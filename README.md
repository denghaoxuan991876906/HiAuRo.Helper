# HiAuRo.Helper

FFXIV 全战斗职业数据辅助库，基于 `HiAuRo.Sdk`，为 ACR 作者提供静态职业 Helper API。

[![Build](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions/workflows/ci.yml/badge.svg)](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions)
[![AI Review](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions/workflows/pr-review.yml/badge.svg)](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions)

## 设计原则

| 原则 | 实现方式 |
|------|----------|
| **简单引用** | 所有 Helper 均为 `static` 属性/方法，`BRDHelper.HasStraightShotReady` 直接用 |
| **SDK 原生** | Helper 编译期引用 `HiAuRo.Sdk`，复用宿主暴露的 ACR/Data API |
| **ACR 共存** | ACR 可同时引用 `HiAuRo.Sdk` 和 `HiAuRo.Helper`，运行时由 HiAuRo 共享加载 |
| **可贡献** | 作为 git submodule 引入，本地改完即验证，PR 回主库 |

## 构建

```bash
dotnet build HiAuRo.Helper.slnx -c Debug
```

## ACR 作者：如何引用

### 1. 引用 HiAuRo.Sdk

ACR 项目必须先引用与宿主匹配的 `HiAuRo.Sdk`。`ExcludeAssets="runtime"` 确保运行时使用 HiAuRo 宿主已加载的程序集，避免 ACR 目录携带第二份 `HiAuRo.dll`。

```xml
<ItemGroup>
    <PackageReference Include="HiAuRo.Sdk" Version="0.2.11">
        <ExcludeAssets>runtime</ExcludeAssets>
    </PackageReference>
</ItemGroup>
```

### 2. 添加 Helper submodule

```bash
cd YourACR
git submodule add https://github.com/denghaoxuan991876906/HiAuRo.Helper.git Helper
dotnet sln YourACR.slnx add Helper/HiAuRo.Helper/HiAuRo.Helper.csproj
```

### 3. 添加 Helper 项目引用

在你的 `.csproj` 中加入 `ProjectReference`，并排除 submodule 源码被 ACR 项目隐式编译。

```xml
<ItemGroup>
    <Compile Remove="Helper\**" />
    <None Remove="Helper\**" />
    <Content Remove="Helper\**" />
</ItemGroup>

<ItemGroup>
    <ProjectReference Include="Helper\HiAuRo.Helper\HiAuRo.Helper.csproj">
        <Private>False</Private>
    </ProjectReference>
</ItemGroup>
```

`Private=False` 表示 ACR 输出目录不复制 `HiAuRo.Helper.dll`。游戏内运行时由 HiAuRo 宿主的 `HelperUpdater` 加载 Helper，`ACRLoader` 会把 ACR 对 `HiAuRo.Helper` 的引用解析到同一份已加载程序集。

## 技能 / Buff ID 规范

每个 Helper 提供两套 ID 常量，名称已通过 [xivapi-v2](https://xivapi-v2.xivcdn.com) 校验：

| 嵌套类 | 说明 | 示例 |
|--------|------|------|
| `XXXHelper.CN.Skills` | 中文技能名 → Action ID | `WARHelper.CN.Skills.原初的解放` |
| `XXXHelper.CN.Buffs` | 中文 Buff 名 → Status ID | `WARHelper.CN.Buffs.原初的解放` |
| `XXXHelper.EN.Skills` | 英文技能名 → Action ID | `WARHelper.EN.Skills.InnerRelease` |
| `XXXHelper.EN.Buffs` | 英文 Buff 名 → Status ID | `WARHelper.EN.Buffs.InnerRelease` |

> ACR 作者请统一使用 `CN` 或 `EN` 子类下的常量，以保证 ID 来源可追溯、中英对照清晰。

## 直接使用

```csharp
using HiAuRo.Helper;

// 战士：原初的解放 buff 检测
if (WARHelper.Has原初的解放)
    ...

// 也可以用英文名（指向同一个 ID）
if (HelperRuntime.HasStatus(WARHelper.EN.Buffs.InnerRelease))
    ...

// 技能 ID 同理
float cd = WARHelper.获取技能剩余CD(WARHelper.CN.Skills.原初的解放);

// 诗人：直线射击预备 + 当前歌曲
if (BRDHelper.HasStraightShotReady && BRDHelper.CurrentSong == Song.WanderersMinuet)
    ...

// 龙骑：龙威
if (DRGHelper.HasPowerSurge)
    ...
```

无需 `new`，无需实现接口，无需在 ACR 中初始化。

## HiAuRo 宿主加载模型

HiAuRo 宿主负责加载和共享 Helper 程序集：

| 组件 | 职责 |
|------|------|
| `HelperUpdater` | 从 GitHub Release 或本地缓存加载 `HiAuRo.Helper.dll` |
| `HiAuRo.Helper.localdev` | 本地开发标记，存在且 Helper DLL 不旧于宿主 DLL 时跳过在线更新 |
| `ACRLoader` | 当 ACR 请求 `HiAuRo.Helper` 时返回 `HelperUpdater` 已加载的同一份程序集 |

这保证 ACR、Helper 和 HiAuRo 宿主看到的是同一套 `HiAuRo.Sdk`/`HiAuRo` 类型，不会因为 ALC 隔离出现两份 Helper 或两份宿主程序集。

## 依赖

| 项目 | 说明 |
|------|------|
| .NET 10.0 | 运行时 |
| Dalamud.CN.NET.Sdk 15.0.0 | 国服 Dalamud SDK |
| HiAuRo.Sdk 0.2.11 | ACR/Data API 编译引用，运行时由 HiAuRo 宿主提供 |

## 覆盖职业

| 职能 | 职业 |
|------|------|
| 坦克 | PLD, WAR, DRK, GNB |
| 治疗 | WHM, SCH, AST, SGE |
| 近战 | MNK, DRG, NIN, SAM, RPR, VPR |
| 远程 | BRD, MCH, DNC |
| 法师 | BLM, SMN, RDM, PCT |

## 贡献

欢迎 PR：更新技能 ID、补充 Buff 检测、修复版本兼容性。

1. Fork → 创建分支 → 修改 → 提交 PR
2. AI 自动审查通过后可自动合并
