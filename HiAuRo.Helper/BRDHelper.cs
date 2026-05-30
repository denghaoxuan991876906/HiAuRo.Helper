
namespace HiAuRo.Helper;

/// <summary>
/// 诗人 (BRD) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class BRDHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                强力射击 = 97,
                直线射击 = 98,
                毒咬箭 = 100,
                猛者强击 = 101,
                连珠箭 = 106,
                纷乱箭 = 107,
                失血箭 = 110,
                后跃射击 = 112,
                风蚀箭 = 113,
                贤者的叙事谣 = 114,
                军神的赞美歌 = 116,
                死亡箭雨 = 117,
                战斗之声 = 118,
                九天连箭 = 3558,
                放浪神的小步舞曲 = 3559,
                伶牙俐齿 = 3560,
                光阴神的礼赞凯歌 = 3561,
                侧风诱导箭 = 3562,
                完美音调 = 7404,
                行吟 = 7405,
                烈毒咬箭 = 7406,
                狂风蚀箭 = 7407,
                大地神的抒情恋歌 = 7408,
                辉煌箭 = 7409,
                内丹 = 7541,
                亲疏自行 = 7548,
                伤头 = 7551,
                伤足 = 7553,
                伤腿 = 7554,
                速行 = 7557,
                影噬箭 = 16494,
                爆发射击 = 16495,
                绝峰箭 = 16496,
                百首龙牙箭 = 25783,
                爆破箭 = 25784,
                光明神的最终乐章 = 25785,
                广域群射 = 36974,
                碎心箭 = 36975,
                共鸣箭 = 36976,
                光明神的返场余音 = 36977;
        }

        public static class Buffs
        {
            public const uint
                直线射击预备 = 122,
                狂风蚀箭 = 1201,
                烈毒咬箭 = 1200,
                猛者强击 = 125,
                战斗之声 = 141,
                光明神的最终乐章 = 2722,
                纷乱箭 = 128,
                暗黑侵蚀 = 3122;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                HeavyShot = 97,
                StraightShot = 98,
                VenomousBite = 100,
                RagingStrikes = 101,
                QuickNock = 106,
                Barrage = 107,
                Bloodletter = 110,
                RepellingShot = 112,
                Windbite = 113,
                MagesBallad = 114,
                ArmysPaeon = 116,
                RainOfDeath = 117,
                BattleVoice = 118,
                EmpyrealArrow = 3558,
                TheWanderersMinuet = 3559,
                IronJaws = 3560,
                TheWardensPaean = 3561,
                Sidewinder = 3562,
                PitchPerfect = 7404,
                Troubadour = 7405,
                CausticBite = 7406,
                Stormbite = 7407,
                NaturesMinne = 7408,
                RefulgentArrow = 7409,
                SecondWind = 7541,
                ArmsLength = 7548,
                HeadGraze = 7551,
                FootGraze = 7553,
                LegGraze = 7554,
                Peloton = 7557,
                Shadowbite = 16494,
                BurstShot = 16495,
                ApexArrow = 16496,
                Ladonsbite = 25783,
                BlastArrow = 25784,
                RadiantFinale = 25785,
                WideVolley = 36974,
                HeartbreakShot = 36975,
                ResonantArrow = 36976,
                RadiantEncore = 36977;
        }

        public static class Buffs
        {
            public const uint
                StraightShotReady = 122,
                Stormbite = 1201,
                CausticBite = 1200,
                RagingStrikes = 125,
                BattleVoice = 141,
                RadiantFinale = 2722,
                Barrage = 128,
                DevouringDark = 3122;
        }
    }

    #endregion

    #region 技能 / Buff / DoT ID

    public const uint StraightShotReady = 122;
    public const uint StormbiteDot       = 1201;
    public const uint CausticBiteDot     = 1200;
    public const uint RagingStrikes      = 125;
    public const uint BattleVoice        = 141;
    public const uint RadiantFinale      = 2722;
    public const uint Barrage            = 128;
    public const uint HawkEye            = 3122;

    #endregion

    /// <summary>诗人职业量谱</summary>
    public static BRDGauge? Gauge => HelperRuntime.GetGauge<BRDGauge>();

    /// <summary>当前歌曲类型</summary>
    public static Song CurrentSong => Gauge?.Song ?? Song.None;

    /// <summary>歌曲剩余时间 (ms)</summary>
    public static ushort SongTimer => Gauge?.SongTimer ?? 0;

    /// <summary>乐章层数</summary>
    public static byte Repertoire => Gauge?.Repertoire ?? 0;

    /// <summary>灵魂之声值 (0-100)</summary>
    public static byte SoulVoice => Gauge?.SoulVoice ?? 0;

    /// <summary>是否在歌曲中</summary>
    public static bool InSong => CurrentSong != Song.None;

    /// <summary>直线射击预备是否激活</summary>
    public static bool HasStraightShotReady =>
        HelperRuntime.HasStatus(StraightShotReady);

    /// <summary>猛者强击是否激活</summary>
    public static bool HasRagingStrikes =>
        HelperRuntime.HasStatus(RagingStrikes);

    /// <summary>战斗之声是否激活</summary>
    public static bool HasBattleVoice =>
        HelperRuntime.HasStatus(BattleVoice);

    /// <summary>光明神的最终乐章是否激活</summary>
    public static bool HasRadiantFinale =>
        HelperRuntime.HasStatus(RadiantFinale);

    /// <summary>纷乱箭是否激活</summary>
    public static bool HasBarrage =>
        HelperRuntime.HasStatus(Barrage);

    /// <summary>鹰眼是否激活</summary>
    public static bool HasHawkEye =>
        HelperRuntime.HasStatus(HawkEye);

    /// <summary>目标上风蚀 DoT 是否激活</summary>
    public static bool HasStormbiteOnTarget =>
        HasDotOnTarget(StormbiteDot);

    /// <summary>目标上毒咬 DoT 是否激活</summary>
    public static bool HasCausticBiteOnTarget =>
        HasDotOnTarget(CausticBiteDot);

    private static bool HasDotOnTarget(uint statusId) => HelperRuntime.HasStatusOnTarget(statusId);
}