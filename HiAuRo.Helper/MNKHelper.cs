namespace HiAuRo.Helper;

/// <summary>
/// 武僧 (MNK) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class MNKHelper
{
    private readonly IHelperContext _ctx;
    public MNKHelper(IHelperContext ctx) { _ctx = ctx; }

    private const uint PerfectBalance = 110;     // 震脚
    private const uint RiddleOfFire = 1181;      // 红莲体势
    private const uint RiddleOfWind = 2587;      // 疾风体势
    private const uint Brotherhood = 1185;       // 义结金兰
    private const uint LeadenFist = 1861;        // 金刚体势 (buff)
    private const uint DisciplinedFist = 3001;   // 破坏神脚 (增伤buff)

    /// <summary>武僧职业量谱</summary>
    public MNKGauge? Gauge => DService.Instance().JobGauges.Get<MNKGauge>();

    /// <summary>查克拉数量</summary>
    public byte ChakraCount => Gauge?.Chakra ?? 0;

    /// <summary>是否拥有最大查克拉</summary>
    public bool HasMaxChakra => ChakraCount >= 5;

    /// <summary>震脚是否激活</summary>
    public bool HasPerfectBalance => _ctx.HasStatus(PerfectBalance);

    /// <summary>红莲体势是否激活</summary>
    public bool HasRiddleOfFire => _ctx.HasStatus(RiddleOfFire);

    /// <summary>疾风体势是否激活</summary>
    public bool HasRiddleOfWind => _ctx.HasStatus(RiddleOfWind);

    /// <summary>义结金兰是否激活</summary>
    public bool HasBrotherhood => _ctx.HasStatus(Brotherhood);

    /// <summary>金刚体势是否激活</summary>
    public bool HasLeadenFist => _ctx.HasStatus(LeadenFist);

    /// <summary>破坏神脚增伤buff是否激活</summary>
    public bool HasDisciplinedFist => _ctx.HasStatus(DisciplinedFist);
}