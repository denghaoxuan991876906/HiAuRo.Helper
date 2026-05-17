
namespace HiAuRo.Helper;

/// <summary>
/// 黑魔法师 (BLM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class BLMHelper
{

    #region 技能

    public const uint 冰结 = 142;
    public const uint 火炎 = 141;
    public const uint 崩溃 = 156;
    public const uint 爆炎 = 152;
    public const uint 冰封 = 154;
    public const uint 灵极魂 = 16506;
    public const uint 玄冰 = 159;
    public const uint 核爆 = 162;
    public const uint 冰澈 = 3576;
    public const uint 炽焰 = 3577;
    public const uint 秽浊 = 7422;
    public const uint 绝望 = 16505;
    public const uint 异言 = 16507;
    public const uint 高烈炎 = 25794;
    public const uint 高冰冻 = 25795;
    public const uint 烈炎 = 147;
    public const uint 冰冻 = 25793;
    public const uint 高闪雷 = 36986;
    public const uint 高震雷 = 36987;
    public const uint 闪雷 = 144;
    public const uint 暴雷 = 153;
    public const uint 震雷 = 7447;
    public const uint 霹雷 = 7420;
    public const uint 耀星 = 36989;
    public const uint 悖论 = 25797;
    public const uint 催眠 = 25880;

    public const uint 星灵移位 = 149;
    public const uint 魔罩 = 157;
    public const uint 魔泉 = 158;
    public const uint 以太步 = 155;
    public const uint 黑魔纹 = 3573;
    public const uint 魔纹步 = 7419;
    public const uint 三连咏唱 = 7421;
    public const uint 详述 = 25796;
    public const uint 魔纹重置 = 36988;
    public const uint 昏乱 = 7560;
    public const uint 醒梦 = 7562;
    public const uint 即可咏唱 = 7561;
    public const uint 沉稳咏唱 = 7559;

    #endregion

    #region BUFF

    public const uint 醒梦buff = 1204;
    public const uint 即刻buff = 167;
    public const uint 沉稳buff = 160;
    public const uint 魔罩buff = 168;
    public const uint 三连buff = 1211;
    public const uint 雷云buff = 3871;
    public const uint 火苗buff = 165;
    public const uint 魔纹存在buff = 737;
    public const uint 魔纹加速buff = 738;

    #endregion
    /// <summary>黑魔法师职业量谱</summary>
    public static BLMGauge Gauge => HelperRuntime.GetGauge<BLMGauge>();

    /// <summary>是否处于星极火状态</summary>
    public static bool 火状态 => Gauge.InAstralFire;
    
    public static bool 冰状态 => Gauge.InUmbralIce;

    public static uint 火层数 => Gauge.AstralFireStacks;
    public static uint 冰层数 => Gauge.UmbralIceStacks;
    public static uint 冰针数 => Gauge.UmbralHearts;
    public static int 耀星层数 => Gauge.AstralSoulStacks;
    public static uint 通晓数 => Gauge.PolyglotStacks;
    public static bool 悖论指示 => Gauge.IsParadoxActive;
    public static bool 天语状态 => Gauge.IsEnochianActive;
    public static short 通晓计时 => Gauge.EnochianTimer;
    
}