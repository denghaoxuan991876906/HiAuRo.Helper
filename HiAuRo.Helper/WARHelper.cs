
namespace HiAuRo.Helper;

/// <summary>
/// 战士 (WAR) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class WARHelper
{
    private readonly IHelperContext _ctx;

    public WARHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff ID

    private const uint InnerRelease        = 1177;   // 原初的解放
    private const uint Berserk             = 86;     // 狂暴
    private const uint NascentChaos        = 1856;   // 混沌 (裂石飞环预备)
    private const uint SurgingTempest      = 2677;   // 暴风 (增伤buff)
    private const uint ThrillOfBattle      = 87;     // 战栗
    private const uint Vengeance           = 89;     // 复仇
    private const uint Holmgang            = 88;     // 死斗

    #endregion

    /// <summary>战士职业量谱</summary>
    public WARGauge? Gauge =>
        DService.Instance().JobGauges.Get<WARGauge>();

    /// <summary>兽魂值 (0-100)</summary>
    public byte BeastGauge => Gauge?.BeastGauge ?? 0;

    /// <summary>原初的解放是否激活</summary>
    public bool HasInnerRelease =>
        _ctx.HasStatus(InnerRelease);

    /// <summary>狂暴是否激活</summary>
    public bool HasBerserk =>
        _ctx.HasStatus(Berserk);

    /// <summary>暴风 (增伤buff) 是否激活</summary>
    public bool HasSurgingTempest =>
        _ctx.HasStatus(SurgingTempest);

    /// <summary>混沌 (裂石飞环预备) 是否激活</summary>
    public bool HasNascentChaos =>
        _ctx.HasStatus(NascentChaos);
}