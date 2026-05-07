
namespace HiAuRo.Helper;

/// <summary>
/// 诗人 (BRD) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class BRDHelper
{
    private readonly IHelperContext _ctx;

    public BRDHelper(IHelperContext ctx)
    {
        _ctx = ctx;
    }

    #region 技能 / Buff / DoT ID

    private const uint StraightShotReady = 122;
    private const uint StormbiteDot       = 1201;
    private const uint CausticBiteDot     = 1200;
    private const uint RagingStrikes      = 125;
    private const uint BattleVoice        = 141;
    private const uint RadiantFinale      = 2722;
    private const uint Barrage            = 128;
    private const uint HawkEye            = 3122;

    #endregion

    /// <summary>诗人职业量谱</summary>
    public BRDGauge? Gauge =>
        DService.Instance().JobGauges.Get<BRDGauge>();

    /// <summary>当前歌曲类型</summary>
    public Song CurrentSong => Gauge?.Song ?? Song.None;

    /// <summary>歌曲剩余时间 (ms)</summary>
    public ushort SongTimer => Gauge?.SongTimer ?? 0;

    /// <summary>乐章层数</summary>
    public byte Repertoire => Gauge?.Repertoire ?? 0;

    /// <summary>灵魂之声值 (0-100)</summary>
    public byte SoulVoice => Gauge?.SoulVoice ?? 0;

    /// <summary>是否在歌曲中</summary>
    public bool InSong => CurrentSong != Song.None;

    /// <summary>直线射击预备是否激活</summary>
    public bool HasStraightShotReady =>
        _ctx.HasStatus(StraightShotReady);

    /// <summary>猛者强击是否激活</summary>
    public bool HasRagingStrikes =>
        _ctx.HasStatus(RagingStrikes);

    /// <summary>战斗之声是否激活</summary>
    public bool HasBattleVoice =>
        _ctx.HasStatus(BattleVoice);

    /// <summary>光明神的最终乐章是否激活</summary>
    public bool HasRadiantFinale =>
        _ctx.HasStatus(RadiantFinale);

    /// <summary>纷乱箭是否激活</summary>
    public bool HasBarrage =>
        _ctx.HasStatus(Barrage);

    /// <summary>鹰眼是否激活</summary>
    public bool HasHawkEye =>
        _ctx.HasStatus(HawkEye);

    /// <summary>目标上风蚀 DoT 是否激活</summary>
    public bool HasStormbiteOnTarget =>
        HasDotOnTarget(StormbiteDot);

    /// <summary>目标上毒咬 DoT 是否激活</summary>
    public bool HasCausticBiteOnTarget =>
        HasDotOnTarget(CausticBiteDot);

    private bool HasDotOnTarget(uint statusId) => _ctx.HasStatusOnTarget(statusId);
}