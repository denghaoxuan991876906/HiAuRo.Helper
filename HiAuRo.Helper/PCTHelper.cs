
namespace HiAuRo.Helper;

/// <summary>
/// 绘灵法师 (PCT) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class PCTHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                火炎之红 = 34650,
                疾风之绿 = 34651,
                流水之蓝 = 34652,
                冰结之蓝青 = 34653,
                飞石之纯黄 = 34654,
                闪雷之品红 = 34655,
                烈炎之红 = 34656,
                烈风之绿 = 34657,
                激水之蓝 = 34658,
                冰冻之蓝青 = 34659,
                坚石之纯黄 = 34660,
                震雷之品红 = 34661,
                神圣之白 = 34662,
                沉稳咏唱 = 7559,
                昏乱 = 7560,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                催眠 = 25880;
        }

        public static class Buffs
        {
            public const uint
                星空构想 = 3466,
                减色混合 = 3467,
                重锤构想 = 3468,
                生物构想 = 3469,
                活现构想 = 3470,
                星光预备 = 3471,
                彩虹点滴预备 = 3472;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                FireInRed = 34650,
                AeroInGreen = 34651,
                WaterInBlue = 34652,
                BlizzardInCyan = 34653,
                StoneInYellow = 34654,
                ThunderInMagenta = 34655,
                FireIIInRed = 34656,
                AeroIIInGreen = 34657,
                WaterIIInBlue = 34658,
                BlizzardIIInCyan = 34659,
                StoneIIInYellow = 34660,
                ThunderIIInMagenta = 34661,
                HolyInWhite = 34662,
                Surecast = 7559,
                Addle = 7560,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                Sleep = 25880;
        }

        public static class Buffs
        {
            public const uint
                StarryMuse = 3466,
                SubtractivePalette = 3467,
                HammerMotif = 3468,
                CreatureMotif = 3469,
                LivingMuse = 3470,
                StarburstReady = 3471,
                RainbowDripReady = 3472;
        }
    }

    #endregion

    #region 技能 / Buff ID

    public const uint StarryMuse = 3466;        // 星空构想
    public const uint SubtractivePalette = 3467; // 减色混合 (buff)
    public const uint HammerMotif = 3468;       // 重锤构想
    public const uint CreatureMotif = 3469;     // 生物构想
    public const uint LivingMuse = 3470;        // 活现构想
    public const uint StarburstReady = 3471;    // 星光预备
    public const uint RainbowDripReady = 3472;  // 彩虹点滴预备

    #endregion

    /// <summary>绘灵法师职业量谱</summary>
    public static PCTGauge? Gauge => HelperRuntime.GetGauge<PCTGauge>();

    /// <summary>画布是否可用</summary>
    public static bool IsCanvasReady => (Gauge?.PalleteGauge ?? 0) > 0;

    /// <summary>星空构想是否激活</summary>
    public static bool HasStarryMuse => HelperRuntime.HasStatus(StarryMuse);

    /// <summary>减色混合是否激活</summary>
    public static bool HasSubtractivePalette => HelperRuntime.HasStatus(SubtractivePalette);
}