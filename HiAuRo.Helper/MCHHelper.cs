
namespace HiAuRo.Helper;

/// <summary>
/// 机工士 (MCH) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class MCHHelper
{

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

    public const uint 起爆 = 16766;
    public const uint 火焰喷射器 = 7418;

    public const uint 武装解除 = 2887;
    public const uint 策动 = 16889;
    public const uint 亲疏自行 = 7548; 
    public const uint 内丹 = 7541; 
    public const uint 伤头 = 7551;
    #endregion

    #region BUFF
    public const uint 野火buff = 1946;
    public const uint 整备buff = 851;
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
