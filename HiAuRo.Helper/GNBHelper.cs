
namespace HiAuRo.Helper;

/// <summary>
/// 绝枪战士 (GNB) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class GNBHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)
    public static class CN
    {
        public static class Skills
        {
            public const uint
                利刃斩 = 16137,
                无情 = 16138,
                残暴弹 = 16139,
                伪装 = 16140,
                恶魔切 = 16141,
                王室亲卫 = 16142,
                闪雷弹 = 16143,
                危险领域 = 16144,
                迅连斩 = 16145,
                烈牙 = 16146,
                猛兽爪 = 16147,
                星云 = 16148,
                恶魔杀 = 16149,
                凶禽爪 = 16150,
                极光 = 16151,
                超火流星 = 16152,
                音速破 = 16153,
                续剑 = 16155,
                撕喉 = 16156,
                裂膛 = 16157,
                穿目 = 16158,
                弓形冲波 = 16159,
                光之心 = 16160,
                石之心 = 16161,
                爆发击 = 16162,
                命运之环 = 16163,
                血壤 = 16164,
                爆破领域 = 16165,
                铁壁 = 7531,
                挑衅 = 7533,
                雪仇 = 7535,
                退避 = 7537,
                插言 = 7538,
                下踢 = 7540,
                亲疏自行 = 7548,
                刚玉之心 = 25758,
                超高速 = 25759,
                倍攻 = 25760,
                解除王室亲卫 = 32068,
                弹道 = 36934,
                大星云 = 36935,
                命运之印 = 36936,
                崛起之心 = 36937,
                支配之心 = 36938,
                终结之心 = 36939;
        }

        public static class Buffs
        {
            public const uint 无情 = 1831,
                              撕喉预备 = 1842,
                              裂膛预备 = 1843,
                              穿目预备 = 1844,
                              刚玉之清 = 2684,
                              超火流星 = 1836,
                              残暴弹 = 1898,
                              命运之印预备 = 3839,
                              心有灵狮 = 3840,
                              超高速 = 2686,
                              王室亲卫 = 1833,
                              音速破预备 = 3886,
                              刚玉之心 = 2683,
                              刚玉之净 = 2685,
                              石之心 = 1840,
                              星云 = 1834,
                              大星云 = 3838,
                              伪装 = 1832,
                              极光 = 1835,
                              光之心 = 1839,
                              血壤 = 5051;
        }
    }
    #endregion
    #region EN — English Names (verified via xivapi-v2.xivcdn.com)
    public static class EN
    {
        public static class Skills
        {
            public const uint
                KeenEdge = 16137,
                NoMercy = 16138,
                BrutalShell = 16139,
                Camouflage = 16140,
                DemonSlice = 16141,
                RoyalGuard = 16142,
                LightningShot = 16143,
                DangerZone = 16144,
                SolidBarrel = 16145,
                GnashingFang = 16146,
                SavageClaw = 16147,
                Nebula = 16148,
                DemonSlaughter = 16149,
                WickedTalon = 16150,
                Aurora = 16151,
                Superbolide = 16152,
                SonicBreak = 16153,
                Continuation = 16155,
                JugularRip = 16156,
                AbdomenTear = 16157,
                EyeGouge = 16158,
                BowShock = 16159,
                HeartOfLight = 16160,
                HeartOfStone = 16161,
                BurstStrike = 16162,
                FatedCircle = 16163,
                Bloodfest = 16164,
                BlastingZone = 16165,
                Rampart = 7531,
                Provoke = 7533,
                Reprisal = 7535,
                Shirk = 7537,
                Interject = 7538,
                LowBlow = 7540,
                ArmsLength = 7548,
                HeartOfCorundum = 25758,
                Hypervelocity = 25759,
                DoubleDown = 25760,
                ReleaseRoyalGuard = 32068,
                Trajectory = 36934,
                GreatNebula = 36935,
                FatedBrand = 36936,
                ReignOfBeasts = 36937,
                NobleBlood = 36938,
                LionHeart = 36939;
        }

        public static class Buffs
        {
            public const uint NoMercy = 1831,
                              ReadyToRip = 1842,
                              ReadyToTear = 1843,
                              ReadyToGouge = 1844,
                              ClarityOfCorundum = 2684,
                              Superbolide = 1836,
                              BrutalShell = 1898,
                              ReadyToRaze = 3839,
                              ReadyToReign = 3840,
                              ReadyToBlast = 2686,
                              RoyalGuard = 1833,
                              ReadyToBreak = 3886,
                              HeartOfCorundum = 2683,
                              CatharsisOfCorundum = 2685,
                              HeartOfStone = 1840,
                              Nebula = 1834,
                              GreatNebula = 3838,
                              Camouflage = 1832,
                              Aurora = 1835,
                              HeartOfLight = 1839,
                              Bloodfest = 5051;
        }
    }
    #endregion

    #region 技能 / Buff ID

    public const uint 无情           = 1831;   // 无情
    public const uint 撕喉预备          = 1842;   // 续剑1
    public const uint 裂膛预备         = 1843;   //续剑2
    public const uint 穿目预备        = 1844;   // 续剑3
    public const uint 刚玉之清     = 2684;   // 4s的15减伤
    public const uint 超火流星         = 1836;   // 无敌
    public const uint 残暴弹         = 1898;   // 残暴弹 (护盾buff)
    public const uint 命运之印预备 = 3839;//Ready to Raze 命运之环续剑
    public const uint 心有灵狮 = 3840; //Ready to Reign
    public const uint 超高速预备 = 2686;//续剑爆发击
    public const uint 王室亲卫 = 1833;//Royal Guard
    public const uint 音速破预备 = 3886U;
    public const uint 刚玉之心 = 2683; //8s的15减伤
    public const uint 刚玉之净 = 2685; //回血
    public const uint 石之心 = 1840;
    public const uint 星云 = 1834;
    public const uint 大星云 = 3838;//Great Nebula
    public const uint 伪装 = 1832;
    public const uint 极光 = 1835;
    public const uint 光之心 = 1839; //
    #endregion

    /// <summary>绝枪战士职业量谱</summary>
    public static GNBGauge? Gauge => HelperRuntime.GetGauge<GNBGauge>();

    /// <summary>晶壤数量 (0-6)</summary>
    public static byte CartridgeCount => Gauge?.Ammo ?? 0;

    /// <summary>是否有晶壤</summary>
    public static bool HasCartridge => CartridgeCount > 0;

    /// <summary>晶壤是否已满 (3层以上)</summary>
    public static bool HasMaxCartridges => CartridgeCount >= 3;

    /// <summary>无情是否激活</summary>
    public static bool Has无情 =>
        HelperRuntime.HasStatus(无情);

    /// <summary>王室亲卫是否激活</summary>
    public static bool Has王室亲卫 =>
        HelperRuntime.HasStatus(王室亲卫);

    /// <summary>残暴弹 (护盾buff) 是否激活</summary>
    public static bool Has残暴弹 =>
        HelperRuntime.HasStatus(残暴弹);

    /// <summary>撕喉预备是否激活</summary>
    public static bool Has撕喉预备 =>
        HelperRuntime.HasStatus(撕喉预备);

    /// <summary>裂膛预备是否激活</summary>
    public static bool Has裂膛预备 =>
        HelperRuntime.HasStatus(裂膛预备);

    /// <summary>穿目预备是否激活</summary>
    public static bool Has穿目预备 =>
        HelperRuntime.HasStatus(穿目预备);

    #region 技能
    public const uint 利刃斩 = 16137;
    public const uint 残暴弹技能 = 16139;
    public const uint 讯连斩 = 16145;
    public const uint 爆发击 = 16162;
    public const uint 恶魔切 = 16141;
    public const uint 恶魔杀 = 16149;
    public const uint 命运之环 = 16163;
    public const uint 命运之印 = 36936;
    public const uint 闪雷弹 = 16143;
    public const uint 音速破 = 16153;
    public const uint 烈牙 = 16146;
    public const uint 猛兽爪 = 16147;
    public const uint 凶禽爪 = 16150;
    public const uint 倍功 = 25760;
    public const uint 崛起之心 = 36937;
    public const uint 支配之心 = 36938;
    public const uint 终结之心 = 36939;
    public const uint 无情技能 = 16138;
    public const uint 危险领域 = 16144;
    public const uint 弓形冲波 = 16159;
    public const uint 血壤 = 16164;
    public const uint 爆破领域 = 16165;
    public const uint 铁壁 = 7531;
    public const uint 雪仇 = 7535;
    public const uint 挑衅 = 7533;
    public const uint 退避 = 7537;
    public const uint 亲疏自行 = 7548;
    public const uint 撕喉 = 16148;
    public const uint 裂膛 = 16151;
    public const uint 穿目 = 16152;
    public const uint 超高速 = 25761;
    #endregion

    #region 辅助方法
        public static bool 续剑激活 => HelperRuntime.HasStatus(1842) || HelperRuntime.HasStatus(1843) || HelperRuntime.HasStatus(1844) || HelperRuntime.HasStatus(3839) || HelperRuntime.HasStatus(2686);
        public static bool 血壤激活 => HelperRuntime.HasStatus(5051);
        public static bool 群怪模式 => HelperRuntime.GetNearbyEnemyCount(5) >= 3;
    #endregion
}
