namespace HiAuRo.Helper;

public static class HelperRuntime
{
    private static IHelperContext? _ctx;

    internal static void Initialize(IHelperContext context)
    {
        _ctx = context;
    }

    internal static bool HasStatus(uint statusId) =>
        _ctx?.HasStatus(statusId) ?? false;

    internal static bool HasStatusOnTarget(uint statusId) =>
        _ctx?.HasStatusOnTarget(statusId) ?? false;

    internal static T? GetGauge<T>() where T : class =>
        _ctx?.GetGauge<T>();

    internal static float GetAuraTimeLeft(uint buffId) =>
        _ctx?.GetAuraTimeLeft(buffId) ?? 0f;

    internal static int GetAuraStackCount(uint buffId) =>
        _ctx?.GetAuraStackCount(buffId) ?? 0;

    internal static float GetCharges(uint spellId) =>
        _ctx?.GetCharges(spellId) ?? 0f;

    internal static float GetCooldownRemaining(uint spellId) =>
        _ctx?.GetCooldownRemaining(spellId) ?? 0f;

    internal static uint GetLastComboSpellId() =>
        _ctx?.GetLastComboSpellId() ?? 0;

    internal static int GetGCDCooldown() =>
        _ctx?.GetGCDCooldown() ?? 0;

    internal static bool RecentlyUsedSpell(uint spellId, int ms) =>
        _ctx?.RecentlyUsedSpell(spellId, ms) ?? false;

    internal static bool IsMoving() =>
        _ctx?.IsMoving() ?? false;

    internal static bool IsInCombat() =>
        _ctx?.IsInCombat() ?? false;

    internal static int GetNearbyEnemyCount(float range) =>
        _ctx?.GetNearbyEnemyCount(range) ?? 0;

    internal static float GetHPPercent() =>
        _ctx?.GetHPPercent() ?? 100f;

    internal static int GetCurrentLevel() =>
        _ctx?.GetCurrentLevel() ?? 0;

    internal static bool IsCurrentTargetInvincible() =>
        _ctx?.IsCurrentTargetInvincible() ?? false;

    internal static uint GetActionChange(uint spellId) =>
        _ctx?.GetActionChange(spellId) ?? spellId;

    // ── 队伍查询 ──

    internal static int GetPartyCount() =>
        _ctx?.GetPartyCount() ?? 0;

    internal static bool IsPartyMemberAlive(int index) =>
        _ctx?.IsPartyMemberAlive(index) ?? false;

    internal static float GetPartyMemberHP(int index) =>
        _ctx?.GetPartyMemberHP(index) ?? 0f;

    internal static float GetPartyMemberMaxHP(int index) =>
        _ctx?.GetPartyMemberMaxHP(index) ?? 0f;

    internal static float GetPartyMemberHPPercent(int index) =>
        _ctx?.GetPartyMemberHPPercent(index) ?? 0f;
}
