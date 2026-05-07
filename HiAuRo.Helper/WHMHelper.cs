
namespace HiAuRo.Helper;

/// <summary>
/// 白魔法师 (WHM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class WHMHelper
{
    private readonly IHelperContext _ctx;

    public WHMHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff / DoT ID

    private const uint PresenceOfMind = 157;      // 神速咏唱
    private const uint ThinAir = 1217;            // 无中生有
    private const uint Temperance = 1873;         // 节制
    private const uint Regen = 158;               // 再生 (buff)
    private const uint Medica2 = 150;             // 医济 (buff)
    private const uint DivineBenison = 1218;      // 神祝祷
    private const uint Aquaveil = 2704;           // 水流幕
    private const uint LiturgyOfTheBell = 2851;   // 礼仪之铃

    #endregion

    /// <summary>白魔法师职业量谱</summary>
    public WHMGauge? Gauge =>
        DService.Instance().JobGauges.Get<WHMGauge>();

    /// <summary>百合数量</summary>
    public byte LilyCount => Gauge?.Lily ?? 0;

    /// <summary>血百合数量</summary>
    public byte BloodLilyCount => Gauge?.BloodLily ?? 0;

    /// <summary>神速咏唱是否激活</summary>
    public bool HasPresenceOfMind =>
        _ctx.HasStatus(PresenceOfMind);

    /// <summary>无中生有是否激活</summary>
    public bool HasThinAir =>
        _ctx.HasStatus(ThinAir);

    /// <summary>节制是否激活</summary>
    public bool HasTemperance =>
        _ctx.HasStatus(Temperance);

    /// <summary>是否有百合可用</summary>
    public bool HasLilyReady => LilyCount > 0;

    /// <summary>是否有血百合可用</summary>
    public bool HasBloodLilyReady => BloodLilyCount >= 3;
}