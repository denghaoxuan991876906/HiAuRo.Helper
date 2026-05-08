using OmenTools;
using Dalamud.Game.ClientState.JobGauge.Types;

namespace HiAuRo.Helper;

/// <summary>
/// 战士 (WAR) 职业入口 —— 技能/Buff ID 常量 + 状态查询
/// </summary>
public class WARHelper
{
    private readonly IHelperContext _ctx;

    public WARHelper(IHelperContext ctx) { _ctx = ctx; }

    #region 技能 ID 常量

    public static class Skills
    {
        public const uint
            牵制 = 7549,
            真北 = 7546,
            重劈 = 31,
            凶残裂 = 37,
            暴风斩 = 42,
            暴风碎 = 45,
            飞斧 = 46,
            超压斧 = 41,
            秘银旋风 = 16462,
            原初之魂 = 49,
            裂石飞环 = 3549,
            钢铁旋风 = 51,
            地毁人亡 = 3550,
            狂魂 = 16465,
            混沌旋风 = 16463,
            尽毁 = 36925,
            蛮荒崩裂 = 25753,
            狂暴 = 38,
            原初的解放 = 7389,
            守护 = 48,
            解除守护 = 32066,
            战栗 = 40,
            原初的直觉 = 3551,
            原初的血气 = 25751,
            原初的勇猛 = 16464,
            复仇 = 44,
            戮罪 = 36923,
            死斗 = 43,
            战嚎 = 52,
            泰然自若 = 3552,
            猛攻 = 7386,
            动乱 = 7387,
            摆脱 = 7388,
            群山隆起 = 25752,
            原初的怒震 = 36924,
            铁壁 = 7531,
            下踢 = 7540,
            挑衅 = 7533,
            插言 = 7538,
            雪仇 = 7535,
            退避 = 7537,
            亲疏自行 = 7548,
            内丹 = 7541,
            浴血 = 7542,
            醒梦 = 7562,
            冲刺 = 3;
    }

    #endregion

    #region Buff ID 常量

    public static class Buffs
    {
        public const uint
            红斩 = 2677,
            死斗 = 409,
            原初的混沌 = 1897,
            原初的解放 = 1177,
            原初的觉悟 = 2663,
            守护 = 91,
            原初的搏动 = 3833,
            尽毁预备 = 3834,
            蛮荒崩裂预备 = 2624,
            原初的怒震预备 = 3901,
            亲疏自行 = 1209,
            雪仇 = 1193,
            原初的血气 = 2678,
            原初的直觉 = 735,
            复仇 = 89,
            戮罪 = 3832,
            战栗 = 87,
            铁壁 = 1191,
            亲疏自行减伤 = 1984;
    }

    #endregion

    #region 内部 Buff ID

    private const uint _原初的解放 = 1177;
    private const uint _狂暴 = 86;
    private const uint _原初的混沌 = 1856;
    private const uint _红斩 = 2677;
    private const uint _战栗 = 87;
    private const uint _复仇 = 89;
    private const uint _死斗 = 88;
    private const uint _蛮荒崩裂预备 = 2624;
    private const uint _尽毁预备 = 3834;
    private const uint _原初的怒震预备 = 3901;
    private const uint _原初的血气 = 2678;
    private const uint _守护 = 91;
    private const uint _原初的觉悟 = 2663;

    #endregion

    #region 实例属性 — 状态查询

    public WARGauge? Gauge => DService.Instance().JobGauges.Get<WARGauge>();
    public byte BeastGauge => Gauge?.BeastGauge ?? 0;

    public bool HasInnerRelease => _ctx.HasStatus(_原初的解放);
    public bool HasBerserk => _ctx.HasStatus(_狂暴);
    public bool HasSurgingTempest => _ctx.HasStatus(_红斩);
    public bool HasNascentChaos => _ctx.HasStatus(_原初的混沌);

    public bool Has红斩 => _ctx.HasStatus(_红斩);
    public bool Has原初的解放 => _ctx.HasStatus(_原初的解放);
    public bool Has狂暴 => _ctx.HasStatus(_狂暴);
    public bool Has原初的混沌 => _ctx.HasStatus(_原初的混沌);
    public bool Has原初的觉悟 => _ctx.HasStatus(_原初的觉悟);
    public bool Has战栗 => _ctx.HasStatus(_战栗);
    public bool Has复仇 => _ctx.HasStatus(_复仇);
    public bool Has死斗 => _ctx.HasStatus(_死斗);
    public bool Has蛮荒崩裂预备 => _ctx.HasStatus(_蛮荒崩裂预备);
    public bool Has尽毁预备 => _ctx.HasStatus(_尽毁预备);
    public bool Has原初的怒震预备 => _ctx.HasStatus(_原初的怒震预备);
    public bool Has原初的血气 => _ctx.HasStatus(_原初的血气);
    public bool Has守护 => _ctx.HasStatus(_守护);

    #endregion
}
