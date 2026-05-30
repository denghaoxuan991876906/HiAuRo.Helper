
namespace HiAuRo.Helper;

/// <summary>
/// 召唤师 (SMN) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SMNHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                毁灭 = 163,
                毁坏 = 172,
                复生 = 173,
                溃烂爆发 = 181,
                痛苦核爆 = 3578,
                毁荡 = 3579,
                龙神附体 = 3581,
                死星核爆 = 3582,
                毁绝 = 7426,
                龙神召唤 = 7427,
                沉稳咏唱 = 7559,
                昏乱 = 7560,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                医术 = 16230,
                能量吸收 = 16508,
                能量抽取 = 16510,
                迸裂 = 16511,
                宝石兽召唤 = 25798,
                守护之光 = 25799,
                以太蓄能 = 25800,
                灼热之光 = 25801,
                红宝石召唤 = 25802,
                黄宝石召唤 = 25803,
                绿宝石召唤 = 25804,
                火神召唤 = 25805,
                土神召唤 = 25806,
                风神召唤 = 25807,
                宝石耀 = 25883,
                宝石辉 = 25884,
                催眠 = 25880,
                坏死爆发 = 36990,
                灼热之闪 = 36991,
                烈日龙神召唤 = 36992,
                日光普照 = 36997,
                烈日龙神迸发 = 36998,
                众生离绝 = 36999;
        }

        public static class Buffs
        {
            public const uint
                灼热之光 = 2703,
                以太蓄能 = 2582,
                龙神附体 = 2584,
                不死鸟附体 = 2585,
                守护之光 = 2700,
                不死鸟之翼 = 2586;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Ruin = 163,
                RuinII = 172,
                Resurrection = 173,
                Fester = 181,
                Painflare = 3578,
                RuinIII = 3579,
                DreadwyrmTrance = 3581,
                Deathflare = 3582,
                RuinIV = 7426,
                SummonBahamut = 7427,
                Surecast = 7559,
                Addle = 7560,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                Physick = 16230,
                EnergyDrain = 16508,
                EnergySiphon = 16510,
                Outburst = 16511,
                SummonCarbuncle = 25798,
                RadiantAegis = 25799,
                Aethercharge = 25800,
                SearingLight = 25801,
                SummonRuby = 25802,
                SummonTopaz = 25803,
                SummonEmerald = 25804,
                SummonIfrit = 25805,
                SummonTitan = 25806,
                SummonGaruda = 25807,
                Gemshine = 25883,
                PreciousBrilliance = 25884,
                Sleep = 25880,
                Necrotize = 36990,
                SearingFlash = 36991,
                SummonSolarBahamut = 36992,
                LuxSolaris = 36997,
                EnkindleSolarBahamut = 36998,
                Exodus = 36999;
        }

        public static class Buffs
        {
            public const uint
                SearingLight = 2703,
                Aethercharge = 2582,
                DreadwyrmTrance = 2584,
                SummonBahamut = 2585,
                RadiantAegis = 2700,
                EverlastingFlight = 2586;
        }
    }

    #endregion

    #region 技能 / Buff ID

    public const uint SearingLight = 2703;       // 灼热之光
    public const uint Aethercharge = 2582;       // 以太蓄能 (buff)
    public const uint DreadwyrmTrance = 2584;    // 龙神附体 (buff)
    public const uint SummonBahamut = 2585;      // 不死鸟附体 (buff after Bahamut)
    public const uint RadiantAegis = 2700;       // 守护之光 (shield)
    public const uint EverlastingFlight = 2586;  // 不死鸟之翼

    #endregion

    /// <summary>召唤师职业量谱</summary>
    public static SMNGauge? Gauge => HelperRuntime.GetGauge<SMNGauge>();

    /// <summary>是否处于巴哈/不死鸟附体状态</summary>
    public static bool IsInBahamut => Gauge?.SummonTimerRemaining > 0;

    /// <summary>灼热之光是否激活</summary>
    public static bool HasSearingLight => HelperRuntime.HasStatus(SearingLight);

    /// <summary>以太蓄能是否激活</summary>
    public static bool HasAethercharge => HelperRuntime.HasStatus(Aethercharge);

    /// <summary>龙神附体是否激活</summary>
    public static bool HasDreadwyrmTrance => HelperRuntime.HasStatus(DreadwyrmTrance);
}