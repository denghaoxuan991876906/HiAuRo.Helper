# HiAuRo.Helper

FFXIV 全战斗职业数据辅助库 — 零 HiAuRo 依赖，可被任何 Dalamud 插件引用。

[![Build](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions/workflows/ci.yml/badge.svg)](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions)
[![AI Review](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions/workflows/pr-review.yml/badge.svg)](https://github.com/denghaoxuan991876906/HiAuRo.Helper/actions)

## 构建

```bash
git clone --recursive https://github.com/denghaoxuan991876906/HiAuRo.Helper
cd HiAuRo.Helper
export DALAMUD_HOME=/path/to/XIVLauncherCN/addon/Hooks/dev
dotnet build
```

## 依赖

| 项目 | 说明 |
|------|------|
| .NET 10.0 | 运行时 |
| [OmenTools](https://github.com/AtmoOmen/OmenTools) | `DService` + Dalamud 服务封装（git submodule） |
| Dalamud.CN.NET.Sdk 15.0.0 | 国服 Dalamud SDK |

## 覆盖职业

| 职能 | 职业 |
|------|------|
| 🛡️ 坦克 | PLD, WAR, DRK, GNB |
| 💚 治疗 | WHM, SCH, AST, SGE |
| ⚔️ 近战 | MNK, DRG, NIN, SAM, RPR, VPR |
| 🏹 远程 | BRD, MCH, DNC |
| 🔮 法师 | BLM, SMN, RDM, PCT |

## 使用

```csharp
using HiAuRo.Helper;

class MyContext : IHelperContext
{
    public bool HasStatus(uint id) => LocalPlayerState.HasStatus(id, out _);
    public IPlayerCharacter? GetTarget() => TargetManager.Target as IPlayerCharacter;
    public bool HasStatusOnTarget(uint id) { /* 目标 DoT */ }
}

var brd = new BRDHelper(new MyContext());
if (brd.HasStraightShotReady && brd.CurrentSong == Song.WanderersMinuet) { }
```

## 贡献

欢迎 PR：更新技能 ID、补充 Buff 检测、修复版本兼容性。
