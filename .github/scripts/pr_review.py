#!/usr/bin/env python3
"""
HiAuRo.Helper - DeepSeek AI 自动 PR 审查脚本
调用 DeepSeek API 审查 PR diff，输出审查意见并判定是否可合并

环境变量:
  DEEPSEEK_API_KEY  - DeepSeek API 密钥 (必需)
  DEEPSEEK_MODEL    - 模型名称 (默认: deepseek-v4-flash)
  DEEPSEEK_API_BASE - API 地址 (默认: https://api.deepseek.com)
  GITHUB_OUTPUT     - GitHub Actions 输出文件路径

输出:
  通过 GITHUB_OUTPUT 设置:
    verdict  - APPROVE / REJECT / SKIP / ERROR
  生成文件 review_body.md 包含 Markdown 格式的审查评论
"""

import json
import os
import re
import subprocess
import sys
import urllib.request
import urllib.error


def get_pr_diff() -> str:
    """使用 GitHub API 获取 PR diff（比 git 命令更可靠）"""
    token = os.environ.get('GITHUB_TOKEN', '')
    repo = os.environ.get('GITHUB_REPOSITORY', '')
    pr_number = os.environ.get('PR_NUMBER', '')
    api_url = os.environ.get('GITHUB_API_URL', 'https://api.github.com')

    if not token or not repo or not pr_number:
        print("错误: 缺少 GITHUB_TOKEN / GITHUB_REPOSITORY / PR_NUMBER")
        sys.exit(1)

    diff_url = f"{api_url}/repos/{repo}/pulls/{pr_number}"

    req = urllib.request.Request(
        diff_url,
        headers={
            "Accept": "application/vnd.github.v3.diff",
            "Authorization": f"Bearer {token}",
            "User-Agent": "HiAuRo-PR-Review",
        },
    )

    try:
        with urllib.request.urlopen(req, timeout=30) as resp:
            diff = resp.read().decode('utf-8')
            return diff
    except urllib.error.HTTPError as e:
        print(f"获取 PR diff 失败 (HTTP {e.code}): {e.reason}")
        sys.exit(1)
    except Exception as e:
        print(f"获取 PR diff 失败: {e}")
        sys.exit(1)


def call_deepseek(diff: str, api_key: str, model: str, api_base: str) -> dict:
    """调用 DeepSeek API 进行代码审查，返回原始响应字典"""

    # 截断过长的 diff（deepseek-v4-flash 上下文约 128K tokens，保守使用 60K 字符）
    max_chars = 60000
    truncated = False
    if len(diff) > max_chars:
        diff = diff[:max_chars]
        truncated = True

    # 系统提示词
    system_prompt = """你是一个资深 C# 代码审查专家，专注于 FFXIV Dalamud 插件开发。

请审查以下 git diff 中的代码变更，重点关注：

1. **潜在 Bug**：空引用（NullReferenceException）、逻辑错误、边界条件遗漏
2. **性能问题**：不必要的内存分配、重复计算、锁竞争、大量 string 拼接
3. **Dalamud 最佳实践**：
   - 使用 IObjectTable 获取本地玩家，不直接用 ClientState.LocalPlayer（已弃用）
   - 避免多次遍历 IPartyMember.GameObject（昂贵操作）
   - 敌人分类不能仅凭 BattleNpcSubKind.Enemy（友方 NPC 也可能有该标志）
   - 使用 DService.* 访问 Dalamud 服务，不自行创建 ServiceWrapper
4. **代码风格一致性**：
   - 中文注释
   - 扁平直接，避免不必要的抽象层
   - 文件名使用中文描述（如 BRD_GCD_强力射击.cs）
5. **安全隐患**：硬编码密钥、路径注入、不安全的反序列化

你必须严格按照以下 JSON 格式返回审查结果（不要包含 markdown 代码块标记，只返回纯 JSON）：

{"verdict":"APPROVE","summary":"变更总结（中文，一句话）","issues":[{"severity":"critical","file":"涉及文件路径","description":"问题描述（中文）","suggestion":"修复建议（中文）"}]}

verdict 取值："APPROVE" 或 "REJECT"
severity 取值："critical"（必须修复才能合并）/ "warning"（建议修复）/ "info"（提示信息）
如果没有任何问题，verdict 为 "APPROVE"，issues 为空数组 []
包含一个 "files_changed" 字段，列出变更涉及的文件名（去重）"""

    user_prompt = f"请审查以下 PR 代码变更：\n\n{diff}"
    if truncated:
        user_prompt += "\n\n（注意：diff 过长已被截断至前 60000 字符）"

    payload = {
        "model": model,
        "messages": [
            {"role": "system", "content": system_prompt},
            {"role": "user", "content": user_prompt},
        ],
        "temperature": 0.1,
        "stream": False,
    }

    api_url = f"{api_base}/chat/completions"
    data = json.dumps(payload).encode('utf-8')

    req = urllib.request.Request(
        api_url,
        data=data,
        headers={
            "Content-Type": "application/json",
            "Authorization": f"Bearer {api_key}",
        },
    )

    print(f"调用 DeepSeek API: {api_url} (模型: {model})")

    try:
        with urllib.request.urlopen(req, timeout=300) as resp:
            return json.loads(resp.read().decode('utf-8'))
    except urllib.error.HTTPError as e:
        body = e.read().decode('utf-8', errors='replace')
        print(f"API HTTP {e.code}: {body}")
        raise
    except Exception as e:
        print(f"API 调用失败: {e}")
        raise


