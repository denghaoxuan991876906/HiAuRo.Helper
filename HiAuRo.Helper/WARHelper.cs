namespace HiAuRo.Helper;

/// <summary>
/// 战士 (WAR) 职业入口 —— 技能/Buff ID 常量 + 状态查询
/// </summary>
public class WARHelper
{
    #region CN — 中文名称

    public static class CN
    {
        public static class Skills
        {
            public const uint
                重劈 = 31,
                凶残裂 = 37,
                狂暴 = 38,
                战栗 = 40,
                超压斧 = 41,
                暴风斩 = 42,
                死斗 = 43,
                复仇 = 44,
                暴风碎 = 45,
                飞斧 = 46,
                守护 = 48,
                原初之魂 = 49,
                钢铁旋风 = 51,
                战嚎 = 52,
                裂石飞环 = 3549,
                地毁人亡 = 3550,
                原初的直觉 = 3551,
                泰然自若 = 3552,
                猛攻 = 7386,
                动乱 = 7387,
                摆脱 = 7388,
                原初的解放 = 7389,
                铁壁 = 7531,
                挑衅 = 7533,
                雪仇 = 7535,
                退避 = 7537,
                插言 = 7538,
                下踢 = 7540,
                亲疏自行 = 7548,
                秘银暴风 = 16462,
                混沌旋风 = 16463,
                原初的勇猛 = 16464,
                狂魂 = 16465,
                原初的血气 = 25751,
                群山隆起 = 25752,
                蛮荒崩裂 = 25753,
                解除守护 = 32066,
                戮罪 = 36923,
                原初的怒震 = 36924,
                尽毁 = 36925;
        }

        public static class Buffs
        {
            public const uint
                战场风暴 = 2677,
                死斗 = 409,
                原初的混沌 = 1897,
                原初的解放 = 1177,
                原初的觉悟 = 2663,
                守护 = 91,
                原初的搏动 = 3833,
                尽毁预备 = 3834,
                蛮荒崩裂预备 = 2624,
                原初的怒震预备 = 3901,
                亲疏自行 = 1209,
                雪仇 = 1193,
                原初的血气 = 2678,
                原初的直觉 = 735,
                复仇 = 89,
                戮罪 = 3832,
                战栗 = 87,
                铁壁 = 1191,
                亲疏自行减伤 = 1984;
        }
    }

    #endregion

