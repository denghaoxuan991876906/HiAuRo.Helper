
namespace HiAuRo.Helper;

/// <summary>
/// 学者 (SCH) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SCHHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                以太超流 = 166,
                能量吸收 = 167,
                医术 = 190,
                复生 = 173,
                鼓舞激励之策 = 185,
                士气高扬之策 = 186,
                野战治疗阵 = 188,
                生命活性法 = 189,
                沉稳咏唱 = 7559,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                康复 = 7568,
                营救 = 7571,
                破阵法 = 16539,
                蛊毒法 = 16540,
                死炎法 = 16541,
                秘策 = 16542,
                炽天召唤 = 16545,
                深谋远虑之策 = 7434,
                魔炎法 = 7435,
                连环计 = 7436,
                以太契约 = 7437,
                沉静 = 16560,
                极炎法 = 25865,
                裂阵法 = 25866,
                生命回生法 = 25867,
                疾风怒涛之计 = 25868,
                埋伏之毒 = 37012,
                意气轩昂之策 = 37013,
                炽天附体 = 37014,
                显灵之章 = 37015,
                降临之章 = 37016;
        }

        public static class Buffs
        {
            public const uint
                连环计 = 1221,
                蛊毒法 = 1895,
                野战治疗阵 = 188,
                深谋远虑之策 = 1220,
                秘策 = 1896,
                疾风怒涛之计 = 2713,
                炽天炽翼 = 3714;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Aetherflow = 166,
                EnergyDrain = 167,
                Physick = 190,
                Resurrection = 173,
                Adloquium = 185,
                Succor = 186,
                SacredSoil = 188,
                Lustrate = 189,
                Surecast = 7559,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                Esuna = 7568,
                Rescue = 7571,
                ArtOfWar = 16539,
                Biolysis = 16540,
                BroilIII = 16541,
                Recitation = 16542,
                SummonSeraph = 16545,
                Excogitation = 7434,
                BroilII = 7435,
                ChainStratagem = 7436,
                Aetherpact = 7437,
                Repose = 16560,
                BroilIV = 25865,
                ArtOfWarII = 25866,
                Protraction = 25867,
                Expedient = 25868,
                BanefulImpaction = 37012,
                Concitation = 37013,
                Seraphism = 37014,
                Manifestation = 37015,
                Accession = 37016;
        }

        public static class Buffs
        {
            public const uint
                ChainStratagem = 1221,
                Biolysis = 1895,
                SacredSoil = 188,
                Excogitation = 1220,
                Recitation = 1896,
                Expedient = 2713,
                Seraphism = 3714;
        }
    }

    #endregion

    #region 技能 / Buff / DoT ID

    public const uint ChainStratagem = 1221;     // 连环计
    public const uint Biolysis = 1895;           // 蛊毒法 (DoT)
    public const uint SacredSoil = 188;          // 野战治疗阵 (buff)
    public const uint Excogitation = 1220;       // 深谋远虑之策
    public const uint Recitation = 1896;         // 转化
    public const uint Expedient = 2713;          // 疾风怒涛之计
    public const uint Seraphism = 3714;          // 炽天炽翼

    #endregion

    /// <summary>学者职业量谱</summary>
    public static SCHGauge? Gauge => HelperRuntime.GetGauge<SCHGauge>();

    /// <summary>以太超流层数</summary>
    public static byte AetherflowCount => Gauge?.Aetherflow ?? 0;

    /// <summary>是否拥有以太超流</summary>
    public static bool HasAetherflow => AetherflowCount > 0;

    /// <summary>连环计是否激活</summary>
    public static bool HasChainStratagem =>
        HelperRuntime.HasStatus(ChainStratagem);

    /// <summary>转化是否激活</summary>
    public static bool HasRecitation =>
        HelperRuntime.HasStatus(Recitation);

    /// <summary>疾风怒涛之计是否激活</summary>
    public static bool HasExpedient =>
        HelperRuntime.HasStatus(Expedient);

    /// <summary>炽天炽翼是否激活</summary>
    public static bool HasSeraphism =>
        HelperRuntime.HasStatus(Seraphism);
}