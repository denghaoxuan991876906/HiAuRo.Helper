
namespace HiAuRo.Helper;

/// <summary>
/// 黑魔法师 (BLM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class BLMHelper
{
    private readonly IHelperContext _ctx;

    public BLMHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff ID

    private const uint Enochian = 868;           // 天语
    private const uint LeyLines = 737;           // 黑魔纹
    private const uint Thunder3 = 163;           // 暴雷 (DoT)
    private const uint Triplecast = 1211;        // 三连咏唱
    private const uint Manafont = 158;           // 魔泉
    private const uint Sharpcast = 867;          // 激情咏唱
    private const uint Amplifier = 2968;         // 详述 (buff — Polyglot gain)
    private const uint ParadoxReady = 2981;      // 悖论预备

    #endregion

    /// <summary>黑魔法师职业量谱</summary>
    public BLMGauge? Gauge => DService.Instance().JobGauges.Get<BLMGauge>();

    /// <summary>是否处于星极火状态</summary>
    public bool InAstralFire => Gauge?.InAstralFire ?? false;

    /// <summary>是否处于冰澈状态</summary>
    public bool InUmbralIce => Gauge?.InUmbralIce ?? false;

    /// <summary>冰脉层数</summary>
    public byte UmbralHearts => Gauge?.UmbralHearts ?? 0;

    /// <summary>悖论充能层数</summary>
    public byte PolyglotStacks => Gauge?.PolyglotStacks ?? 0;

    /// <summary>是否有悖论充能</summary>
    public bool HasPolyglot => PolyglotStacks > 0;

    /// <summary>天语是否激活</summary>
    public bool HasEnochian => _ctx.HasStatus(Enochian);

    /// <summary>黑魔纹是否激活</summary>
    public bool HasLeyLines => _ctx.HasStatus(LeyLines);

    /// <summary>三连咏唱是否激活</summary>
    public bool HasTriplecast => _ctx.HasStatus(Triplecast);

    /// <summary>激情咏唱是否激活</summary>
    public bool HasSharpcast => _ctx.HasStatus(Sharpcast);
}