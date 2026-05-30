namespace HiAuRo.Helper;

/// <summary>
/// 骑士 (PLD) 职业入口 —— 技能/Buff ID 常量 + 状态查询
/// </summary>
public class PLDHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)
    public static class CN
    {
        public static class Skills
        {
            public const uint
                先锋剑 = 9,
                暴乱剑 = 15,
                盾牌猛击 = 16,
                战逃反应 = 20,
                战女神之怒 = 21,
                壁垒 = 22,
                厄运流转 = 23,
                投盾 = 24,
                保护 = 27,
                钢铁信念 = 28,
                深奥之灵 = 29,
                神圣领域 = 30,
                沥血剑 = 3538,
                王权剑 = 3539,
                圣光幕帘 = 3540,
                深仁厚泽 = 3541,
                盾阵 = 3542,
                全蚀斩 = 7381,
                干预 = 7382,
                安魂祈祷 = 7383,
                圣灵 = 7384,
                武装戍卫 = 7385,
                铁壁 = 7531,
                挑衅 = 7533,
                雪仇 = 7535,
                退避 = 7537,
                插言 = 7538,
                下踢 = 7540,
                亲疏自行 = 7548,
                日珥斩 = 16457,
                圣环 = 16458,
                悔罪 = 16459,
                赎罪剑 = 16460,
                调停 = 16461,
                圣盾阵 = 25746,
                偿赎剑 = 25747,
                信念之剑 = 25748,
                真理之剑 = 25749,
                英勇之剑 = 25750,
                解除钢铁信念 = 32065,
                祈告剑 = 36918,
                葬送剑 = 36919,
                极致防御 = 36920,
                绝对统治 = 36921,
                荣耀之剑 = 36922;
        }

        public static class Buffs
        {
            public const uint 战逃反应 = 76,
                              安魂祈祷 = 1368,
                              神圣魔法效果提高 = 2673,
                              赎罪剑预备 = 1902,
                              祈告剑预备 = 3827,
                              葬送剑预备 = 3828,
                              沥血剑预备 = 3847,
                              荣耀之剑预备 = 3831,
                              圣盾阵 = 2674,
                              预警 = 74,
                              极致护盾 = 3830,
                              神圣领域 = 82,
                              壁垒 = 77,
                              钢铁信念 = 79,
                              铁壁 = 1191,
                              亲疏自行 = 1209,
                              雪仇 = 1193,
                              生还 = 418,
                              加速度炸弹 = 3802;
        }
    }
    #endregion
    #region EN — English Names (verified via xivapi-v2.xivcdn.com)
    public static class EN
    {
        public static class Skills
        {
            public const uint
                FastBlade = 9,
                RiotBlade = 15,
                ShieldBash = 16,
                FightOrFlight = 20,
                RageOfHalone = 21,
                Bulwark = 22,
                CircleOfScorn = 23,
                ShieldLob = 24,
                Cover = 27,
                IronWill = 28,
                SpiritsWithin = 29,
                HallowedGround = 30,
                GoringBlade = 3538,
                RoyalAuthority = 3539,
                DivineVeil = 3540,
                Clemency = 3541,
                Sheltron = 3542,
                TotalEclipse = 7381,
                Intervention = 7382,
                Requiescat = 7383,
                HolySpirit = 7384,
                PassageOfArms = 7385,
                Rampart = 7531,
                Provoke = 7533,
                Reprisal = 7535,
                Shirk = 7537,
                Interject = 7538,
                LowBlow = 7540,
                ArmsLength = 7548,
                Prominence = 16457,
                HolyCircle = 16458,
                Confiteor = 16459,
                Atonement = 16460,
                Intervene = 16461,
                HolySheltron = 25746,
                Expiacion = 25747,
                BladeOfFaith = 25748,
                BladeOfTruth = 25749,
                BladeOfValor = 25750,
                ReleaseIronWill = 32065,
                Supplication = 36918,
                Sepulchre = 36919,
                Guardian = 36920,
                Imperator = 36921,
                BladeOfHonor = 36922;
        }

        public static class Buffs
        {
            public const uint FightOrFlight = 76,
                              Requiescat = 1368,
                              DivineMight = 2673,
                              AtonementReady = 1902,
                              SupplicationReady = 3827,
                              SepulchreReady = 3828,
                              GoringBladeReady = 3847,
                              BladeOfHonorReady = 3831,
                              HolySheltron = 2674,
                              Sentinel = 74,
                              GuardiansWill = 3830,
                              HallowedGround = 82,
                              Bulwark = 77,
                              IronWill = 79,
                              Rampart = 1191,
                              ArmsLength = 1209,
                              Reprisal = 1193,
                              Transcendent = 418,
                              AccelerationBomb = 3802;
        }
    }
    #endregion

    #region 技能 ID 常量

    public static class Skills
    {
        // ── GCD 连击 ──
        public const uint
            先锋剑 = 9,
            暴乱剑 = 15,
            战女神之怒 = 21,
            投盾 = 24,
            全蚀斩 = 7381,
            日珥斩 = 16457,
            沥血剑 = 3538,
            王权剑 = 3539;

        // ── 魔法 GCD ──
        public const uint
            圣灵 = 7384,
            圣环 = 16458;

        // ── 大宝剑连击 ──
        public const uint
            悔罪 = 16459,
            信念之剑 = 25748,
            真理之剑 = 25749,
            英勇之剑 = 25750;

        // ── 赎罪剑系列 ──
        public const uint
            赎罪剑 = 16460,
            祈告剑 = 36918,
            葬送剑 = 36919,
            偿赎剑 = 25747;

        // ── 爆发技能 ──
        public const uint
            战逃反应 = 20,
            安魂祈祷 = 7383,
            绝对统治 = 36921,
            荣耀之剑 = 36922;

        // ── 能力技 ──
        public const uint
            厄运流转 = 23,
            深奥之灵 = 29,
            调停 = 16461;

        // ── 盾姿 ──
        public const uint
            钢铁信念 = 28,
            解除钢铁信念 = 32065;

        // ── 防御技能 ──
        public const uint
            盾阵 = 3542,
            预警 = 17,
            极致防御 = 36920,
            壁垒 = 22,
            神圣领域 = 30,
            圣光幕帘 = 3540,
            干预 = 7382,
            武装戍卫 = 7385;

        // ── 职能技能 ──
        public const uint
            铁壁 = 7531,
            亲疏自行 = 7548,
            挑衅 = 7533,
            雪仇 = 7535,
            退避 = 7537,
            下踢 = 7540,
            插言 = 7538,
            冲刺 = 3,
            内丹 = 7541,
            浴血 = 7542,
            醒梦 = 7562;
    }

    #endregion

    #region Buff ID 常量

    public static class Buffs
    {
        public const uint
            战逃反应 = 76,
            安魂祈祷 = 1368,
            神圣魔法效果提高 = 2673,
            赎罪剑预备 = 1902,
            祈告剑预备 = 3827,
            葬送剑预备 = 3828,
            沥血剑预备 = 3847,
            荣耀之剑预备 = 3831,
            圣盾阵 = 2674,
            预警 = 74,
            极致护盾 = 3830,
            神圣领域 = 82,
            壁垒 = 77,
            钢铁信念 = 79,
            铁壁 = 1191,
            亲疏自行 = 1209,
            雪仇 = 1193,
            生还 = 418,
            加速器炸弹 = 3802;
    }

    #endregion

    #region 内部 Buff ID (状态属性快捷引用)

    public const uint _战逃反应 = 76;
    public const uint _安魂祈祷 = 1368;
    public const uint _神圣魔法效果提高 = 2673;
    public const uint _赎罪剑预备 = 1902;
    public const uint _祈告剑预备 = 3827;
    public const uint _葬送剑预备 = 3828;
    public const uint _沥血剑预备 = 3847;
    public const uint _荣耀之剑预备 = 3831;
    public const uint _圣盾阵 = 2674;
    public const uint _预警 = 74;
    public const uint _极致护盾 = 3830;
    public const uint _神圣领域 = 82;
    public const uint _壁垒 = 77;
    public const uint _钢铁信念 = 79;

    #endregion

    #region 量谱

    /// <summary>骑士职业量谱</summary>
    public static PLDGauge? Gauge => HelperRuntime.GetGauge<PLDGauge>();

    /// <summary>忠义值 (0-100)</summary>
    public static byte OathGauge => Gauge?.OathGauge ?? 0;

    #endregion

    #region 实例属性 — 状态查询

    public static bool Has战逃反应 => HelperRuntime.HasStatus(_战逃反应);
    public static bool Has安魂祈祷 => HelperRuntime.HasStatus(_安魂祈祷);
    public static bool Has神圣魔法效果提高 => HelperRuntime.HasStatus(_神圣魔法效果提高);
    public static bool Has赎罪剑预备 => HelperRuntime.HasStatus(_赎罪剑预备);
    public static bool Has祈告剑预备 => HelperRuntime.HasStatus(_祈告剑预备);
    public static bool Has葬送剑预备 => HelperRuntime.HasStatus(_葬送剑预备);
    public static bool Has沥血剑预备 => HelperRuntime.HasStatus(_沥血剑预备);
    public static bool Has荣耀之剑预备 => HelperRuntime.HasStatus(_荣耀之剑预备);
    public static bool Has圣盾阵 => HelperRuntime.HasStatus(_圣盾阵);
    public static bool Has预警 => HelperRuntime.HasStatus(_预警);
    public static bool Has极致护盾 => HelperRuntime.HasStatus(_极致护盾);
    public static bool Has神圣领域 => HelperRuntime.HasStatus(_神圣领域);
    public static bool Has壁垒 => HelperRuntime.HasStatus(_壁垒);
    public static bool Has钢铁信念 => HelperRuntime.HasStatus(_钢铁信念);

    /// <summary>是否有任意赎罪剑预备 (赎罪/祈祷/葬送)</summary>
    public static bool Has任意赎罪剑预备 =>
        Has赎罪剑预备 || Has祈告剑预备 || Has葬送剑预备;

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
        if (spellId == Skills.调停) return 2;
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

    public static uint 获取上一个连击技能ID() => HelperRuntime.GetLastComboSpellId();
    public static int 获取GCD剩余时间() => HelperRuntime.GetGCDCooldown();
    public static bool 技能最近是否使用过(uint spellId, int ms) =>
        HelperRuntime.RecentlyUsedSpell(spellId, ms);

    #endregion

    #region 目标与战斗环境

    public static bool 目标是否无敌() =>
        HelperRuntime.IsCurrentTargetInvincible();

    public static int 获取周围敌人数量(float range = 5f) =>
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
