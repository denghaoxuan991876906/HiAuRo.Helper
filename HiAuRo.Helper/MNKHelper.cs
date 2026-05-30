namespace HiAuRo.Helper;

/// <summary>
/// 武僧 (MNK) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class MNKHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                连击 = 53,
                正拳 = 54,
                崩拳 = 56,
                双掌打 = 61,
                破坏神冲 = 62,
                真言 = 65,
                破碎拳 = 66,
                震脚 = 69,
                地烈劲 = 70,
                双龙脚 = 74,
                斗魂旋风脚 = 3543,
                苍气炮 = 3545,
                阴阳斗气斩 = 3547,
                演武 = 4262,
                金刚极意 = 7394,
                红莲极意 = 7395,
                义结金兰 = 7396,
                内丹 = 7541,
                浴血 = 7542,
                真北 = 7546,
                亲疏自行 = 7548,
                牵制 = 7549,
                扫腿 = 7863,
                四面脚 = 16473,
                万象斗气圈 = 16474,
                六合星导脚 = 16476,
                铁山靠 = 25761,
                轻身步法 = 25762,
                空鸣拳 = 25763,
                必杀技 = 25764,
                翻天脚 = 25765,
                疾风极意 = 25766,
                破坏神脚 = 25767,
                凤凰舞 = 25768,
                梦幻斗舞 = 25769,
                爆裂脚 = 25882,
                铁山斗气 = 36940,
                空鸣斗气 = 36941,
                阴阳斗气 = 36942,
                万象斗气 = 36943,
                金刚周天 = 36944,
                猿舞连击 = 36945,
                龙颚正拳 = 36946,
                豹袭崩拳 = 36947,
                真空波 = 36948,
                绝空拳 = 36949,
                乾坤斗气弹 = 36950;
        }
        public static class Buffs
        {
            public const uint
                震脚 = 110,
                红莲极意 = 1181,
                疾风体势 = 2587,
                义结金兰 = 1185,
                金刚体势 = 1861,
                功力 = 3001;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Bootshine = 53,
                TrueStrike = 54,
                SnapPunch = 56,
                TwinSnakes = 61,
                ArmOfTheDestroyer = 62,
                Mantra = 65,
                Demolish = 66,
                PerfectBalance = 69,
                Rockbreaker = 70,
                DragonKick = 74,
                TornadoKick = 3543,
                ElixirField = 3545,
                TheForbiddenChakra = 3547,
                FormShift = 4262,
                RiddleOfEarth = 7394,
                RiddleOfFire = 7395,
                Brotherhood = 7396,
                SecondWind = 7541,
                Bloodbath = 7542,
                TrueNorth = 7546,
                ArmsLength = 7548,
                Feint = 7549,
                LegSweep = 7863,
                FourPointFury = 16473,
                Enlightenment = 16474,
                SixSidedStar = 16476,
                SteelPeak = 25761,
                Thunderclap = 25762,
                HowlingFist = 25763,
                MasterfulBlitz = 25764,
                CelestialRevolution = 25765,
                RiddleOfWind = 25766,
                ShadowOfTheDestroyer = 25767,
                RisingPhoenix = 25768,
                PhantomRush = 25769,
                FlintStrike = 25882,
                SteledMeditation = 36940,
                InspiritedMeditation = 36941,
                ForbiddenMeditation = 36942,
                EnlightenedMeditation = 36943,
                EarthsReply = 36944,
                LeapingOpo = 36945,
                RisingRaptor = 36946,
                PouncingCoeurl = 36947,
                ElixirBurst = 36948,
                WindsReply = 36949,
                FiresReply = 36950;
        }
        public static class Buffs
        {
            public const uint
                PerfectBalance = 110,
                RiddleOfFire = 1181,
                RiddleOfWind = 2587,
                Brotherhood = 1185,
                LeadenFist = 1861,
                DisciplinedFist = 3001;
        }
    }

    #endregion

    public const uint PerfectBalance = 110;     // 震脚
    public const uint RiddleOfFire = 1181;      // 红莲体势
    public const uint RiddleOfWind = 2587;      // 疾风体势
    public const uint Brotherhood = 1185;       // 义结金兰
    public const uint LeadenFist = 1861;        // 金刚体势 (buff)
    public const uint DisciplinedFist = 3001;   // 破坏神脚 (增伤buff)

    /// <summary>武僧职业量谱</summary>
    public static MNKGauge? Gauge => HelperRuntime.GetGauge<MNKGauge>();

    /// <summary>查克拉数量</summary>
    public static byte ChakraCount => Gauge?.Chakra ?? 0;

    /// <summary>是否拥有最大查克拉</summary>
    public static bool HasMaxChakra => ChakraCount >= 5;

    /// <summary>震脚是否激活</summary>
    public static bool HasPerfectBalance => HelperRuntime.HasStatus(PerfectBalance);

    /// <summary>红莲体势是否激活</summary>
    public static bool HasRiddleOfFire => HelperRuntime.HasStatus(RiddleOfFire);

    /// <summary>疾风体势是否激活</summary>
    public static bool HasRiddleOfWind => HelperRuntime.HasStatus(RiddleOfWind);

    /// <summary>义结金兰是否激活</summary>
    public static bool HasBrotherhood => HelperRuntime.HasStatus(Brotherhood);

    /// <summary>金刚体势是否激活</summary>
    public static bool HasLeadenFist => HelperRuntime.HasStatus(LeadenFist);

    /// <summary>破坏神脚增伤buff是否激活</summary>
    public static bool HasDisciplinedFist => HelperRuntime.HasStatus(DisciplinedFist);
}