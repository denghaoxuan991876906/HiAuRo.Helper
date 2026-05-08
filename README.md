# HiAuRo.Helper

FFXIV 全战斗职业数据辅助库 — 零公共依赖，静态 API 开箱即用。

[![Build](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions/workflows/ci.yml/badge.svg)](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions)
[![AI Review](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions/workflows/pr-review.yml/badge.svg)](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions)

## 设计原则

| 原则 | 实现方式 |
|------|----------|
| **简单引用** | 所有 Helper 均为 `static` 属性/方法，`BRDHelper.HasStraightShotReady` 直接用 |
| **不冲突** | 公共 API 零 OmenTypes 依赖；OmenTools 以条件 `ProjectReference` 引入，不与 ACR 已有引用冲突 |
| **可贡献** | 作为 git submodule 引入，本地改完即验证，PR 回主库 |

## 构建

```bash
git clone --recursive https://github.com/denghaoxuan991876906/HiAuRo.Helper
cd HiAuRo.Helper
export DALAMUD_HOME=/path/to/XIVLauncherCN/addon/Hooks/dev
dotnet build
```

## ACR 作者：如何引用

### 1. 添加 submodule

```bash
cd YourACR
git submodule add https://github.com/denghaoxuan991876906/HiAuRo.Helper.git Helper
```

### 2. 加入 solution

```bash
dotnet sln YourACR.slnx add Helper/HiAuRo.Helper/HiAuRo.Helper.csproj
```

### 3. 添加项目引用

在你的 `.csproj` 中：

```xml
<ItemGroup>
    <ProjectReference Include="Helper\HiAuRo.Helper\HiAuRo.Helper.csproj">
        <Private>False</Private>
    </ProjectReference>
</ItemGroup>
```

### 4. 直接使用

```csharp
using HiAuRo.Helper;

// 诗人：直线射击预备 + 当前歌曲
if (BRDHelper.HasStraightShotReady && BRDHelper.CurrentSong == Song.WanderersMinuet)
    ...

// 战士：原初的解放
if (WARHelper.Has原初的解放)
    ...

// 龙骑：龙威
if (DRGHelper.HasPowerSurge)
    ...
```

无需 `new`，无需实现接口，无需关心初始化 — HiAuRo 宿主会自动完成。

### OmenTools 不冲突

Helper 对 OmenTools 的引用是**条件引用**——只在 submodule 存在时生效。你的 ACR 项目如果已引用 OmenTools，Helper 会直接复用同一份类型，不会冲突。

## HiAuRo 宿主：如何接入

Helper 的 `IHelperContext` 和 `HelperRuntime.Initialize` 均为 `internal`，通过 `[assembly: InternalsVisibleTo("HiAuRo")]` 仅对 HiAuRo 程序集开放。

在 HiAuRo 中实现接口并初始化：

```csharp
using HiAuRo.Helper;
using Dalamud.Game.ClientState.Statuses;
using OmenTools.Dalamud.Services.ObjectTable.Abstractions.ObjectKinds;

internal sealed class HiAuRoContextImpl : IHelperContext
{
    public bool HasStatus(uint statusId)
    {
        var player = DService.Instance().ClientState.LocalPlayer;
        if (player == null) return false;

        foreach (var status in player.StatusList)
        {
            if (status.StatusId == statusId)
                return true;
        }
        return false;
    }

    public bool HasStatusOnTarget(uint statusId)
    {
        var target = DService.Instance().TargetManager.SoftTarget
                  ?? DService.Instance().TargetManager.Target;
        if (target is not IBattleChara battle) return false;

        foreach (var status in battle.StatusList)
        {
            if (status.StatusId == statusId)
                return true;
        }
        return false;
    }
}
```

在 HiAuRo 插件加载时调用一次：

```csharp
HelperRuntime.Initialize(new HiAuRoContextImpl());
```

## 依赖

| 项目 | 说明 |
|------|------|
| .NET 10.0 | 运行时 |
| [OmenTools](https://github.com/AtmoOmen/OmenTools) | `DService` + Dalamud 服务封装（git submodule，仅内部使用） |
| Dalamud.CN.NET.Sdk 15.0.0 | 国服 Dalamud SDK |

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