    #region EN — English Names (verified via XIVAPI v2)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                HeavySwing = 31,
                Maim = 37,
                Berserk = 38,
                ThrillOfBattle = 40,
                Overpower = 41,
                StormsPath = 42,
                Holmgang = 43,
                Vengeance = 44,
                StormsEye = 45,
                Tomahawk = 46,
                Defiance = 48,
                InnerBeast = 49,
                SteelCyclone = 51,
                Infuriate = 52,
                FellCleave = 3549,
                Decimate = 3550,
                RawIntuition = 3551,
                Equilibrium = 3552,
                Onslaught = 7386,
                Upheaval = 7387,
                ShakeItOff = 7388,
                InnerRelease = 7389,
                Rampart = 7531,
                Provoke = 7533,
                Reprisal = 7535,
                Shirk = 7537,
                Interject = 7538,
                LowBlow = 7540,
                ArmsLength = 7548,
                MythrilTempest = 16462,
                ChaoticCyclone = 16463,
                NascentFlash = 16464,
                InnerChaos = 16465,
                Bloodwhetting = 25751,
                Orogeny = 25752,
                PrimalRend = 25753,
                ReleaseDefiance = 32066,
                Damnation = 36923,
                PrimalWrath = 36924,
                PrimalRuination = 36925;
        }

        public static class Buffs
        {
            public const uint
                SurgingTempest = 2677,
                Holmgang = 409,
                NascentChaos = 1897,
                InnerRelease = 1177,
                InnerStrength = 2663,
                Defiance = 91,
                BurgeoningFury = 3833,
                PrimalRuinationReady = 3834,
                PrimalRendReady = 2624,
                Wrathful = 3901,
                ArmsLength = 1209,
                Reprisal = 1193,
                Bloodwhetting = 2678,
                RawIntuition = 735,
                Vengeance = 89,
                Damnation = 3832,
                ThrillOfBattle = 87,
                Rampart = 1191,
                ArmsLengthSlowResist = 1984;
        }
    }

    #endregion

    #region 内部 Buff ID

    public const uint _原初的解放 = CN.Buffs.原初的解放;
    public const uint _狂暴 = 86;
    public const uint _原初的混沌 = CN.Buffs.原初的混沌;
    public const uint _红斩 = CN.Buffs.战场风暴;
    public const uint _战栗 = CN.Buffs.战栗;
    public const uint _复仇 = CN.Buffs.复仇;
    public const uint _死斗 = 88;
    public const uint _蛮荒崩裂预备 = CN.Buffs.蛮荒崩裂预备;
    public const uint _尽毁预备 = CN.Buffs.尽毁预备;
    public const uint _原初的怒震预备 = CN.Buffs.原初的怒震预备;
    public const uint _原初的血气 = CN.Buffs.原初的血气;
    public const uint _守护 = CN.Buffs.守护;
    public const uint _原初的觉悟 = CN.Buffs.原初的觉悟;

    #endregion

    #region 实例属性 — 状态查询

    public static WARGauge? Gauge => HelperRuntime.GetGauge<WARGauge>();
    public static byte BeastGauge => Gauge?.BeastGauge ?? 0;

    public static bool HasInnerRelease => HelperRuntime.HasStatus(_原初的解放);
    public static bool HasBerserk => HelperRuntime.HasStatus(_狂暴);
    public static bool HasSurgingTempest => HelperRuntime.HasStatus(_红斩);
    public static bool HasNascentChaos => HelperRuntime.HasStatus(_原初的混沌);

    public static bool Has红斩 => HelperRuntime.HasStatus(_红斩);
    public static bool Has原初的解放 => HelperRuntime.HasStatus(_原初的解放);
    public static bool Has狂暴 => HelperRuntime.HasStatus(_狂暴);
    public static bool Has原初的混沌 => HelperRuntime.HasStatus(_原初的混沌);
    public static bool Has原初的觉悟 => HelperRuntime.HasStatus(_原初的觉悟);
    public static bool Has战栗 => HelperRuntime.HasStatus(_战栗);
    public static bool Has复仇 => HelperRuntime.HasStatus(_复仇);
    public static bool Has死斗 => HelperRuntime.HasStatus(_死斗);
    public static bool Has蛮荒崩裂预备 => HelperRuntime.HasStatus(_蛮荒崩裂预备);
    public static bool Has尽毁预备 => HelperRuntime.HasStatus(_尽毁预备);
    public static bool Has原初的怒震预备 => HelperRuntime.HasStatus(_原初的怒震预备);
    public static bool Has原初的血气 => HelperRuntime.HasStatus(_原初的血气);
    public static bool Has守护 => HelperRuntime.HasStatus(_守护);

    #endregion

    #region 战斗运行时

    public static float 获取Buff剩余时间(uint buffId)
    {
        return HelperRuntime.HasStatus(buffId)
            ? HelperRuntime.GetAuraTimeLeft(buffId) : 0f;
    }

    public static int 获取Buff层数(uint buffId)
    {
        return HelperRuntime.HasStatus(buffId)
            ? HelperRuntime.GetAuraStackCount(buffId) : 0;
    }

    public static float 获取技能充能层数(uint spellId) =>
        HelperRuntime.GetCharges(spellId);

    public static float 获取技能最大充能层数(uint spellId)
    {
        if (spellId == CN.Skills.猛攻) return HelperRuntime.GetCurrentLevel() >= 88 ? 3 : 2;
        if (spellId == CN.Skills.战嚎) return 2;
        return 1;
    }

    public static float 获取技能剩余CD(uint spellId)
    {
        var actualId = HelperRuntime.GetActionChange(spellId);
        return HelperRuntime.GetCooldownRemaining(actualId);
    }

    public static bool 技能CD快好了(uint spellId, float seconds)
    {
        var cd = 获取技能剩余CD(spellId);
        return cd > 0 && cd < seconds * 1000;
    }

    public static uint 获取上一个GCD技能ID() => HelperRuntime.GetLastComboSpellId();
    public static int 获取GCD剩余时间() => HelperRuntime.GetGCDCooldown();
    public static bool 技能最近是否使用过(uint spellId, int ms) =>
        HelperRuntime.RecentlyUsedSpell(spellId, ms);

    public static float 获取爆发期剩余时间()
    {
        return HelperRuntime.HasStatus(_原初的觉悟)
            ? HelperRuntime.GetAuraTimeLeft(_原初的觉悟) : 0f;
    }

    public static float 获取红斩剩余时间()
    {
        return HelperRuntime.HasStatus(_红斩)
            ? HelperRuntime.GetAuraTimeLeft(_红斩) : 0f;
    }

    public static int 获取解放层数()
    {
        if (!HelperRuntime.HasStatus(CN.Buffs.原初的解放)) return 0;
        return Math.Max(1, HelperRuntime.GetAuraStackCount(CN.Buffs.原初的解放));
    }

    #endregion

    #region 目标与战斗环境

    public static bool 目标是否无敌()
    {
        return HelperRuntime.IsCurrentTargetInvincible();
    }

    public static int 获取周围敌人数量(float range = 10f) =>
        HelperRuntime.GetNearbyEnemyCount(range);

    public static bool 是否在战斗中() => HelperRuntime.IsInCombat();
    public static bool 是否在移动中() => HelperRuntime.IsMoving();

    public static float 获取血量百分比() => HelperRuntime.GetHPPercent();

    public static bool 是否在拉怪中(bool 启用自动拉怪, bool 启用拉怪中检测, float 搜索范围, int 敌人数阈值)
    {
        if (!启用自动拉怪 || !启用拉怪中检测) return false;
        return 是否在移动中() && 获取周围敌人数量(搜索范围) >= 敌人数阈值;
    }

    public static int 获取血量最低成员索引()
    {
        int count = HelperRuntime.GetPartyCount();
        if (count <= 1) return -1;

        int lowestIdx = -1;
        float lowestHp = float.MaxValue;

        for (int i = 1; i < count; i++)
        {
            if (!HelperRuntime.IsPartyMemberAlive(i)) continue;
            float hp = HelperRuntime.GetPartyMemberHP(i);
            if (hp < lowestHp)
            {
                lowestHp = hp;
                lowestIdx = i;
            }
        }

        return lowestIdx;
    }

    public static int 获取血量百分比最低成员索引()
    {
        int count = HelperRuntime.GetPartyCount();
        if (count <= 1) return -1;

        int lowestIdx = -1;
        float lowestPct = float.MaxValue;

        for (int i = 1; i < count; i++)
        {
            if (!HelperRuntime.IsPartyMemberAlive(i)) continue;
            float pct = HelperRuntime.GetPartyMemberHPPercent(i);
            if (pct < lowestPct)
            {
                lowestPct = pct;
                lowestIdx = i;
            }
        }

        return lowestIdx;
    }

    #endregion
}
