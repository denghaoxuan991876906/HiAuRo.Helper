
namespace HiAuRo.Helper;

/// <summary>
/// 赤魔法师 (RDM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class RDMHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                摇荡 = 7503,
                回刺 = 7504,
                赤闪雷 = 7505,
                短兵相接 = 7506,
                赤疾风 = 7507,
                散碎 = 7509,
                赤火炎 = 7510,
                赤飞石 = 7511,
                交击斩 = 7512,
                划圆斩 = 7513,
                赤治疗 = 7514,
                移转 = 7515,
                连攻 = 7516,
                飞刺 = 7517,
                促进 = 7518,
                六分反击 = 7519,
                鼓励 = 7520,
                魔元化 = 7521,
                赤复活 = 7523,
                震荡 = 7524,
                赤核爆 = 7525,
                赤神圣 = 7526,
                魔回刺 = 7527,
                魔交击斩 = 7528,
                魔连攻 = 7529,
                魔划圆斩_一段 = 7530,
                沉稳咏唱 = 7559,
                昏乱 = 7560,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                赤震雷 = 16524,
                赤烈风 = 16525,
                冲击 = 16526,
                交剑 = 16527,
                魔续斩 = 16528,
                续斩 = 16529,
                焦热 = 16530,
                赤暴雷 = 25855,
                赤暴风 = 25856,
                抗死 = 25857,
                决断 = 25858,
                催眠 = 25880,
                魔划圆斩_二段 = 37002,
                魔划圆斩_三段 = 37003,
                激荡 = 37004,
                荆棘环绕 = 37005,
                显贵冲击 = 37006,
                光芒四射 = 37007;
        }

        public static class Buffs
        {
            public const uint
                鼓励 = 2282,
                魔元化 = 1971,
                促进 = 1238,
                赤飞石预备 = 1235,
                赤火炎预备 = 1234,
                引雷 = 2574;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Jolt = 7503,
                Riposte = 7504,
                Verthunder = 7505,
                CorpsACorps = 7506,
                Veraero = 7507,
                Scatter = 7509,
                Verfire = 7510,
                Verstone = 7511,
                Zwerchhau = 7512,
                Moulinet = 7513,
                Vercure = 7514,
                Displacement = 7515,
                Redoublement = 7516,
                Fleche = 7517,
                Acceleration = 7518,
                ContreSixte = 7519,
                Embolden = 7520,
                Manafication = 7521,
                Verraise = 7523,
                JoltII = 7524,
                Verflare = 7525,
                Verholy = 7526,
                EnchantedRiposte = 7527,
                EnchantedZwerchhau = 7528,
                EnchantedRedoublement = 7529,
                EnchantedMoulinet = 7530,
                Surecast = 7559,
                Addle = 7560,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                VerthunderII = 16524,
                VeraeroII = 16525,
                Impact = 16526,
                Engagement = 16527,
                EnchantedReprise = 16528,
                Reprise = 16529,
                Scorch = 16530,
                VerthunderIII = 25855,
                VeraeroIII = 25856,
                MagickBarrier = 25857,
                Resolution = 25858,
                Sleep = 25880,
                EnchantedMoulinetDeux = 37002,
                EnchantedMoulinetTrois = 37003,
                JoltIII = 37004,
                ViceOfThorns = 37005,
                GrandImpact = 37006,
                Prefulgence = 37007;
        }

        public static class Buffs
        {
            public const uint
                Embolden = 2282,
                Manafication = 1971,
                Acceleration = 1238,
                VerstoneReady = 1235,
                VerfireReady = 1234,
                LightningRod = 2574;
        }
    }

    #endregion

    #region 技能 / Buff ID

    public const uint Embolden = 2282;        // 鼓励
    public const uint Manafication = 1971;    // 倍增
    public const uint Acceleration = 1238;    // 促进
    public const uint VerstoneReady = 1235;   // 赤飞石预备
    public const uint VerfireReady = 1234;    // 赤火炎预备
    public const uint MagickBarrier = 2574;   // 抗死

    #endregion

    /// <summary>赤魔法师职业量谱</summary>
    public static RDMGauge? Gauge => HelperRuntime.GetGauge<RDMGauge>();

    /// <summary>白魔元 (0-100)</summary>
    public static byte WhiteMana => Gauge?.WhiteMana ?? 0;

    /// <summary>黑魔元 (0-100)</summary>
    public static byte BlackMana => Gauge?.BlackMana ?? 0;

    /// <summary>魔元集层数</summary>
    public static byte ManaStacks => Gauge?.ManaStacks ?? 0;

    /// <summary>是否可以发动近战连击 (黑白魔元均 >= 50)</summary>
    public static bool CanMeleeCombo => WhiteMana >= 50 && BlackMana >= 50;

    /// <summary>鼓励是否激活</summary>
    public static bool HasEmbolden => HelperRuntime.HasStatus(Embolden);

    /// <summary>倍增是否激活</summary>
    public static bool HasManafication => HelperRuntime.HasStatus(Manafication);

    /// <summary>促进是否激活</summary>
    public static bool HasAcceleration => HelperRuntime.HasStatus(Acceleration);

    /// <summary>赤飞石预备是否激活</summary>
    public static bool HasVerstoneReady => HelperRuntime.HasStatus(VerstoneReady);

    /// <summary>赤火炎预备是否激活</summary>
    public static bool HasVerfireReady => HelperRuntime.HasStatus(VerfireReady);
}