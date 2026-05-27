
namespace HiAuRo.Helper;

/// <summary>
/// 绝枪战士 (GNB) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class GNBHelper
{

    #region 技能 / Buff ID

    public const uint 无情           = 1831;   // 无情
    public const uint 撕喉预备          = 1842;   // 续剑1
    public const uint 裂膛预备         = 1843;   //续剑2
    public const uint 穿目预备        = 1844;   // 续剑3
    public const uint 刚玉之清     = 2684;   // 4s的15减伤
    public const uint 超火流星         = 1836;   // 无敌
    public const uint 残暴弹         = 1898;   // 残暴弹 (护盾buff)
    public const uint 命运之印预备 = 3839;//Ready to Raze 命运之环续剑
    public const uint 心有灵狮 = 3840; //Ready to Reign
    public const uint 超高速预备 = 2686;//续剑爆发击
    public const uint 王室亲卫 = 1833;//Royal Guard
    public const uint 音速破预备 = 3886U;
    public const uint 刚玉之心 = 2683; //8s的15减伤
    public const uint 刚玉之净 = 2685; //回血
    public const uint 石之心 = 1840;
    public const uint 星云 = 1834;
    public const uint 大星云 = 3838;//Great Nebula
    public const uint 伪装 = 1832;
    public const uint 极光 = 1835;
    public const uint 光之心 = 1839; //
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
    public static bool Has穿目预备 =>
        HelperRuntime.HasStatus(穿目预备);

    #region 技能
    public const uint 利刃斩 = 16137;
    public const uint 残暴弹技能 = 16139;
    public const uint 讯连斩 = 16145;
    public const uint 爆发击 = 16162;
    public const uint 恶魔切 = 16141;
    public const uint 恶魔杀 = 16149;
    public const uint 命运之环 = 16163;
    public const uint 命运之印 = 36936;
    public const uint 闪雷弹 = 16143;
    public const uint 音速破 = 16153;
    public const uint 烈牙 = 16146;
    public const uint 猛兽爪 = 16147;
    public const uint 凶禽爪 = 16150;
    public const uint 倍功 = 25760;
    public const uint 崛起之心 = 36937;
    public const uint 支配之心 = 36938;
    public const uint 终结之心 = 36939;
    public const uint 无情技能 = 16138;
    public const uint 危险领域 = 16144;
    public const uint 弓形冲波 = 16159;
    public const uint 血壤 = 16164;
    public const uint 爆破领域 = 16165;
    public const uint 铁壁 = 7531;
    public const uint 雪仇 = 7535;
    public const uint 挑衅 = 7533;
    public const uint 退避 = 7537;
    public const uint 亲疏自行 = 7548;
    public const uint 撕喉 = 16148;
    public const uint 裂膛 = 16151;
    public const uint 穿目 = 16152;
    public const uint 超高速 = 25761;
    #endregion

    #region 辅助方法
        public static bool 续剑激活 => HelperRuntime.HasStatus(1842) || HelperRuntime.HasStatus(1843) || HelperRuntime.HasStatus(1844) || HelperRuntime.HasStatus(3839) || HelperRuntime.HasStatus(2686);
        public static bool 血壤激活 => HelperRuntime.HasStatus(5051);
        public static bool 群怪模式 => HelperRuntime.GetNearbyEnemyCount(5) >= 3;
    #endregion
}
