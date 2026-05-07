namespace HiAuRo.Helper;

/// <summary>
/// 龙骑士 (DRG) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class DRGHelper
{
    private readonly IHelperContext _ctx;
    public DRGHelper(IHelperContext ctx) { _ctx = ctx; }

    private const uint LifeSurge = 116;          // 龙剑
    private const uint LanceCharge = 1864;       // 猛枪
    private const uint DragonSight = 1870;       // 巨龙视线
    private const uint BattleLitany = 786;       // 战斗连祷
    private const uint PowerSurge = 2720;        // 龙威 (buff)
    private const uint GeirskogulReady = 2719;   // 龙眼 (武神枪预备)

    /// <summary>龙骑士职业量谱</summary>
    public DRGGauge? Gauge => DService.Instance().JobGauges.Get<DRGGauge>();

    /// <summary>猛枪是否激活</summary>
    public bool HasLanceCharge => _ctx.HasStatus(LanceCharge);

    /// <summary>巨龙视线是否激活</summary>
    public bool HasDragonSight => _ctx.HasStatus(DragonSight);

    /// <summary>龙剑是否激活</summary>
    public bool HasLifeSurge => _ctx.HasStatus(LifeSurge);

    /// <summary>战斗连祷是否激活</summary>
    public bool HasBattleLitany => _ctx.HasStatus(BattleLitany);

    /// <summary>龙威是否激活</summary>
    public bool HasPowerSurge => _ctx.HasStatus(PowerSurge);

    /// <summary>武神枪预备是否激活</summary>
    public bool HasGeirskogulReady => _ctx.HasStatus(GeirskogulReady);
}