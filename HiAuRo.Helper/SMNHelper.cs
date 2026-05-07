
namespace HiAuRo.Helper;

/// <summary>
/// 召唤师 (SMN) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SMNHelper
{
    private readonly IHelperContext _ctx;

    public SMNHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff ID

    private const uint SearingLight = 2703;       // 灼热之光
    private const uint Aethercharge = 2582;       // 以太蓄能 (buff)
    private const uint DreadwyrmTrance = 2584;    // 龙神附体 (buff)
    private const uint SummonBahamut = 2585;      // 不死鸟附体 (buff after Bahamut)
    private const uint RadiantAegis = 2700;       // 守护之光 (shield)
    private const uint EverlastingFlight = 2586;  // 不死鸟之翼

    #endregion

    /// <summary>召唤师职业量谱</summary>
    public SMNGauge? Gauge => DService.Instance().JobGauges.Get<SMNGauge>();

    /// <summary>是否处于巴哈/不死鸟附体状态</summary>
    public bool IsInBahamut => Gauge?.SummonTimerRemaining > 0;

    /// <summary>灼热之光是否激活</summary>
    public bool HasSearingLight => _ctx.HasStatus(SearingLight);

    /// <summary>以太蓄能是否激活</summary>
    public bool HasAethercharge => _ctx.HasStatus(Aethercharge);

    /// <summary>龙神附体是否激活</summary>
    public bool HasDreadwyrmTrance => _ctx.HasStatus(DreadwyrmTrance);
}