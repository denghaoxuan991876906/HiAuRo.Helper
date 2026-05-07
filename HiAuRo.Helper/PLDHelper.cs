
namespace HiAuRo.Helper;

/// <summary>
/// 骑士 (PLD) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class PLDHelper
{
    private readonly IHelperContext _ctx;

    public PLDHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff ID

    private const uint Requiescat          = 1368;   // 安魂祈祷
    private const uint FightOrFlight       = 76;     // 战逃反应
    private const uint DivineMight         = 2673;   // 圣光之力 (赎罪剑预备)
    private const uint HolySheltron        = 2674;   // 圣盾阵
    private const uint Sentinel            = 74;     // 预警
    private const uint HallowedGround      = 82;     // 神圣领域
    private const uint Cover               = 80;     // 保护

    #endregion

    /// <summary>骑士职业量谱</summary>
    public PLDGauge? Gauge =>
        DService.Instance().JobGauges.Get<PLDGauge>();

    /// <summary>忠义值 (0-100)</summary>
    public byte OathGauge => Gauge?.OathGauge ?? 0;

    /// <summary>安魂祈祷是否激活</summary>
    public bool HasRequiescat =>
        _ctx.HasStatus(Requiescat);

    /// <summary>战逃反应是否激活</summary>
    public bool HasFightOrFlight =>
        _ctx.HasStatus(FightOrFlight);

    /// <summary>圣光之力 (赎罪剑预备) 是否激活</summary>
    public bool HasDivineMight =>
        _ctx.HasStatus(DivineMight);
}