using Dalamud.Game.ClientState.JobGauge;
using HiAuRo.ACR;
using OmenTools.Dalamud.Services.ObjectTable.Abstractions.ObjectKinds;

namespace HiAuRo.Helper;

/// <summary>
/// 游戏数据查询入口 —— 全部通过 HiAuRo.Sdk 暴露的 public API 原生访问。
/// 无状态、静态 API 开箱即用，无需任何初始化。
/// </summary>
public static class GameHelper
{
    // ── Buff / 状态查询 ──

    public static bool HasStatus(uint statusId) =>
        AuraHelper.HasSelfAura(statusId);

    public static bool HasStatusOnTarget(uint statusId) =>
        AuraHelper.HasTargetAura(statusId);

    public static float GetStatusTimeLeftOnTarget(uint statusId) =>
        AuraHelper.GetAuraTimeLeft(Data.Target.Current, statusId);

    /// <summary>自身 buff 剩余时间（秒）</summary>
    public static float GetAuraTimeLeft(uint buffId) =>
        AuraHelper.GetAuraTimeLeft(Data.Me.Object, buffId);

    /// <summary>自身 buff 层数</summary>
    public static int GetAuraStackCount(uint buffId)
    {
        if (Data.Me.Object is not IBattleChara bc) return 0;
        foreach (var s in bc.StatusList)
        {
            if (s.StatusID == buffId)
                return s.Param > 0 ? s.Param : 1;
        }
        return 0;
    }

    /// <summary>职业量谱（通过 Dalamud JobGauges 原生获取）</summary>
    public static T? GetGauge<T>() where T : JobGaugeBase =>
        OmenTools.DService.Instance().JobGauges.Get<T>();

    // ── CD 查询 ──

    /// <summary>技能当前充能层数</summary>
    public static float GetCharges(uint spellId) =>
        SpellHelper.GetCharges(spellId);

    /// <summary>技能剩余冷却时间（毫秒）</summary>
    public static float GetCooldownRemaining(uint spellId) =>
        SpellHelper.GetCooldownRemaining(spellId);

    // ── Combo / GCD ──

    /// <summary>上一个 GCD 技能 ID（0 = 无连击）</summary>
    public static uint GetLastComboSpellId() =>
        ComboHelper.LastComboSpellId;

    /// <summary>GCD 剩余时间（毫秒）</summary>
    public static int GetGCDCooldown() =>
        (int)GCDHelper.GetGCDCooldown();

    // ── 技能历史 ──

    /// <summary>技能是否在最近 <paramref name="ms"/> 毫秒内使用过</summary>
    public static bool RecentlyUsedSpell(uint spellId, int ms) =>
        SpellHistoryHelper.RecentlyUsed(spellId, ms);

    // ── 战斗状态 ──

    /// <summary>是否移动中</summary>
    public static bool IsMoving() =>
        Data.Me.IsMoving;

    /// <summary>是否战斗中</summary>
    public static bool IsInCombat() =>
        Data.Combat.InCombat;

    /// <summary>周围 <paramref name="range"/> 码内敌人数量</summary>
    public static int GetNearbyEnemyCount(float range)
    {
        if (Data.Me.Object == null) return 0;
        var count = 0;
        var enemies = Data.Objects.Enemies;
        for (int i = 0; i < enemies.Count; i++)
        {
            if (Data.Me.DistanceToObject2D(enemies[i]) <= range)
                count++;
        }
        return count;
    }

    // ── 自身属性 ──

    /// <summary>自身血量百分比（0-100）</summary>
    public static float GetHPPercent()
    {
        if (Data.Me.Object is not IBattleChara bc || bc.MaxHp == 0) return 100f;
        return (float)bc.CurrentHp / bc.MaxHp * 100f;
    }

    /// <summary>当前等级</summary>
    public static int GetCurrentLevel() =>
        Data.Me.CurrentLevel;

    // ── 目标 ──

    /// <summary>当前目标是否无敌（无目标/已死/不可选中/带无敌 buff）</summary>
    public static bool IsCurrentTargetInvincible()
    {
        var target = Data.Target.Current;
        return target == null || target.IsDead == true || !target.IsTargetable
            || AuraHelper.HasInvincibleBuffs(target);
    }

    /// <summary>当前目标周围 <paramref name="range"/> 码内敌人数量</summary>
    public static int GetEnemyCountNearTarget(float range) =>
        TargetHelper.GetNearbyEnemyCount(Data.Target.Current, range);

    // ── 技能数据 ──

    /// <summary>技能变身 ID（如无变身则返回原 ID）</summary>
    public static uint GetActionChange(uint spellId) =>
        SpellExtension.GetActionChange(spellId);

    // ── 队伍查询 ──

    /// <summary>队伍人数（含自身，index 0 = 自身）</summary>
    public static int GetPartyCount() =>
        Data.Party.All.Count;

    /// <summary>指定索引的队员是否存活</summary>
    public static bool IsPartyMemberAlive(int index) =>
        GetPartyMember(index)?.IsAlive ?? false;

    /// <summary>指定索引的队员当前血量</summary>
    public static float GetPartyMemberHP(int index)
    {
        if (GetPartyMember(index)?.Player is not IBattleChara bc) return 0f;
        return bc.CurrentHp;
    }

    /// <summary>指定索引的队员最大血量</summary>
    public static float GetPartyMemberMaxHP(int index)
    {
        if (GetPartyMember(index)?.Player is not IBattleChara bc) return 0f;
        return bc.MaxHp;
    }

    /// <summary>指定索引的队员血量百分比（0.0-1.0）</summary>
    public static float GetPartyMemberHPPercent(int index)
    {
        if (GetPartyMember(index)?.Player is not IBattleChara bc || bc.MaxHp == 0) return 0f;
        return (float)bc.CurrentHp / bc.MaxHp;
    }

    private static Data.PartyMemberInfo? GetPartyMember(int index)
    {
        var all = Data.Party.All;
        if ((uint)index >= (uint)all.Count) return null;
        return all[index];
    }
}
