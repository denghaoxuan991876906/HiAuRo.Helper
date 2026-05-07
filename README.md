# HiAuRo.Helper

FFXIV 全战斗职业数据辅助库 — 为 ACR 作者提供统一的职业量谱、Buff、DoT 快捷访问。

独立于 [HiAuRo](https://github.com/denghaoxuan991876906/HiAuRo) 维护，可被任何 Dalamud 插件引用。

[![Build & Release](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions/workflows/ci.yml/badge.svg)](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions)

## HiAuRo.Sdk NuGet 包

一键安装全部开发依赖（HiAuRo 框架 + 本库 + OmenTools + Dalamud 运行时），ACR 开发者零配置开写。

```bash
# 添加 GitHub Packages 源
dotnet nuget add source "https://nuget.pkg.github.com/denghaoxuan991876906/index.json" -n github

# 安装
dotnet add package HiAuRo.Sdk
```

无需 `DALAMUD_HOME`、无需子模块、无需多项目引用。

> 手动下载：每期 Release 附带 `.nupkg` 文件，或取 [nuget/](nuget/) 目录下的最新包。

## 覆盖职业

| 职能 | 职业 |
|------|------|
| 🛡️ 坦克 | PLD, WAR, DRK, GNB |
| 💚 治疗 | WHM, SCH, AST, SGE |
| ⚔️ 近战 | MNK, DRG, NIN, SAM, RPR, VPR |
| 🏹 远程 | BRD, MCH, DNC |
| 🔮 法师 | BLM, SMN, RDM, PCT |

## 快速使用

```csharp
using HiAuRo.Helper;

class MyContext : IHelperContext
{
    public bool HasStatus(uint id) => LocalPlayerState.HasStatus(id, out _);
    public IPlayerCharacter? GetTarget() => TargetManager.Target as IPlayerCharacter;
    public bool HasStatusOnTarget(uint id) => Target.Current is IBattleChara bc
        && bc.StatusList.Any(s => s.StatusID == id && s.SourceID == Me.Object?.EntityID);
}

var brd = new BRDHelper(new MyContext());
if (brd.HasStraightShotReady && brd.CurrentSong == Song.WanderersMinuet)
    brd.HasRagingStrikes  // 猛者强击是否激活
```

| Helper | 提供 |
|--------|------|
| 量谱 | `Gauge` — 职业量谱（如 `BRDGauge`, `PLDGauge`） |
| Buff 检测 | `HasXXX` — 常见 Buff 是否激活 |
| DoT 检测 | `HasXXXOnTarget` — 目标上 DoT 是否由自己施加 |
| 资源 | `SoulVoice`, `Kenki`, `BloodGauge` — 职业特有资源值 |

## 依赖

| 项目 | 说明 |
|------|------|
| .NET 10.0 | 运行时 |
| [OmenTools](https://github.com/AtmoOmen/OmenTools) | `DService` + Dalamud 服务封装 |
| Dalamud.CN.NET.Sdk 15.0.0 | 国服 Dalamud 插件 SDK |

## 构建

```bash
export DALAMUD_HOME=/path/to/XIVLauncherCN/addon/Hooks/dev
dotnet build HiAuRo.Helper.csproj
```

## CI / CD

推送 tag 自动触发构建 → 发布 `.nupkg` 到 GitHub Packages + Release。

```bash
git tag v0.2.0 && git push --tags
```

## 贡献

欢迎 PR：更新技能 ID、补充 Buff 检测、修复游戏版本兼容性。
