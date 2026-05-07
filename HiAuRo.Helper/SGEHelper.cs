
namespace HiAuRo.Helper;

/// <summary>
/// 贤者 (SGE) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SGEHelper
{
    private readonly IHelperContext _ctx;

    public SGEHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff / DoT ID

    private const uint Eukrasia = 2429;           // 均衡
    private const uint Kardia = 2428;             // 心关 (buff on target)
    private const uint Physis = 2427;             // 自生 (buff)
    private const uint Krasis = 2430;             // 活化 (buff on target)
    private const uint Haima = 2432;              // 泛输血
    private const uint Panhaima = 2433;           // 整体论
    private const uint Pneuma = 2434;             // 魂灵风息
    private const uint EukrasianDosis = 2614;     // 均衡注药 (DoT)

    #endregion

    /// <summary>贤者职业量谱</summary>
    public SGEGauge? Gauge =>
        DService.Instance().JobGauges.Get<SGEGauge>();

    /// <summary>蛇刺数量</summary>
    public byte AdderstingCount => Gauge?.Addersting ?? 0;

    /// <summary>是否拥有均衡状态</summary>
    public bool HasEukrasia => Gauge?.Eukrasia ?? false;

    /// <summary>均衡状态是否激活</summary>
    public bool HasEukrasiaStatus =>
        _ctx.HasStatus(Eukrasia);

    /// <summary>泛输血是否激活</summary>
    public bool HasHaima =>
        _ctx.HasStatus(Haima);

    /// <summary>整体论是否激活</summary>
    public bool HasPanhaima =>
        _ctx.HasStatus(Panhaima);

    /// <summary>自生是否激活</summary>
    public bool HasPhysis =>
        _ctx.HasStatus(Physis);
}