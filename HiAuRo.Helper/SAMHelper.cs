namespace HiAuRo.Helper;

/// <summary>
/// 武士 (SAM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SAMHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                刃风 = 7477,
                阵风 = 7478,
                士风 = 7479,
                雪风 = 7480,
                月光 = 7481,
                花车 = 7482,
                风雅 = 7483,
                满月 = 7484,
                樱花 = 7485,
                燕飞 = 7486,
                纷乱雪月花 = 7487,
                天下五剑 = 7488,
                彼岸花 = 7489,
                必杀剑_震天 = 7490,
                必杀剑_九天 = 7491,
                必杀剑_晓天 = 7492,
                必杀剑_夜天 = 7493,
                叶隐 = 7495,
                必杀剑_红莲 = 7496,
                默想 = 7497,
                心眼 = 7498,
                明镜止水 = 7499,
                内丹 = 7541,
                浴血 = 7542,
                真北 = 7546,
                亲疏自行 = 7548,
                牵制 = 7549,
                扫腿 = 7863,
                居合术 = 7867,
                必杀剑_闪影 = 16481,
                意气冲天 = 16482,
                燕回返 = 16483,
                回返五剑 = 16485,
                回返雪月花 = 16486,
                照破 = 16487,
                风光 = 25780,
                奥义斩浪 = 25781,
                回返斩浪 = 25782,
                天眼通 = 36962,
                晓风 = 36963,
                残心 = 36964,
                天道五剑 = 36965,
                天道雪月花 = 36966,
                天道回返五剑 = 36967,
                天道回返雪月花 = 36968;
        }
        public static class Buffs
        {
            public const uint
                明镜止水 = 1233,
                彼岸花 = 1228,
                风月 = 1298,
                风花 = 1299,
                放浪神之箭 = 1884,
                出血 = 2951,
                鼓励 = 1239;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Hakaze = 7477,
                Jinpu = 7478,
                Shifu = 7479,
                Yukikaze = 7480,
                Gekko = 7481,
                Kasha = 7482,
                Fuga = 7483,
                Mangetsu = 7484,
                Oka = 7485,
                Enpi = 7486,
                MidareSetsugekka = 7487,
                TenkaGoken = 7488,
                Higanbana = 7489,
                HissatsuShinten = 7490,
                HissatsuKyuten = 7491,
                HissatsuGyoten = 7492,
                HissatsuYaten = 7493,
                Hagakure = 7495,
                HissatsuGuren = 7496,
                Meditate = 7497,
                ThirdEye = 7498,
                MeikyoShisui = 7499,
                SecondWind = 7541,
                Bloodbath = 7542,
                TrueNorth = 7546,
                ArmsLength = 7548,
                Feint = 7549,
                LegSweep = 7863,
                Iaijutsu = 7867,
                HissatsuSenei = 16481,
                Ikishoten = 16482,
                TsubameGaeshi = 16483,
                KaeshiGoken = 16485,
                KaeshiSetsugekka = 16486,
                Shoha = 16487,
                Fuko = 25780,
                OgiNamikiri = 25781,
                KaeshiNamikiri = 25782,
                Tengentsu = 36962,
                Gyofu = 36963,
                Zanshin = 36964,
                TendoGoken = 36965,
                TendoSetsugekka = 36966,
                TendoKaeshiGoken = 36967,
                TendoKaeshiSetsugekka = 36968;
        }
        public static class Buffs
        {
            public const uint
                MeikyoShisui = 1233,
                Higanbana = 1228,
                Fugetsu = 1298,
                Fuka = 1299,
                TheArrow = 1884,
                Bleeding = 2951,
                Embolden = 1239;
        }
    }

    #endregion

    public const uint MeikyoShisui = 1233;      // 明镜止水
    public const uint Higanbana = 1228;         // 彼岸花 (DoT)
    public const uint Jinpu = 1298;             // 阵风 (buff)
    public const uint Shifu = 1299;             // 士风 (buff)
    public const uint Ikishoten = 1884;         // 意气冲天
    public const uint OgiNamikiriReady = 2951;  // 奥义斩浪预备
    public const uint TsubameGaeshiReady = 1239; // 燕飞 (回返彼岸花预备)

    /// <summary>武士职业量谱</summary>
    public static SAMGauge? Gauge => HelperRuntime.GetGauge<SAMGauge>();

    /// <summary>剑气值</summary>
    public static int Kenki => Gauge?.Kenki ?? 0;

    /// <summary>冥想层数</summary>
    public static byte MeditationStacks => Gauge?.MeditationStacks ?? 0;

    /// <summary>是否拥有雪之闪</summary>
    public static bool HasSetsu => Gauge?.HasSetsu ?? false;

    /// <summary>是否拥有月之闪</summary>
    public static bool HasGetsu => Gauge?.HasGetsu ?? false;

    /// <summary>是否拥有花之闪</summary>
    public static bool HasKa => Gauge?.HasKa ?? false;

    /// <summary>明镜止水是否激活</summary>
    public static bool HasMeikyoShisui => HelperRuntime.HasStatus(MeikyoShisui);

    /// <summary>彼岸花DoT是否激活</summary>
    public static bool HasHiganbana => HelperRuntime.HasStatus(Higanbana);

    /// <summary>阵风是否激活</summary>
    public static bool HasJinpu => HelperRuntime.HasStatus(Jinpu);

    /// <summary>士风是否激活</summary>
    public static bool HasShifu => HelperRuntime.HasStatus(Shifu);

    /// <summary>意气冲天是否激活</summary>
    public static bool HasIkishoten => HelperRuntime.HasStatus(Ikishoten);

    /// <summary>奥义斩浪预备是否激活</summary>
    public static bool HasOgiNamikiriReady => HelperRuntime.HasStatus(OgiNamikiriReady);

    /// <summary>回返彼岸花预备是否激活</summary>
    public static bool HasTsubameGaeshiReady => HelperRuntime.HasStatus(TsubameGaeshiReady);

    /// <summary>是否拥有全部三闪 (雪/月/花)</summary>
    public static bool HasAllThreeSen => HasSetsu && HasGetsu && HasKa;
}