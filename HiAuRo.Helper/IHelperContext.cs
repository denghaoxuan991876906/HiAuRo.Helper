using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("HiAuRo")]

namespace HiAuRo.Helper;

/// <summary>
/// 宿主（HiAuRo）实现此接口，通过 <see cref="HelperRuntime.Initialize"/> 注入。
/// ACR 作者无需关心此接口。
/// </summary>
internal interface IHelperContext
{
    bool HasStatus(uint statusId);
    bool HasStatusOnTarget(uint statusId);
    T? GetGauge<T>() where T : class;

    // ── Buff 查询 ──
    float GetAuraTimeLeft(uint buffId) => 0f;
    int GetAuraStackCount(uint buffId) => 0;

    // ── CD 查询 ──
    float GetCharges(uint spellId) => 0f;
    float GetCooldownRemaining(uint spellId) => 0f;

    // ── Combo / GCD ──
    uint GetLastComboSpellId() => 0;
    int GetGCDCooldown() => 0;

    // ── 技能历史 ──
    bool RecentlyUsedSpell(uint spellId, int ms) => false;

    // ── 战斗状态 ──
    bool IsMoving() => false;
    bool IsInCombat() => false;
    int GetNearbyEnemyCount(float range) => 0;

    // ── 自身属性 ──
    float GetHPPercent() => 100f;
    int GetCurrentLevel() => 0;

    // ── 目标 ──
    bool IsCurrentTargetInvincible() => false;

    // ── 技能数据 ──
    uint GetActionChange(uint spellId) => spellId;
}
