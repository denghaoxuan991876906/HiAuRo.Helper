using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HiAuRo")]

namespace HiAuRo.Helper;

/// <summary>
/// 宿主（HiAuRo）实现此接口，通过 <see cref="HelperRuntime.Initialize"/> 注入。
/// ACR 作者无需关心此接口。
/// 所有默认实现仅作为安全回退值；HiAuRo 框架必须覆盖所有方法以返回真实游戏数据。
/// </summary>
internal interface IHelperContext
{
    bool HasStatus(uint statusId);
    bool HasStatusOnTarget(uint statusId);
    T? GetGauge<T>() where T : class;

    // ── Buff 查询 ──

    /// <summary>自身 buff 剩余时间（秒）</summary>
    float GetAuraTimeLeft(uint buffId) => 0f;

    /// <summary>自身 buff 层数</summary>
    int GetAuraStackCount(uint buffId) => 0;

    // ── CD 查询 ──

    /// <summary>技能当前充能层数</summary>
    float GetCharges(uint spellId) => 0f;

    /// <summary>技能剩余冷却时间（毫秒）</summary>
    float GetCooldownRemaining(uint spellId) => 0f;

    // ── Combo / GCD ──

    /// <summary>上一个 GCD 技能 ID（0 = 无连击）</summary>
    uint GetLastComboSpellId() => 0;

    /// <summary>GCD 剩余时间（毫秒）</summary>
    int GetGCDCooldown() => 0;

    // ── 技能历史 ──

    /// <summary>技能是否在最近 <paramref name="ms"/> 毫秒内使用过</summary>
    bool RecentlyUsedSpell(uint spellId, int ms) => false;

    // ── 战斗状态 ──

    /// <summary>是否移动中</summary>
    bool IsMoving() => false;

    /// <summary>是否战斗中</summary>
    bool IsInCombat() => false;

    /// <summary>周围 <paramref name="range"/> 码内敌人数量</summary>
    int GetNearbyEnemyCount(float range) => 0;

    // ── 自身属性 ──

    /// <summary>自身血量百分比（0-100）</summary>
    float GetHPPercent() => 100f;

    /// <summary>当前等级</summary>
    int GetCurrentLevel() => 0;

    // ── 目标 ──

    /// <summary>当前目标是否无敌（已死/不可攻击）</summary>
    bool IsCurrentTargetInvincible() => false;

    // ── 技能数据 ──

    /// <summary>技能变身 ID（如无变身则返回原 ID）</summary>
    uint GetActionChange(uint spellId) => spellId;

    // ── 队伍查询 ──

    /// <summary>队伍人数（含自身，index 0 = 自身）</summary>
    int GetPartyCount() => 0;

    /// <summary>指定索引的队员是否存活</summary>
    bool IsPartyMemberAlive(int index) => false;

    /// <summary>指定索引的队员当前血量</summary>
    float GetPartyMemberHP(int index) => 0f;

    /// <summary>指定索引的队员最大血量</summary>
    float GetPartyMemberMaxHP(int index) => 0f;

    /// <summary>指定索引的队员血量百分比（0.0-1.0）</summary>
    float GetPartyMemberHPPercent(int index) => 0f;
}
