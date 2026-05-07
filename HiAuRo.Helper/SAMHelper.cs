namespace HiAuRo.Helper;

/// <summary>
/// 武士 (SAM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SAMHelper
{
    private readonly IHelperContext _ctx;
    public SAMHelper(IHelperContext ctx) { _ctx = ctx; }

    private const uint MeikyoShisui = 1233;      // 明镜止水
    private const uint Higanbana = 1228;         // 彼岸花 (DoT)
    private const uint Jinpu = 1298;             // 阵风 (buff)
    private const uint Shifu = 1299;             // 士风 (buff)
    private const uint Ikishoten = 1884;         // 意气冲天
    private const uint OgiNamikiriReady = 2951;  // 奥义斩浪预备
    private const uint TsubameGaeshiReady = 1239; // 燕飞 (回返彼岸花预备)

    /// <summary>武士职业量谱</summary>
    public SAMGauge? Gauge => DService.Instance().JobGauges.Get<SAMGauge>();

    /// <summary>剑气值</summary>
    public int Kenki => Gauge?.Kenki ?? 0;

    /// <summary>冥想层数</summary>
    public byte MeditationStacks => Gauge?.MeditationStacks ?? 0;

    /// <summary>是否拥有雪之闪</summary>
    public bool HasSetsu => Gauge?.HasSetsu ?? false;

    /// <summary>是否拥有月之闪</summary>
    public bool HasGetsu => Gauge?.HasGetsu ?? false;

    /// <summary>是否拥有花之闪</summary>
    public bool HasKa => Gauge?.HasKa ?? false;

    /// <summary>明镜止水是否激活</summary>
    public bool HasMeikyoShisui => _ctx.HasStatus(MeikyoShisui);

    /// <summary>彼岸花DoT是否激活</summary>
    public bool HasHiganbana => _ctx.HasStatus(Higanbana);

    /// <summary>阵风是否激活</summary>
    public bool HasJinpu => _ctx.HasStatus(Jinpu);

    /// <summary>士风是否激活</summary>
    public bool HasShifu => _ctx.HasStatus(Shifu);

    /// <summary>意气冲天是否激活</summary>
    public bool HasIkishoten => _ctx.HasStatus(Ikishoten);

    /// <summary>奥义斩浪预备是否激活</summary>
    public bool HasOgiNamikiriReady => _ctx.HasStatus(OgiNamikiriReady);

    /// <summary>回返彼岸花预备是否激活</summary>
    public bool HasTsubameGaeshiReady => _ctx.HasStatus(TsubameGaeshiReady);

    /// <summary>是否拥有全部三闪 (雪/月/花)</summary>
    public bool HasAllThreeSen => HasSetsu && HasGetsu && HasKa;
}