
namespace HiAuRo.Helper;

/// <summary>
/// 暗黑骑士 (DRK) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class DRKHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                重斩 = 3617,
                释放 = 3621,
                吸收斩 = 3623,
                伤残 = 3624,
                嗜血 = 3625,
                深恶痛绝 = 3629,
                噬魂斩 = 3632,
                弃明投暗 = 3634,
                暗影墙 = 3636,
                行尸走肉 = 3638,
                腐秽大地 = 3639,
                吸血深渊 = 3641,
                精雕怒斩 = 3643,
                血乱 = 7390,
                寂灭 = 7391,
                血溅 = 7392,
                至黑之夜 = 7393,
                铁壁 = 7531,
                挑衅 = 7533,
                雪仇 = 7535,
                退避 = 7537,
                插言 = 7538,
                下踢 = 7540,
                亲疏自行 = 7548,
                暗黑波动 = 16466,
                暗黑锋 = 16467,
                刚魂 = 16468,
                暗影波动 = 16469,
                暗影锋 = 16470,
                暗黑布道 = 16471,
                掠影示现 = 16472,
                献奉 = 25754,
                腐秽黑暗 = 25755,
                暗影使者 = 25757,
                解除深恶痛绝 = 32067,
                暗影步 = 36926,
                暗影卫 = 36927,
                血红乱 = 36928,
                报应 = 36929,
                戮山 = 36930,
                刺穿 = 36931,
                掠影的蔑视 = 36932;
        }

        public static class Buffs
        {
            public const uint
                血乱 = 3836,
                嗜血 = 742,
                暗黑 = 751,
                暗影墙 = 747,
                行尸走肉 = 810,
                献奉 = 2578,
                腐秽大地 = 749,
                掠影的蔑视预备 = 3837;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                HardSlash = 3617,
                Unleash = 3621,
                SyphonStrike = 3623,
                Unmend = 3624,
                BloodWeapon = 3625,
                Grit = 3629,
                Souleater = 3632,
                DarkMind = 3634,
                ShadowWall = 3636,
                LivingDead = 3638,
                SaltedEarth = 3639,
                AbyssalDrain = 3641,
                CarveAndSpit = 3643,
                Delirium = 7390,
                Quietus = 7391,
                Bloodspiller = 7392,
                TheBlackestNight = 7393,
                Rampart = 7531,
                Provoke = 7533,
                Reprisal = 7535,
                Shirk = 7537,
                Interject = 7538,
                LowBlow = 7540,
                ArmsLength = 7548,
                FloodOfDarkness = 16466,
                EdgeOfDarkness = 16467,
                StalwartSoul = 16468,
                FloodOfShadow = 16469,
                EdgeOfShadow = 16470,
                DarkMissionary = 16471,
                LivingShadow = 16472,
                Oblation = 25754,
                SaltAndDarkness = 25755,
                Shadowbringer = 25757,
                ReleaseGrit = 32067,
                Shadowstride = 36926,
                ShadowedVigil = 36927,
                ScarletDelirium = 36928,
                Comeuppance = 36929,
                Torcleaver = 36930,
                Impalement = 36931,
                Disesteem = 36932;
        }

        public static class Buffs
        {
            public const uint
                Delirium = 3836,
                BloodWeapon = 742,
                Darkside = 751,
                ShadowWall = 747,
                LivingDead = 810,
                Oblation = 2578,
                SaltedEarth = 749,
                Scorn = 3837;
        }
    }

    #endregion

    #region 技能 / Buff ID

    public const uint Delirium            = 3836;   // 血乱 (fixed)
    public const uint BloodWeapon         = 742;    // 嗜血
    public const uint Darkside            = 751;    // 暗黑
    public const uint DarkMissionary      = 2686;   // 暗黑布道 (fixed from 747)
    public const uint ShadowWall          = 747;    // 暗影墙
    public const uint LivingDead          = 810;    // 行尸走肉
    public const uint Oblation            = 2578;   // 献祭

    #endregion

    #region 技能

    public const uint 重斩 = 3617;
    public const uint 吸收斩 = 3623;
    public const uint 噬魂斩 = 3632;
    public const uint 释放 = 3621;
    public const uint 刚魂 = 16468;
    public const uint 血溅 = 7392;
    public const uint 寂灭 = 7391;
    public const uint 暗影锋 = 16470;
    public const uint 暗黑波动 = 16466;
    public const uint 伤残 = 3624;
    public const uint 血乱 = 7390;
    public const uint 嗜血 = 3625;
    public const uint 腐秽大地 = 3639;
    public const uint 腐秽黑暗 = 25755;
    public const uint 精雕怒斩 = 36927;
    public const uint 飞斧 = 3641;
    public const uint 掠影示现 = 16472;
    public const uint 暗影使者 = 25757;
    public const uint 暗黑布道 = 16471;
    public const uint 暗影墙 = 3636;
    public const uint 行尸走肉 = 3638;
    public const uint 至黑之夜 = 7393;
    public const uint 献奉 = 25754;
    public const uint 铁壁 = 7531;
    public const uint 雪仇 = 7535;
    public const uint 挑衅 = 7533;
    public const uint 退避 = 7537;
    public const uint 亲疏自行 = 7548;
    public const uint 下踢 = 7540;
    public const uint 蔑视 = 36932;
    public const uint 血乱裂 = 36928;
    public const uint 血乱斩 = 36929;
    public const uint 血乱灭 = 36930;

    #endregion

    #region 辅助方法

    public static bool 血乱激活 => HelperRuntime.HasStatus(3836);
    public static bool 嗜血激活 => HelperRuntime.HasStatus(BloodWeapon);
    public static bool 暗黑激活 => HasDarkside;
    public static bool 腐秽大地激活 => HelperRuntime.HasStatus(749);
    public static bool 蔑视激活 => HelperRuntime.HasStatus(3837);
    public static bool 群怪模式 => HelperRuntime.GetNearbyEnemyCount(5) >= 3;

    #endregion

    /// <summary>暗黑骑士职业量谱</summary>
    public static DRKGauge? Gauge => HelperRuntime.GetGauge<DRKGauge>();

    /// <summary>暗血值 (0-100)</summary>
    public static byte BloodGauge => Gauge?.Blood ?? 0;

    /// <summary>血乱是否激活</summary>
    public static bool HasDelirium =>
        HelperRuntime.HasStatus(Delirium);

    /// <summary>嗜血是否激活</summary>
    public static bool HasBloodWeapon =>
        HelperRuntime.HasStatus(BloodWeapon);

    /// <summary>暗黑是否激活</summary>
    public static bool HasDarkside =>
        HelperRuntime.HasStatus(Darkside);
}