
namespace HiAuRo.Helper;

/// <summary>
/// 学者 (SCH) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class SCHHelper
{
    private readonly IHelperContext _ctx;

    public SCHHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff / DoT ID

    private const uint ChainStratagem = 1221;     // 连环计
    private const uint Biolysis = 1895;           // 蛊毒法 (DoT)
    private const uint SacredSoil = 188;          // 野战治疗阵 (buff)
    private const uint Excogitation = 1220;       // 深谋远虑之策
    private const uint Recitation = 1896;         // 转化
    private const uint Expedient = 2713;          // 疾风怒涛之计
    private const uint Seraphism = 3714;          // 炽天炽翼

    #endregion

    /// <summary>学者职业量谱</summary>
    public SCHGauge? Gauge =>
        DService.Instance().JobGauges.Get<SCHGauge>();

    /// <summary>以太超流层数</summary>
    public byte AetherflowCount => Gauge?.Aetherflow ?? 0;

    /// <summary>是否拥有以太超流</summary>
    public bool HasAetherflow => AetherflowCount > 0;

    /// <summary>连环计是否激活</summary>
    public bool HasChainStratagem =>
        _ctx.HasStatus(ChainStratagem);

    /// <summary>转化是否激活</summary>
    public bool HasRecitation =>
        _ctx.HasStatus(Recitation);

    /// <summary>疾风怒涛之计是否激活</summary>
    public bool HasExpedient =>
        _ctx.HasStatus(Expedient);

    /// <summary>炽天炽翼是否激活</summary>
    public bool HasSeraphism =>
        _ctx.HasStatus(Seraphism);
}