
namespace HiAuRo.Helper;

/// <summary>
/// 白魔法师 (WHM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class WHMHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                飞石 = 119,
                治疗 = 120,
                疾风 = 121,
                医治 = 124,
                复活 = 125,
                坚石 = 127,
                愈疗 = 131,
                烈风 = 132,
                医济 = 133,
                救疗 = 135,
                神速咏唱 = 136,
                再生 = 137,
                神圣 = 139,
                天赐祝福 = 140,
                垒石 = 3568,
                庇护所 = 3569,
                神名 = 3570,
                法令 = 3571,
                无中生有 = 7430,
                崩石 = 7431,
                神祝祷 = 7432,
                全大赦 = 7433,
                沉稳咏唱 = 7559,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                康复 = 7568,
                营救 = 7571,
                安慰之心 = 16531,
                天辉 = 16532,
                闪耀 = 16533,
                狂喜之心 = 16534,
                苦难之心 = 16535,
                节制 = 16536,
                沉静 = 16560,
                闪灼 = 25859,
                豪圣 = 25860,
                水流幕 = 25861,
                礼仪之铃 = 25862,
                以太变移 = 37008,
                闪飒 = 37009,
                医养 = 37010,
                神爱抚 = 37011;
        }

        public static class Buffs
        {
            public const uint
                神速咏唱 = 157,
                无中生有 = 1217,
                节制 = 1873,
                再生 = 158,
                医济 = 150,
                神祝祷 = 1218,
                苏生之炎 = 2704,
                礼仪之铃 = 2851;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Stone = 119,
                Cure = 120,
                Aero = 121,
                Medica = 124,
                Raise = 125,
                StoneII = 127,
                CureIII = 131,
                AeroII = 132,
                MedicaII = 133,
                CureII = 135,
                PresenceOfMind = 136,
                Regen = 137,
                Holy = 139,
                Benediction = 140,
                StoneIII = 3568,
                Asylum = 3569,
                Tetragrammaton = 3570,
                Assize = 3571,
                ThinAir = 7430,
                StoneIV = 7431,
                DivineBenison = 7432,
                PlenaryIndulgence = 7433,
                Surecast = 7559,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                Esuna = 7568,
                Rescue = 7571,
                AfflatusSolace = 16531,
                Dia = 16532,
                Glare = 16533,
                AfflatusRapture = 16534,
                AfflatusMisery = 16535,
                Temperance = 16536,
                Repose = 16560,
                GlareIII = 25859,
                HolyIII = 25860,
                Aquaveil = 25861,
                LiturgyOfTheBell = 25862,
                AetherialShift = 37008,
                GlareIV = 37009,
                MedicaIII = 37010,
                DivineCaress = 37011;
        }

        public static class Buffs
        {
            public const uint
                PresenceOfMind = 157,
                ThinAir = 1217,
                Temperance = 1873,
                Regen = 158,
                MedicaII = 150,
                DivineBenison = 1218,
                Rekindle = 2704,
                LiturgyOfTheBell = 2851;
        }
    }

    #endregion

    #region 技能 / Buff / DoT ID

    public const uint PresenceOfMind = 157;      // 神速咏唱
    public const uint ThinAir = 1217;            // 无中生有
    public const uint Temperance = 1873;         // 节制
    public const uint Regen = 158;               // 再生 (buff)
    public const uint Medica2 = 150;             // 医济 (buff)
    public const uint DivineBenison = 1218;      // 神祝祷
    public const uint Aquaveil = 2704;           // 水流幕
    public const uint LiturgyOfTheBell = 2851;   // 礼仪之铃

    #endregion

    /// <summary>白魔法师职业量谱</summary>
    public static WHMGauge? Gauge => HelperRuntime.GetGauge<WHMGauge>();

    /// <summary>百合数量</summary>
    public static byte LilyCount => Gauge?.Lily ?? 0;

    /// <summary>血百合数量</summary>
    public static byte BloodLilyCount => Gauge?.BloodLily ?? 0;

    /// <summary>神速咏唱是否激活</summary>
    public static bool HasPresenceOfMind =>
        HelperRuntime.HasStatus(PresenceOfMind);

    /// <summary>无中生有是否激活</summary>
    public static bool HasThinAir =>
        HelperRuntime.HasStatus(ThinAir);

    /// <summary>节制是否激活</summary>
    public static bool HasTemperance =>
        HelperRuntime.HasStatus(Temperance);

    /// <summary>是否有百合可用</summary>
    public static bool HasLilyReady => LilyCount > 0;

    /// <summary>是否有血百合可用</summary>
    public static bool HasBloodLilyReady => BloodLilyCount >= 3;
}