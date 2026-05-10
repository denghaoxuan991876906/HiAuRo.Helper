
namespace HiAuRo.Helper;

/// <summary>
/// 绝枪战士 (GNB) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class GNBHelper
{

    #region 技能 / Buff ID

    private const uint 无情           = 1831;   // 无情
    private const uint 撕喉预备          = 1842;   // 续剑1
    private const uint 裂膛预备         = 1843;   //续剑2
    private const uint 穿目预备        = 1844;   // 续剑3
    private const uint 刚玉之清     = 2684;   // 4s的15减伤
    private const uint 超火流星         = 1836;   // 无敌
    private const uint 残暴弹         = 1898;   // 残暴弹 (护盾buff)
    private const uint 命运之印预备 = 3839;//Ready to Raze 命运之环续剑
    private const uint 心有灵狮 = 3840; //Ready to Reign
    private const uint 超高速预备 = 2686;//续剑爆发击
    private const uint 王室亲卫 = 1833;//Royal Guard
    private const uint 音速破预备 = 3886U;
    private const uint 刚玉之心 = 2683; //8s的15减伤
    private const uint 刚玉之净 = 2685; //回血
    private const uint 石之心 = 1840;
    private const uint 星云 = 1834;
    private const uint 大星云 = 3838;//Great Nebula
    private const uint 伪装 = 1832;
    private const uint 极光 = 1835;
    #endregion

    /// <summary>绝枪战士职业量谱</summary>
    public static GNBGauge? Gauge => HelperRuntime.GetGauge<GNBGauge>();

    /// <summary>晶壤数量 (0-6)</summary>
    public static byte CartridgeCount => Gauge?.Ammo ?? 0;

    /// <summary>是否有晶壤</summary>
    public static bool HasCartridge => CartridgeCount > 0;

    /// <summary>晶壤是否已满 (3层以上)</summary>
    public static bool HasMaxCartridges => CartridgeCount >= 3;

    /// <summary>无情是否激活</summary>
    public static bool Has无情 =>
        HelperRuntime.HasStatus(无情);

    /// <summary>王室亲卫是否激活</summary>
    public static bool Has王室亲卫 =>
        HelperRuntime.HasStatus(王室亲卫);

    /// <summary>残暴弹 (护盾buff) 是否激活</summary>
    public static bool Has残暴弹 =>
        HelperRuntime.HasStatus(残暴弹);

    /// <summary>撕喉预备是否激活</summary>
    public static bool Has撕喉预备 =>
        HelperRuntime.HasStatus(撕喉预备);

    /// <summary>裂膛预备是否激活</summary>
    public static bool Has裂膛预备 =>
        HelperRuntime.HasStatus(裂膛预备);

    /// <summary>穿目预备是否激活</summary>
    public static bool Has超高速预备 =>
        HelperRuntime.HasStatus(超高速预备);
    
    public static bool Has音速破预备 =>
        HelperRuntime.HasStatus(音速破预备);
    public static bool Has命运之印预备 =>
        HelperRuntime.HasStatus(命运之印预备);
    public static bool Has超火流星 =>
        HelperRuntime.HasStatus(超火流星);
    public static bool Has心有灵狮 =>
        HelperRuntime.HasStatus(心有灵狮);
    public static bool Has穿目预备 =>
        HelperRuntime.HasStatus(穿目预备);
}