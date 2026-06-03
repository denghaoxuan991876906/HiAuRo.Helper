namespace HiAuRo.Helper;

/// <summary>
/// 蝰蛇剑士 (VPR) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class VPRHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                咬噬尖齿 = 34606,
                穿裂尖齿 = 34607,
                猛袭利齿 = 34608,
                疾速利齿 = 34609,
                侧击獠齿 = 34610,
                侧裂獠齿 = 34611,
                背击獠齿 = 34612,
                背裂獠齿 = 34613,
                咬噬尖牙 = 34614,
                穿裂尖牙 = 34615,
                猛袭利牙 = 34616,
                疾速利牙 = 34617,
                乱击獠牙 = 34618,
                乱裂獠牙 = 34619,
                强碎灵蛇 = 34620,
                猛袭盘蛇 = 34621,
                疾速盘蛇 = 34622,
                强碎灵蝰 = 34623,
                猛袭盘蝰 = 34624,
                疾速盘蝰 = 34625,
                祖灵降临 = 34626,
                祖灵之牙一式 = 34627,
                祖灵之牙二式 = 34628,
                祖灵之牙三式 = 34629,
                祖灵之牙四式 = 34630,
                祖灵大蛇牙 = 34631,
                飞蛇之牙 = 34632,
                飞蛇之尾 = 34633,
                蛇尾击 = 34634,
                蛇尾闪 = 34635,
                双牙连击 = 34636,
                双牙乱击 = 34637,
                双牙连闪 = 34638,
                双牙乱闪 = 34639,
                祖灵之蛇一式 = 34640,
                祖灵之蛇二式 = 34641,
                祖灵之蛇三式 = 34642,
                祖灵之蛇四式 = 34643,
                飞蛇连尾击 = 34644,
                飞蛇乱尾击 = 34645,
                蛇行 = 34646,
                蛇灵气 = 34647,
                蛇尾术 = 35920,
                双牙连术 = 35921,
                双牙乱术 = 35922,
                内丹 = 7541,
                浴血 = 7542,
                真北 = 7546,
                亲疏自行 = 7548,
                牵制 = 7549,
                扫腿 = 7863;
        }
        public static class Buffs
        {
            public const uint
                真北 = 1250,
                侧击之毒 = 3645,
                侧裂之毒 = 3646,
                背击之毒 = 3647,
                背裂之毒 = 3648,
                阴惨猎毒 = 3649,
                阴惨肤毒 = 3650,
                猎毒 = 3657,
                疾速肤毒 = 3658,
                凶猎毒 = 3659,
                凶肤毒 = 3660,
                双牙连击预备 = 3665,
                双牙乱击预备 = 3666,
                夺命之毒 = 3667,
                猎人直觉 = 3668,
                疾速之牙 = 3669,
                祖灵附体 = 3670,
                祖灵预备 = 3671,
                咬噬强化 = 3672,
                穿裂强化 = 3772;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                SteelFangs = 34606,
                ReavingFangs = 34607,
                HuntersSting = 34608,
                SwiftskinsSting = 34609,
                FlankstingStrike = 34610,
                FlanksbaneFang = 34611,
                HindstingStrike = 34612,
                HindsbaneFang = 34613,
                SteelMaw = 34614,
                ReavingMaw = 34615,
                HuntersBite = 34616,
                SwiftskinsBite = 34617,
                JaggedMaw = 34618,
                BloodiedMaw = 34619,
                Vicewinder = 34620,
                HuntersCoil = 34621,
                SwiftskinsCoil = 34622,
                Vicepit = 34623,
                HuntersDen = 34624,
                SwiftskinsDen = 34625,
                Reawaken = 34626,
                FirstGeneration = 34627,
                SecondGeneration = 34628,
                ThirdGeneration = 34629,
                FourthGeneration = 34630,
                Ouroboros = 34631,
                WrithingSnap = 34632,
                UncoiledFury = 34633,
                DeathRattle = 34634,
                LastLash = 34635,
                TwinfangBite = 34636,
                TwinbloodBite = 34637,
                TwinfangThresh = 34638,
                TwinbloodThresh = 34639,
                FirstLegacy = 34640,
                SecondLegacy = 34641,
                ThirdLegacy = 34642,
                FourthLegacy = 34643,
                UncoiledTwinfang = 34644,
                UncoiledTwinblood = 34645,
                Slither = 34646,
                SerpentsIre = 34647,
                SerpentsTail = 35920,
                Twinfang = 35921,
                Twinblood = 35922,
                SecondWind = 7541,
                Bloodbath = 7542,
                TrueNorth = 7546,
                ArmsLength = 7548,
                Feint = 7549,
                LegSweep = 7863;
        }
        public static class Buffs
        {
            public const uint
                TrueNorth = 1250,
                FlankstungVenom = 3645,
                FlanksbaneVenom = 3646,
                HindstungVenom = 3647,
                HindsbaneVenom = 3648,
                GrimhuntersVenom = 3649,
                GrimskinsVenom = 3650,
                HuntersVenom = 3657,
                SwiftskinsVenom = 3658,
                FellhuntersVenom = 3659,
                FellskinsVenom = 3660,
                PoisedForTwinfang = 3665,
                PoisedForTwinblood = 3666,
                NoxiousGnash = 3667,
                HuntersInstinct = 3668,
                Swiftscaled = 3669,
                Reawakened = 3670,
                ReadyToReawaken = 3671,
                HonedSteel = 3672,
                HonedReavers = 3772;
        }
    }

    #endregion

    public const uint HuntersInstinct = 3668;   // 猎人直觉 (增伤buff)
    public const uint Swiftscaled = 3669;       // 疾速之牙 (加速buff)
    public const uint FlankstingReady = 3645;   // 侧击强化毒
    public const uint FlanksbaneReady = 3646;   // 侧裂强化毒
    public const uint Reawakened = 3670;        // 祖灵附体
    public const uint TrueNorth = 1250;         // 真北
    public const uint FlankstungVenom = 3645;   // 侧击之毒
    public const uint FlanksbaneVenom = 3646;   // 侧裂之毒
    public const uint HindstungVenom = 3647;    // 背击之毒
    public const uint HindsbaneVenom = 3648;    // 背裂之毒
    public const uint GrimhuntersVenom = 3649;  // 阴惨猎毒
    public const uint GrimskinsVenom = 3650;    // 阴惨肤毒
    public const uint HuntersVenom = 3657;      // 猎毒
    public const uint SwiftskinsVenom = 3658;   // 疾速肤毒
    public const uint FellhuntersVenom = 3659;  // 凶猎毒
    public const uint FellskinsVenom = 3660;    // 凶肤毒
    public const uint PoisedForTwinfang = 3665;  // 双牙连击预备
    public const uint PoisedForTwinblood = 3666; // 双牙乱击预备
    public const uint NoxiousGnash = 3667;      // 夺命之毒
    public const uint ReadyToReawaken = 3671;   // 祖灵预备
    public const uint HonedSteel = 3672;        // 咬噬强化
    public const uint HonedReavers = 3772;      // 穿裂强化

    /// <summary>蝰蛇剑士职业量谱</summary>
    public static VPRGauge? Gauge => HelperRuntime.GetGauge<VPRGauge>();

    /// <summary>猎人直觉是否激活</summary>
    public static bool HasHuntersInstinct => HelperRuntime.HasStatus(HuntersInstinct);

    /// <summary>疾速之牙是否激活</summary>
    public static bool HasSwiftscaled => HelperRuntime.HasStatus(Swiftscaled);

    /// <summary>祖灵附体是否激活</summary>
    public static bool HasReawakened => HelperRuntime.HasStatus(Reawakened);

    /// <summary>侧击强化毒是否激活</summary>
    public static bool HasFlankstingReady => HelperRuntime.HasStatus(FlankstingReady);

    /// <summary>侧裂强化毒是否激活</summary>
    public static bool HasFlanksbaneReady => HelperRuntime.HasStatus(FlanksbaneReady);
}
