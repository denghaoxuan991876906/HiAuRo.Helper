namespace HiAuRo.Helper;

/// <summary>
/// 钐镰客 (RPR) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class RPRHelper
{
    private readonly IHelperContext _ctx;
    public RPRHelper(IHelperContext ctx) { _ctx = ctx; }

    private const uint ArcaneCircle = 2577;      // 神秘环
    private const uint SoulSow = 2591;           // 播魂种 (buff)
    private const uint Enshrouded = 2593;        // 夜游魂 (附体buff)

    /// <summary>钐镰客职业量谱</summary>
    public RPRGauge? Gauge => DService.Instance().JobGauges.Get<RPRGauge>();

    /// <summary>魂量值</summary>
    public byte SoulGauge => Gauge?.Soul ?? 0;

    /// <summary>遮蔽值</summary>
    public byte ShroudGauge => Gauge?.Shroud ?? 0;

    /// <summary>是否可以进入夜游魂附体 (需要50遮蔽)</summary>
    public bool CanEnshroud => ShroudGauge >= 50;

    /// <summary>神秘环是否激活</summary>
    public bool HasArcaneCircle => _ctx.HasStatus(ArcaneCircle);

    /// <summary>播魂种是否激活</summary>
    public bool HasSoulSow => _ctx.HasStatus(SoulSow);

    /// <summary>夜游魂附体是否激活</summary>
    public bool HasEnshrouded => _ctx.HasStatus(Enshrouded);
}