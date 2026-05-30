
namespace HiAuRo.Helper;

/// <summary>
/// 贤者 (SGE) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SGEHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                注药 = 24283,
                诊断 = 24284,
                心关 = 24285,
                预后 = 24286,
                复苏 = 24287,
                自生 = 24288,
                发炎 = 24289,
                均衡 = 24290,
                均衡诊断 = 24291,
                均衡预后 = 24292,
                均衡注药 = 24293,
                拯救 = 24294,
                神翼 = 24295,
                灵橡清汁 = 24296,
                失衡 = 24297,
                坚角清汁 = 24298,
                寄生清汁 = 24299,
                活化 = 24300,
                消化 = 24301,
                自生II = 24302,
                白牛清汁 = 24303,
                箭毒 = 24304,
                输血 = 24305,
                注药II = 24306,
                发炎II = 24307,
                均衡注药II = 24308,
                根素 = 24309,
                整体论 = 24310,
                泛输血 = 24311,
                注药III = 24312,
                发炎III = 24313,
                均衡注药III = 24314,
                失衡II = 24315,
                箭毒II = 24316,
                混合 = 24317,
                魂灵风息 = 24318,
                沉稳咏唱 = 7559,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                康复 = 7568,
                营救 = 7571,
                沉静 = 16560,
                均衡失衡 = 37032,
                心神风息 = 37033,
                均衡预后II = 37034,
                智慧之爱 = 37035,
                幸福 = 37036;
        }

        public static class Buffs
        {
            public const uint
                均衡 = 2429,
                心关 = 2428,
                自生 = 2427,
                活化 = 2430,
                泛输血 = 2432,
                整体论 = 2433,
                魂灵风息 = 2434,
                均衡注药 = 2614;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Dosis = 24283,
                Diagnosis = 24284,
                Kardia = 24285,
                Prognosis = 24286,
                Egeiro = 24287,
                Physis = 24288,
                Phlegma = 24289,
                Eukrasia = 24290,
                EukrasianDiagnosis = 24291,
                EukrasianPrognosis = 24292,
                EukrasianDosis = 24293,
                Soteria = 24294,
                Icarus = 24295,
                Druochole = 24296,
                Dyskrasia = 24297,
                Kerachole = 24298,
                Ixochole = 24299,
                Zoe = 24300,
                Pepsis = 24301,
                PhysisII = 24302,
                Taurochole = 24303,
                Toxikon = 24304,
                Haima = 24305,
                DosisII = 24306,
                PhlegmaII = 24307,
                EukrasianDosisII = 24308,
                Rhizomata = 24309,
                Holos = 24310,
                Panhaima = 24311,
                DosisIII = 24312,
                PhlegmaIII = 24313,
                EukrasianDosisIII = 24314,
                DyskrasiaII = 24315,
                ToxikonII = 24316,
                Krasis = 24317,
                Pneuma = 24318,
                Surecast = 7559,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                Esuna = 7568,
                Rescue = 7571,
                Repose = 16560,
                EukrasianDyskrasia = 37032,
                Psyche = 37033,
                EukrasianPrognosisII = 37034,
                Philosophia = 37035,
                Eudaimonia = 37036;
        }

        public static class Buffs
        {
            public const uint
                Eukrasia = 2429,
                Kardia = 2428,
                Physis = 2427,
                Krasis = 2430,
                Haima = 2432,
                Panhaima = 2433,
                Pneuma = 2434,
                EukrasianDosis = 2614;
        }
    }

    #endregion

    #region 技能 / Buff / DoT ID

    public const uint Eukrasia = 2429;           // 均衡
    public const uint Kardia = 2428;             // 心关 (buff on target)
    public const uint Physis = 2427;             // 自生 (buff)
    public const uint Krasis = 2430;             // 活化 (buff on target)
    public const uint Haima = 2432;              // 泛输血
    public const uint Panhaima = 2433;           // 整体论
    public const uint Pneuma = 2434;             // 魂灵风息
    public const uint EukrasianDosis = 2614;     // 均衡注药 (DoT)

    #endregion

    /// <summary>贤者职业量谱</summary>
    public static SGEGauge? Gauge => HelperRuntime.GetGauge<SGEGauge>();

    /// <summary>蛇刺数量</summary>
    public static byte AdderstingCount => Gauge?.Addersting ?? 0;

    /// <summary>是否拥有均衡状态</summary>
    public static bool HasEukrasia => Gauge?.Eukrasia ?? false;

    /// <summary>均衡状态是否激活</summary>
    public static bool HasEukrasiaStatus =>
        HelperRuntime.HasStatus(Eukrasia);

    /// <summary>泛输血是否激活</summary>
    public static bool HasHaima =>
        HelperRuntime.HasStatus(Haima);

    /// <summary>整体论是否激活</summary>
    public static bool HasPanhaima =>
        HelperRuntime.HasStatus(Panhaima);

    /// <summary>自生是否激活</summary>
    public static bool HasPhysis =>
        HelperRuntime.HasStatus(Physis);
}