namespace HiAuRo.Helper;

/// <summary>
/// 忍者 (NIN) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class NINHelper
{
    private readonly IHelperContext _ctx;
    public NINHelper(IHelperContext ctx) { _ctx = ctx; }

    private const uint Kassatsu = 497;           // 生杀予夺
    private const uint TenChiJin = 1186;         // 天地人
    private const uint Bunshin = 1954;           // 分身之术

    /// <summary>忍者职业量谱</summary>
    public NINGauge? Gauge => DService.Instance().JobGauges.Get<NINGauge>();

    /// <summary>忍气值</summary>
    public byte Ninki => Gauge?.Ninki ?? 0;

    /// <summary>是否拥有最大忍气</summary>
    public bool HasMaxNinki => Ninki >= 100;

    /// <summary>生杀予夺是否激活</summary>
    public bool HasKassatsu => _ctx.HasStatus(Kassatsu);

    /// <summary>天地人是否激活</summary>
    public bool HasTenChiJin => _ctx.HasStatus(TenChiJin);

    /// <summary>分身之术是否激活</summary>
    public bool HasBunshin => _ctx.HasStatus(Bunshin);
}