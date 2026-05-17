namespace HiAuRo.Helper;

public static class HelperRuntime
{
    private static IHelperContext? _ctx;

    internal static void Initialize(IHelperContext context)
    {
        _ctx = context;
    }

    public static bool HasStatus(uint statusId) =>
        _ctx?.HasStatus(statusId) ?? false;

    public static bool HasStatusOnTarget(uint statusId) =>
        _ctx?.HasStatusOnTarget(statusId) ?? false;

    public static T? GetGauge<T>() where T : class =>
        _ctx?.GetGauge<T>();

    public static float GetAuraTimeLeft(uint buffId) =>
        _ctx?.GetAuraTimeLeft(buffId) ?? 0f;

    public static int GetAuraStackCount(uint buffId) =>
        _ctx?.GetAuraStackCount(buffId) ?? 0;

    public static float GetCharges(uint spellId) =>
        _ctx?.GetCharges(spellId) ?? 0f;

    public static float GetCooldownRemaining(uint spellId) =>
        _ctx?.GetCooldownRemaining(spellId) ?? 0f;

    public static uint GetLastComboSpellId() =>
        _ctx?.GetLastComboSpellId() ?? 0;

    public static int GetGCDCooldown() =>
        _ctx?.GetGCDCooldown() ?? 0;

    public static bool RecentlyUsedSpell(uint spellId, int ms) =>
        _ctx?.RecentlyUsedSpell(spellId, ms) ?? false;

    public static bool IsMoving() =>
        _ctx?.IsMoving() ?? false;

    public static bool IsInCombat() =>
        _ctx?.IsInCombat() ?? false;

    public static int GetNearbyEnemyCount(float range) =>
        _ctx?.GetNearbyEnemyCount(range) ?? 0;

    public static float GetHPPercent() =>
        _ctx?.GetHPPercent() ?? 100f;

    public static int GetCurrentLevel() =>
        _ctx?.GetCurrentLevel() ?? 0;

    public static bool IsCurrentTargetInvincible() =>
        _ctx?.IsCurrentTargetInvincible() ?? false;

    public static uint GetActionChange(uint spellId) =>
        _ctx?.GetActionChange(spellId) ?? spellId;

    // ── 队伍查询 ──

    public static int GetPartyCount() =>
        _ctx?.GetPartyCount() ?? 0;

    public static bool IsPartyMemberAlive(int index) =>
        _ctx?.IsPartyMemberAlive(index) ?? false;

    public static float GetPartyMemberHP(int index) =>
        _ctx?.GetPartyMemberHP(index) ?? 0f;

    public static float GetPartyMemberMaxHP(int index) =>
        _ctx?.GetPartyMemberMaxHP(index) ?? 0f;

    public static float GetPartyMemberHPPercent(int index) =>
        _ctx?.GetPartyMemberHPPercent(index) ?? 0f;
}
