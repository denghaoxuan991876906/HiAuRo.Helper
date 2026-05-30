
namespace HiAuRo.Helper;

public class DNCHelper
{
    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)
    public static class CN
    {
        public static class Skills
        {
            public const uint
                瀑泻 = 15989,
                喷泉 = 15990,
                逆瀑泻 = 15991,
                坠喷泉 = 15992,
                风车 = 15993,
                落刃雨 = 15994,
                升风车 = 15995,
                落血雨 = 15996,
                标准舞步 = 15997,
                技巧舞步 = 15998,
                标准舞步结束 = 16003,
                技巧舞步结束 = 16004,
                剑舞 = 16005,
                闭式舞姿 = 16006,
                扇舞_序 = 16007,
                扇舞_破 = 16008,
                扇舞_急 = 16009,
                前冲步 = 16010,
                进攻之探戈 = 16011,
                防守之桑巴 = 16012,
                百花争艳 = 16013,
                即兴表演 = 16014,
                治疗之华尔兹 = 16015,
                单色标准舞步结束 = 16191,
                双色标准舞步结束 = 16192,
                单色技巧舞步结束 = 16193,
                双色技巧舞步结束 = 16194,
                三色技巧舞步结束 = 16195,
                四色技巧舞步结束 = 16196,
                解除闭式舞姿 = 18073,
                即兴表演结束 = 25789,
                提拉纳 = 25790,
                扇舞_终 = 25791,
                流星舞 = 25792,
                内丹 = 7541,
                亲疏自行 = 7548,
                伤头 = 7551,
                伤足 = 7553,
                伤腿 = 7554,
                速行 = 7557,
                落幕舞 = 36983,
                结束动作 = 36984,
                拂晓舞 = 36985;
        }
        public static class Buffs
        {
            public const uint 标准舞步结束 = 1821;
            public const uint 技巧舞步结束 = 1822;
            public const uint 扇舞急预备 = 1820;
            public const uint 提拉纳预备 = 2698;
            public const uint 流星舞预备 = 2700;
            public const uint 对称投掷 = 2693;
            public const uint 非对称投掷 = 2694;
            public const uint 扇舞终 = 2699;
            public const uint 落幕舞预备 = 3867;
            public const uint 伶俐 = 1847;
        }
    }
    #endregion
    #region EN — English Names (verified via xivapi-v2.xivcdn.com)
    public static class EN
    {
        public static class Skills
        {
            public const uint
                Cascade = 15989,
                Fountain = 15990,
                ReverseCascade = 15991,
                Fountainfall = 15992,
                Windmill = 15993,
                Bladeshower = 15994,
                RisingWindmill = 15995,
                Bloodshower = 15996,
                StandardStep = 15997,
                TechnicalStep = 15998,
                StandardFinish = 16003,
                TechnicalFinish = 16004,
                SaberDance = 16005,
                ClosedPosition = 16006,
                FanDance = 16007,
                FanDanceII = 16008,
                FanDanceIII = 16009,
                EnAvant = 16010,
                Devilment = 16011,
                ShieldSamba = 16012,
                Flourish = 16013,
                Improvisation = 16014,
                CuringWaltz = 16015,
                SingleStandardFinish = 16191,
                DoubleStandardFinish = 16192,
                SingleTechnicalFinish = 16193,
                DoubleTechnicalFinish = 16194,
                TripleTechnicalFinish = 16195,
                QuadrupleTechnicalFinish = 16196,
                Ending = 18073,
                ImprovisedFinish = 25789,
                Tillana = 25790,
                FanDanceIV = 25791,
                StarfallDance = 25792,
                SecondWind = 7541,
                ArmsLength = 7548,
                HeadGraze = 7551,
                FootGraze = 7553,
                LegGraze = 7554,
                Peloton = 7557,
                LastDance = 36983,
                FinishingMove = 36984,
                DanceOfTheDawn = 36985;
        }
        public static class Buffs
        {
            public const uint StandardFinish = 1821;
            public const uint TechnicalFinish = 1822;
            public const uint ThreefoldFanDance = 1820;
            public const uint FlourishingFinish = 2698;
            public const uint FlourishingStarfall = 2700;
            public const uint SilkenSymmetry = 2693;
            public const uint SilkenFlow = 2694;
            public const uint FourfoldFanDance = 2699;
            public const uint LastDanceReady = 3867;
            public const uint Esprit = 1847;
        }
    }
    #endregion

    #region 技能

    public const uint 瀑泻 = 15989;
    public const uint 喷泉 = 15990;
    public const uint 逆瀑泻 = 15991;
    public const uint 坠喷泉 = 15992;
    public const uint 风车 = 15993;
    public const uint 落刃雨 = 15994;
    public const uint 升风车 = 15995;
    public const uint 落血雨 = 15996;
    public const uint 标准舞步 = 15997;
    public const uint 技巧舞步 = 15998;
    public const uint 单色标准舞步结束 = 16191;
    public const uint 双色标准舞步结束 = 16192;
    public const uint 单色技巧舞步结束 = 16193;
    public const uint 双色技巧舞步结束 = 16194;
    public const uint 三色技巧舞步结束 = 16195;
    public const uint 四色技巧舞步结束 = 16196;
    public const uint 剑舞 = 16005;
    public const uint 闭式舞姿 = 16006;
    public const uint 解除闭式舞姿 = 18073;
    public const uint 扇舞序 = 16007;
    public const uint 扇舞破 = 16008;
    public const uint 扇舞急 = 16009;
    public const uint 扇舞终 = 25791;
    public const uint 前冲步 = 16010;
    public const uint 进攻之探戈 = 16011;
    public const uint 防守之桑巴 = 16012;
    public const uint 百花争艳 = 16013;
    public const uint 即兴表演 = 16014;
    public const uint 即兴表演结束 = 25789;
    public const uint 治疗之华尔兹 = 16015;
    public const uint 流星舞 = 25792;
    public const uint 提拉纳 = 25790;
    public const uint 落幕舞 = 36983;
    public const uint 结束动作 = 36984;
    public const uint 拂晓舞 = 36985;

    #endregion

    #region Buff

    public const uint 标准舞步结束buff = 1821;
    public const uint 技巧舞步结束buff = 1822;
    public const uint 进攻之探戈buff = 1820;
    public const uint 百花争艳buff = 2698;
    public const uint 流星舞预备buff = 2700;
    public const uint 对称投掷buff = 2693;
    public const uint 非对称投掷buff = 2694;
    public const uint 四色扇舞buff = 2699;
    public const uint 落幕舞预备buff = 3867;
    public const uint 伶俐buff = 1847;

    #endregion

    #region 量谱

    public static DNCGauge? Gauge => HelperRuntime.GetGauge<DNCGauge>();

    public static byte EspritGauge => Gauge?.Esprit ?? 0;

    public static byte FeathersCount => Gauge?.Feathers ?? 0;

    public static bool IsDancing => Gauge?.IsDancing ?? false;

    #endregion

    #region BUFF检测

    public static bool HasTechnicalFinish => HelperRuntime.HasStatus(技巧舞步结束buff);

    public static bool HasStandardFinish => HelperRuntime.HasStatus(标准舞步结束buff);

    public static bool HasDevilment => HelperRuntime.HasStatus(进攻之探戈buff);

    #endregion

    #region 辅助方法

        public static bool 双目标 => HelperRuntime.GetNearbyEnemyCount(5) >= 2;
        public static bool 群怪模式 => HelperRuntime.GetNearbyEnemyCount(5) >= 3;

    #endregion
}
