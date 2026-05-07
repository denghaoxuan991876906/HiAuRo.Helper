
namespace HiAuRo.Helper;

/// <summary>
/// 暗黑骑士 (DRK) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class DRKHelper
{
    private readonly IHelperContext _ctx;

    public DRKHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff ID

    private const uint Delirium            = 1972;   // 血乱
    private const uint BloodWeapon         = 742;    // 嗜血
    private const uint Darkside            = 751;    // 暗黑
    private const uint DarkMissionary      = 747;    // 暗黑布道
    private const uint ShadowWall          = 747;    // 暗影墙
    private const uint LivingDead          = 810;    // 行尸走肉
    private const uint Oblation            = 2578;   // 献祭

    #endregion

    /// <summary>暗黑骑士职业量谱</summary>
    public DRKGauge? Gauge =>
        DService.Instance().JobGauges.Get<DRKGauge>();

    /// <summary>暗血值 (0-100)</summary>
    public byte BloodGauge => Gauge?.Blood ?? 0;

    /// <summary>血乱是否激活</summary>
    public bool HasDelirium =>
        _ctx.HasStatus(Delirium);

    /// <summary>嗜血是否激活</summary>
    public bool HasBloodWeapon =>
        _ctx.HasStatus(BloodWeapon);

    /// <summary>暗黑是否激活</summary>
    public bool HasDarkside =>
        _ctx.HasStatus(Darkside);
}