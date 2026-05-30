namespace HiAuRo.Helper;

/// <summary>
/// 钐镰客 (RPR) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class RPRHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                切割 = 24373,
                增盈切割 = 24374,
                地狱切割 = 24375,
                旋转钐割 = 24376,
                噩梦钐割 = 24377,
                死亡之影 = 24378,
                死亡之涡 = 24379,
                灵魂切割 = 24380,
                灵魂钐割 = 24381,
                绞决 = 24382,
                缢杀 = 24383,
                断首 = 24384,
                大丰收 = 24385,
                勾刃 = 24386,
                播魂种 = 24387,
                收获月 = 24388,
                隐匿挥割 = 24389,
                绞决爪 = 24390,
                缢杀爪 = 24391,
                束缚挥割 = 24392,
                暴食 = 24393,
                夜游魂衣 = 24394,
                虚无收割 = 24395,
                交错收割 = 24396,
                阴冷收割 = 24397,
                团契 = 24398,
                夜游魂切割 = 24399,
                夜游魂钐割 = 24400,
                地狱入境 = 24401,
                地狱出境 = 24402,
                回退 = 24403,
                神秘纹 = 24404,
                神秘环 = 24405,
                内丹 = 7541,
                浴血 = 7542,
                真北 = 7546,
                亲疏自行 = 7548,
                牵制 = 7549,
                扫腿 = 7863,
                祭牲 = 36969,
                绞决处刑 = 36970,
                缢杀处刑 = 36971,
                断首处刑 = 36972,
                完人 = 36973;
        }
        public static class Buffs
        {
            public const uint
                神秘环 = 2577,
                播魂种 = 2591,
                夜游魂附体 = 2593;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Slice = 24373,
                WaxingSlice = 24374,
                InfernalSlice = 24375,
                SpinningScythe = 24376,
                NightmareScythe = 24377,
                ShadowOfDeath = 24378,
                WhorlOfDeath = 24379,
                SoulSlice = 24380,
                SoulScythe = 24381,
                Gibbet = 24382,
                Gallows = 24383,
                Guillotine = 24384,
                PlentifulHarvest = 24385,
                Harpe = 24386,
                Soulsow = 24387,
                HarvestMoon = 24388,
                BloodStalk = 24389,
                UnveiledGibbet = 24390,
                UnveiledGallows = 24391,
                GrimSwathe = 24392,
                Gluttony = 24393,
                Enshroud = 24394,
                VoidReaping = 24395,
                CrossReaping = 24396,
                GrimReaping = 24397,
                Communio = 24398,
                LemuresSlice = 24399,
                LemuresScythe = 24400,
                HellsIngress = 24401,
                HellsEgress = 24402,
                Regress = 24403,
                ArcaneCrest = 24404,
                ArcaneCircle = 24405,
                SecondWind = 7541,
                Bloodbath = 7542,
                TrueNorth = 7546,
                ArmsLength = 7548,
                Feint = 7549,
                LegSweep = 7863,
                Sacrificium = 36969,
                ExecutionersGibbet = 36970,
                ExecutionersGallows = 36971,
                ExecutionersGuillotine = 36972,
                Perfectio = 36973;
        }
        public static class Buffs
        {
            public const uint
                ArcaneCircle = 2577,
                SoulSow = 2591,
                Enshrouded = 2593;
        }
    }

    #endregion

    public const uint ArcaneCircle = 2577;      // 神秘环
    public const uint SoulSow = 2591;           // 播魂种 (buff)
    public const uint Enshrouded = 2593;        // 夜游魂 (附体buff)

    /// <summary>钐镰客职业量谱</summary>
    public static RPRGauge? Gauge => HelperRuntime.GetGauge<RPRGauge>();

    /// <summary>魂量值</summary>
    public static byte SoulGauge => Gauge?.Soul ?? 0;

    /// <summary>遮蔽值</summary>
    public static byte ShroudGauge => Gauge?.Shroud ?? 0;

    /// <summary>是否可以进入夜游魂附体 (需要50遮蔽)</summary>
    public static bool CanEnshroud => ShroudGauge >= 50;

    /// <summary>神秘环是否激活</summary>
    public static bool HasArcaneCircle => HelperRuntime.HasStatus(ArcaneCircle);

    /// <summary>播魂种是否激活</summary>
    public static bool HasSoulSow => HelperRuntime.HasStatus(SoulSow);

    /// <summary>夜游魂附体是否激活</summary>
    public static bool HasEnshrouded => HelperRuntime.HasStatus(Enshrouded);
}