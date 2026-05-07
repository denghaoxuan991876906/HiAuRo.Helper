
namespace HiAuRo.Helper;

/// <summary>
/// 赤魔法师 (RDM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class RDMHelper
{
    private readonly IHelperContext _ctx;

    public RDMHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff ID

    private const uint Embolden = 2282;        // 鼓励
    private const uint Manafication = 1971;    // 倍增
    private const uint Acceleration = 1238;    // 促进
    private const uint VerstoneReady = 1235;   // 赤飞石预备
    private const uint VerfireReady = 1234;    // 赤火炎预备
    private const uint MagickBarrier = 2574;   // 抗死

    #endregion

    /// <summary>赤魔法师职业量谱</summary>
    public RDMGauge? Gauge => DService.Instance().JobGauges.Get<RDMGauge>();

    /// <summary>白魔元 (0-100)</summary>
    public byte WhiteMana => Gauge?.WhiteMana ?? 0;

    /// <summary>黑魔元 (0-100)</summary>
    public byte BlackMana => Gauge?.BlackMana ?? 0;

    /// <summary>魔元集层数</summary>
    public byte ManaStacks => Gauge?.ManaStacks ?? 0;

    /// <summary>是否可以发动近战连击 (黑白魔元均 >= 50)</summary>
    public bool CanMeleeCombo => WhiteMana >= 50 && BlackMana >= 50;

    /// <summary>鼓励是否激活</summary>
    public bool HasEmbolden => _ctx.HasStatus(Embolden);

    /// <summary>倍增是否激活</summary>
    public bool HasManafication => _ctx.HasStatus(Manafication);

    /// <summary>促进是否激活</summary>
    public bool HasAcceleration => _ctx.HasStatus(Acceleration);

    /// <summary>赤飞石预备是否激活</summary>
    public bool HasVerstoneReady => _ctx.HasStatus(VerstoneReady);

    /// <summary>赤火炎预备是否激活</summary>
    public bool HasVerfireReady => _ctx.HasStatus(VerfireReady);
}