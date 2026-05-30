
namespace HiAuRo.Helper;

/// <summary>
/// 机工士 (MCH) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class MCHHelper
{
    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)
    public static class CN
    {
        public static class Skills
        {
            public const uint
                车式浮空炮塔 = 2864,
                分裂弹 = 2866,
                独头弹 = 2868,
                散射 = 2870,
                热弹 = 2872,
                狙击弹 = 2873,
                虹吸弹 = 2874,
                整备 = 2876,
                野火 = 2878,
                武装解除 = 2887,
                弹射 = 2890,
                热冲击 = 7410,
                热分裂弹 = 7411,
                热独头弹 = 7412,
                热狙击弹 = 7413,
                枪管加热 = 7414,
                超档车式炮塔 = 7415,
                火焰喷射器 = 7418,
                内丹 = 7541,
                伤头 = 7551,
                伤足 = 7553,
                伤腿 = 7554,
                速行 = 7557,
                自动弩 = 16497,
                钻头 = 16498,
                毒菌冲击 = 16499,
                空气锚 = 16500,
                后式自走人偶 = 16501,
                超档后式人偶 = 16502,
                打桩枪 = 16503,
                铁臂拳 = 16504,
                起爆 = 16766,
                策动 = 16889,
                亲疏自行 = 7548,
                冲刺 = 3,
                超荷 = 17209,
                滚轮冲 = 17206,
                霰弹枪 = 25786,
                王室对撞机 = 25787,
                回转飞锯 = 25788,
                烈焰弹 = 36978,
                双将 = 36979,
                将死 = 36980,
                掘地飞轮 = 36981,
                全金属爆发 = 36982;
        }
        public static class Buffs
        {
            public const uint 野火 = 1946;
            public const uint 目标野火 = 861;
            public const uint 整备 = 851;
            public const uint 火焰喷射器 = 1205;
            public const uint 过热 = 2688;
            public const uint 掘地飞轮预备 = 3865;
            public const uint 超荷预备 = 3864;
            public const uint 全金属爆发预备 = 3866;
            public const uint 策动 = 1951;
            public const uint 防守之桑巴 = 1826;
            public const uint 行吟 = 1934;
            public const uint 武装解除 = 860;
            public const uint 毒菌冲击 = 1866;
        }
    }
    #endregion
    #region EN — English Names (verified via xivapi-v2.xivcdn.com)
    public static class EN
    {
        public static class Skills
        {
            public const uint
                RookAutoturret = 2864,
                SplitShot = 2866,
                SlugShot = 2868,
                SpreadShot = 2870,
                HotShot = 2872,
                CleanShot = 2873,
                GaussRound = 2874,
                Reassemble = 2876,
                Wildfire = 2878,
                Dismantle = 2887,
                Ricochet = 2890,
                HeatBlast = 7410,
                HeatedSplitShot = 7411,
                HeatedSlugShot = 7412,
                HeatedCleanShot = 7413,
                BarrelStabilizer = 7414,
                RookOverdrive = 7415,
                Flamethrower = 7418,
                SecondWind = 7541,
                HeadGraze = 7551,
                FootGraze = 7553,
                LegGraze = 7554,
                Peloton = 7557,
                AutoCrossbow = 16497,
                Drill = 16498,
                Bioblaster = 16499,
                AirAnchor = 16500,
                AutomatonQueen = 16501,
                QueenOverdrive = 16502,
                PileBunker = 16503,
                ArmPunch = 16504,
                Detonator = 16766,
                Tactician = 16889,
                ArmsLength = 7548,
                Sprint = 3,
                Hypercharge = 17209,
                RollerDash = 17206,
                Scattergun = 25786,
                CrownedCollider = 25787,
                ChainSaw = 25788,
                BlazingShot = 36978,
                DoubleCheck = 36979,
                Checkmate = 36980,
                Excavator = 36981,
                FullMetalField = 36982;
        }
        public static class Buffs
        {
            public const uint Wildfire = 1946;
            public const uint WildfireOnTarget = 861;
            public const uint Reassembled = 851;
            public const uint Flamethrower = 1205;
            public const uint Overheated = 2688;
            public const uint ExcavatorReady = 3865;
            public const uint Hypercharged = 3864;
            public const uint FullMetalMachinist = 3866;
            public const uint Tactician = 1951;
            public const uint ShieldSamba = 1826;
            public const uint Troubadour = 1934;
            public const uint Dismantled = 860;
            public const uint Bioblaster = 1866;
        }
    }
    #endregion

    #region 技能ID

    public const uint 分裂弹 = 2866;
    public const uint 独头弹 = 2868;
    public const uint 狙击弹 = 2873;
    public const uint 热分裂弹 = 7411;
    public const uint 热独头弹 = 7412;
    public const uint 热狙击弹 = 7413;

    public const uint 热弹 = 2872;
    public const uint 钻头 = 16498;
    public const uint 空气锚 = 16500;
    public const uint 回转飞锯 = 25788;
    public const uint 掘地飞轮 = 36981;
    public const uint 全金属爆发 = 36982;

    public const uint 散射 = 2870;
    public const uint 霰弹枪 = 25786;
    public const uint 毒菌冲击 = 16499;

    public const uint 超荷 = 17209;
    public const uint 热冲击 = 7410;
    public const uint 烈焰弹 = 36978;
    public const uint 自动弩 = 16497;

    public const uint 虹吸弹 = 2874;
    public const uint 弹射 = 2890;
    public const uint 双将 = 36979;
    public const uint 将死 = 36980;
    public const uint 枪管加热 = 7414;
    public const uint 整备 = 2876;
    public const uint 野火 = 2878;  

    public const uint 车式浮空炮塔 = 2864;
    public const uint 超档车式炮塔 = 7415;
    public const uint 后式自走人偶 = 16501;
    public const uint 超档后式人偶 = 16502;
    public const uint 打桩枪 = 16503;
    public const uint 铁臂拳 = 16504;

    public const uint 起爆 = 16766;
    public const uint 火焰喷射器 = 7418;
    public const uint 滚轮冲 = 17206;
    public const uint 王室对撞机 = 25787;

    public const uint 武装解除 = 2887;
    public const uint 策动 = 16889;
    public const uint 亲疏自行 = 7548; 
    public const uint 内丹 = 7541; 
    public const uint 伤头 = 7551;
    #endregion

    #region BUFF
    public const uint 野火buff = 1946;
    public const uint 目标野火dot = 861;
    public const uint 整备buff = 851;
    public const uint 火焰喷射器buff = 1205;
    public const uint 过热buff = 2688; 
    public const uint 掘地飞轮预备buff = 3865;
    public const uint 超荷预备 = 3864;
    public const uint 全金属爆发预备buff = 3866;
    public const uint 策动buff = 1951;

    public const uint 防守之桑巴buff = 1826;
    public const uint 行吟buff = 1934;

    public const uint 武装解除debuff = 860;
    public const uint 毒菌冲击dot = 1866;
    //public const uint QueenReady = 1726;
    #endregion

    /// <summary>机工士职业量谱</summary>
    public static Dalamud.Game.ClientState.JobGauge.Types.MCHGauge? Gauge
        => HelperRuntime.GetGauge<Dalamud.Game.ClientState.JobGauge.Types.MCHGauge>();

    /// <summary>热量 (0-100)</summary>
    public static byte HeatGauge => Gauge?.Heat ?? 0;

    /// <summary>电量 (0-100)</summary>
    public static byte BatteryGauge => Gauge?.Battery ?? 0;

    /// <summary>是否可以过热 (热量 >= 50)</summary>
    public static bool CanHypercharge => HeatGauge >= 50;

    /// <summary>是否可以召唤机器人 (电量 >= 50)</summary>
    public static bool CanSummonQueen => BatteryGauge >= 50;

    /// <summary>整备是否激活</summary>
    public static bool HasReassembled => HelperRuntime.HasStatus(整备buff);

    /// <summary>野火是否激活</summary>
    public static bool HasWildfire => HelperRuntime.HasStatus(野火buff);

    /// <summary>过热是否激活</summary>
    public static bool HasHypercharge => HelperRuntime.HasStatus(过热buff);
}