def parse_review(raw_response: dict) -> dict:
    """从 DeepSeek API 原始响应中提取并解析审查结果 JSON"""
    try:
        content = raw_response['choices'][0]['message']['content']
    except (KeyError, IndexError, TypeError) as e:
        print(f"API 响应格式异常: {e}")
        print(f"原始响应: {json.dumps(raw_response, ensure_ascii=False)[:500]}")
        sys.exit(1)

    # 尝试直接解析
    try:
        review = json.loads(content.strip())
        _validate_review(review)
        return review
    except (json.JSONDecodeError, ValueError):
        pass

    # 尝试从 markdown 代码块中提取
    json_match = re.search(r'```(?:json)?\s*([\s\S]*?)```', content)
    if json_match:
        try:
            review = json.loads(json_match.group(1).strip())
            _validate_review(review)
            return review
        except (json.JSONDecodeError, ValueError):
            pass

    # 尝试从文本中找到第一个 JSON 对象
    json_match = re.search(r'\{[\s\S]*\}', content)
    if json_match:
        try:
            review = json.loads(json_match.group())
            _validate_review(review)
            return review
        except (json.JSONDecodeError, ValueError):
            pass

    # 所有解析尝试均失败
    print(f"无法解析 API 返回内容为 JSON:")
    print(content[:2000])
    sys.exit(1)


def _validate_review(review: dict):
    """验证审查结果的基本结构"""
    if 'verdict' not in review:
        raise ValueError("缺少 verdict 字段")
    if review['verdict'] not in ('APPROVE', 'REJECT'):
        raise ValueError(f"verdict 值无效: {review['verdict']}")
    if 'issues' not in review:
        review['issues'] = []
    if 'summary' not in review:
        review['summary'] = ''


def format_review(review: dict, model: str) -> str:
    """将审查结果格式化为 Markdown 评论"""
    verdict = review.get('verdict', 'REJECT')
    summary = review.get('summary', '')
    issues = review.get('issues', [])
    files = review.get('files_changed', [])

    # 标题
    if verdict == 'APPROVE':
        body = "## 🤖 AI Code Review — ✅ 审查通过\n\n"
        body += "> 未发现需要修复的问题，即将自动合并。\n\n"
    else:
        body = "## 🤖 AI Code Review — ❌ 需要修复\n\n"
        body += "> 发现以下问题，请在合并前修复。\n\n"

    # 总结
    if summary:
        body += f"### 📋 审查总结\n\n{summary}\n\n"

    # 涉及文件
    if files:
        body += "### 📁 变更文件\n\n"
        for f in files:
            body += f"- `{f}`\n"
        body += "\n"

    # 问题列表
    if issues:
        body += "### 🔍 发现问题\n\n"
        for i, issue in enumerate(issues, 1):
            sev = issue.get('severity', 'info')
            sev_labels = {
                'critical': '🔴 Critical',
                'warning': '🟡 Warning',
                'info': '🔵 Info',
            }
            sev_label = sev_labels.get(sev, f'⚪ {sev}')

            file_name = issue.get('file', '-')
            desc = issue.get('description', '')
            suggestion = issue.get('suggestion', '')

            body += f"#### {i}. {sev_label}\n\n"
            body += f"- **文件**: `{file_name}`\n"
            body += f"- **问题**: {desc}\n"
            if suggestion:
                body += f"- **建议**: {suggestion}\n"
            body += "\n"
    else:
        body += "### ✅ 未发现问题\n\n"

    # 页脚
    body += "---\n"
    body += f"<sub>🤖 此评论由 [DeepSeek AI](https://api-docs.deepseek.com/) 自动生成 · "
    body += f"模型: `{model}` · "
    body += f"审查时间: 自动触发</sub>\n"

    return body


def main():
    # 配置
    model = os.environ.get('DEEPSEEK_MODEL', 'deepseek-v4-flash')
    api_base = os.environ.get('DEEPSEEK_API_BASE', 'https://api.deepseek.com')
    api_key = os.environ.get('DEEPSEEK_API_KEY', '')

    if not api_key:
        print("错误: 环境变量 DEEPSEEK_API_KEY 未设置")
        _write_output('ERROR', 'API key 未配置')
        sys.exit(1)

    # 获取 diff
    print("获取 PR diff...")
    diff = get_pr_diff()

    if not diff.strip():
        print("PR 无代码变更，跳过审查")
        _write_output('SKIP', '无代码变更')
        return

    print(f"Diff 大小: {len(diff)} 字符 ({diff.count(chr(10))} 行)")

    # 调用 DeepSeek
    try:
        response = call_deepseek(diff, api_key, model, api_base)
    except Exception:
        _write_output('ERROR', 'API 调用失败')
        sys.exit(1)

    # 解析结果
    print("解析审查结果...")
    review = parse_review(response)

    verdict = review.get('verdict', 'REJECT')

    # 格式化评论
    body = format_review(review, model)

    # 写入评论文件（供 workflow 读取）
    with open('review_body.md', 'w', encoding='utf-8') as f:
        f.write(body)

    # 输出到 stdout（可在 Actions log 中查看）
    print(body)

    # 写入 GITHUB_OUTPUT
    _write_output(verdict, review.get('summary', ''))

    print(f"\n审查完成: {verdict}")


def _write_output(verdict: str, summary: str):
    """写入 GitHub Actions output"""
    output_file = os.environ.get('GITHUB_OUTPUT', '')
    if not output_file:
        return
    with open(output_file, 'a', encoding='utf-8') as f:
        f.write(f"verdict={verdict}\n")
        # summary 可能包含换行符，需要转义
        escaped = summary.replace('%', '%25').replace('\n', '%0A').replace('\r', '%0D')
        f.write(f"summary={escaped}\n")


if __name__ == '__main__':
    main()
