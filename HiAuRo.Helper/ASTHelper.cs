
namespace HiAuRo.Helper;

/// <summary>
/// 占星术士 (AST) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class ASTHelper
{
    private readonly IHelperContext _ctx;

    public ASTHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff / DoT ID

    private const uint Divination = 1654;         // 占卜
    private const uint Lightspeed = 841;          // 光速
    private const uint Combust = 838;             // 焚灼 (DoT)
    private const uint NeutralSect = 1892;        // 中间学派
    private const uint Horoscope = 1891;          // 天星冲日
    private const uint Exaltation = 2713;         // 擢升
    private const uint Macrocosmos = 2712;        // 大宇宙
    private const uint SunSign = 2720;            // 太阳神之衡 (buff on party)
    private const uint Arrow = 2717;              // 放浪神之箭 (buff on party)
    private const uint Spear = 2718;              // 战争神之枪 (buff on party)
    private const uint Balance = 2716;            // 建筑神之塔 (buff on party)

    #endregion

    /// <summary>占星术士职业量谱</summary>
    public ASTGauge? Gauge =>
        DService.Instance().JobGauges.Get<ASTGauge>();

    /// <summary>占卜是否激活</summary>
    public bool HasDivination =>
        _ctx.HasStatus(Divination);

    /// <summary>光速是否激活</summary>
    public bool HasLightspeed =>
        _ctx.HasStatus(Lightspeed);

    /// <summary>中间学派是否激活</summary>
    public bool HasNeutralSect =>
        _ctx.HasStatus(NeutralSect);
}