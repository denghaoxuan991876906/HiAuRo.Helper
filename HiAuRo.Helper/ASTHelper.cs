namespace HiAuRo.Helper;

//请勿修改CN部分的代码，EN部分的skill&status为机翻，自行补充原版EN名！
public class ASTHelper
{
    #region CN 技能ID / BuffID

    public static class CN
    {
        public static class Skills
        {
            public const uint
                吉星 = 3594,
                吉星相位 = 3595,
                凶星 = 3596,
                灾星 = 3598,
                烧灼 = 3599,
                阳星 = 3600,
                阳星相位 = 3601,
                生辰 = 3603,
                光速 = 3606,
                炽灼 = 3608,
                福星 = 3610,
                星位合图 = 3612,
                命运之轮 = 3613,
                先天禀赋 = 3614,
                重力 = 3615,
                地星 = 7439,
                祸星 = 7442,
                王冠之领主 = 7444,
                王冠之贵妇 = 7445,
                沉稳咏唱 = 7559,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                康复 = 7568,
                营救 = 7571,
                星体爆轰 = 8324,
                占卜 = 16552,
                天星冲日 = 16553,
                焚灼 = 16554,
                煞星 = 16555,
                天星交错 = 16556,
                天宫图 = 16557,
                天宫图激活 = 16558,
                中间学派 = 16559,
                沉静 = 16560,
                落陷凶星 = 25871,
                中重力 = 25872,
                擢升 = 25873,
                大宇宙 = 25874,
                小宇宙 = 25875,
                星极抽卡 = 37017,
                灵极抽卡 = 37018,
                出卡I = 37019,
                出卡II = 37020,
                出卡III = 37021,
                小奥秘卡 = 37022,
                太阳神之衡 = 37023,
                放浪神之箭 = 37024,
                建筑神之塔 = 37025,
                战争神之枪 = 37026,
                世界树之干 = 37027,
                河流神之瓶 = 37028,
                神谕 = 37029,
                阳星合相 = 37030,
                太阳星座 = 37031;
        }

        public static class Buffs
        {
            public const uint
                吉星相位 = 835,
                烧灼 = 838,
                光速 = 841,
                炽灼 = 843,
                阳星相位 = 836,
                星位合图自己 = 845,
                星位合图他人 = 846,
                命运之轮 = 848,
                命运之轮减伤 = 849,
                命运之轮恢复 = 956,
                地星主宰 = 1224,
                巨星主宰 = 1248,
                王冠之领主 = 1451,
                王冠之贵妇 = 1452,
                占卜 = 1878,
                天星冲日 = 1879,
                焚灼 = 1881,
                天星交错 = 1889,
                天宫图 = 1890,
                阳星天宫图 = 1891,
                中间学派 = 1892,
                中间学派盾 = 1921,
                擢升 = 2717,
                大宇宙 = 2718,
                太阳神之衡 = 3887,
                放浪神之箭 = 3888,
                战争神之枪 = 3889,
                世界树之干 = 3890,
                河流神之瓶 = 3891,
                建筑神之塔 = 3892,
                神谕预备 = 3893,
                阳星合相 = 3894,
                太阳星座预备 = 3895,
                太阳星座 = 3896,
                星体破裂 = 7440,
                星体爆炸 = 7441;
        }
    }

    #endregion

    #region 原版技能ID / BuffID

    public static class EN
    {
        public static class Skills
        {
            public const uint
                Benefic = 3594,
                AspectedBenefic = 3595,
                Malefic = 3596,
                MaleficII = 3598,
                Combust = 3599,
                Helios = 3600,
                AspectedHelios = 3601,
                Ascend = 3603,
                Lightspeed = 3606,
                CombustII = 3608,
                BeneficII = 3610,
                Synastry = 3612,
                CollectiveUnconscious = 3613,
                EssentialDignity = 3614,
                Gravity = 3615,
                EarthlyStar = 7439,
                MaleficIII = 7442,
                LordOfCrowns = 7444,
                LadyOfCrowns = 7445,
                Surecast = 7559,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                Esuna = 7568,
                Rescue = 7571,
                StellarDetonation = 8324,
                Divination = 16552,
                CelestialOpposition = 16553,
                CombustIII = 16554,
                MaleficIV = 16555,
                CelestialIntersection = 16556,
                Horoscope = 16557,
                HoroscopeActivation = 16558,
                NeutralSect = 16559,
                Repose = 16560,
                FallMalefic = 25871,
                GravityII = 25872,
                Exaltation = 25873,
                Macrocosmos = 25874,
                Microcosmos = 25875,
                AstralDraw = 37017,
                UmbralDraw = 37018,
                PlayI = 37019,
                PlayII = 37020,
                PlayIII = 37021,
                MinorArcana = 37022,
                TheBalance = 37023,
                TheArrow = 37024,
                TheSpire = 37025,
                TheSpear = 37026,
                TheBole = 37027,
                TheEwer = 37028,
                Oracle = 37029,
                HeliosConjunction = 37030,
                SunSign = 37031;
        }

        public static class Buffs
        {
            public const uint
                AspectedBenefic = 835,
                Combust = 838,
                Lightspeed = 841,
                CombustII = 843,
                AspectedHelios = 836,
                SynastrySelf = 845,
                SynastryTarget = 846,
                CollectiveUnconscious = 848,
                CollectiveUnconsciousMitigation = 849,
                WheelOfFortune = 956,
                EarthlyDominance = 1224,
                GiantDominance = 1248,
                LordOfCrowns = 1451,
                LadyOfCrowns = 1452,
                Divination = 1878,
                CelestialOpposition = 1879,
                CombustIII = 1881,
                CelestialIntersection = 1889,
                Horoscope = 1890,
                HoroscopeHelios = 1891,
                NeutralSect = 1892,
                NeutralSectShield = 1921,
                Exaltation = 2717,
                Macrocosmos = 2718,
                TheBalance = 3887,
                TheArrow = 3888,
                TheSpear = 3889,
                TheBole = 3890,
                TheEwer = 3891,
                TheSpire = 3892,
                OracleReady = 3893,
                HeliosConjunction = 3894,
                SunSignReady = 3895,
                SunSign = 3896,
                StellarBurst = 7440,
                StellarExplosion = 7441;
        }
    }

    #endregion

    #region 量谱 / 卡牌

    public static ASTGauge? 占星量谱 => HelperRuntime.GetGauge<ASTGauge>();
    public static CardType[] 已抽卡牌 => 占星量谱?.DrawnCards.ToArray() ?? [CardType.None, CardType.None, CardType.None];
    public static CardType 小奥秘卡 => 占星量谱?.DrawnCrownCard ?? CardType.None;
    public static DrawType? 当前抽卡类型 => 占星量谱?.ActiveDraw;

    public static CardType 获取卡牌(int slotIndex)
    {
        var cards = 已抽卡牌;
        return slotIndex >= 0 && slotIndex < cards.Length ? cards[slotIndex] : CardType.None;
    }

    #endregion

    #region 状态判断

    public static bool 占卜是否激活 => HelperRuntime.HasStatus(CN.Buffs.占卜);
    public static bool 光速是否激活 => HelperRuntime.HasStatus(CN.Buffs.光速);
    public static bool 中间学派是否激活 => HelperRuntime.HasStatus(CN.Buffs.中间学派);

    #endregion

    #region 动态技能

    public static uint 当前抽卡技能 => 当前抽卡类型 switch
    {
        DrawType.Umbral => CN.Skills.灵极抽卡,
        DrawType.Astral => CN.Skills.星极抽卡,
        _ => HelperRuntime.GetActionChange(CN.Skills.星极抽卡)
    };

    public static uint 获取出卡技能(int slotIndex) => 获取卡牌(slotIndex) switch
    {
        CardType.Balance => CN.Skills.太阳神之衡,
        CardType.Arrow => CN.Skills.放浪神之箭,
        CardType.Spire => CN.Skills.建筑神之塔,
        CardType.Spear => CN.Skills.战争神之枪,
        CardType.Bole => CN.Skills.世界树之干,
        CardType.Ewer => CN.Skills.河流神之瓶,
        _ => slotIndex switch
        {
            0 => HelperRuntime.GetActionChange(CN.Skills.出卡I),
            1 => HelperRuntime.GetActionChange(CN.Skills.出卡II),
            2 => HelperRuntime.GetActionChange(CN.Skills.出卡III),
            _ => 0
        }
    };

    public static uint 获取等级变化的技能(uint 技能ID) => 技能ID switch
    {
        CN.Skills.落陷凶星 or CN.Skills.煞星 or CN.Skills.祸星 or CN.Skills.灾星 or CN.Skills.凶星 => HelperRuntime.GetCurrentLevel() switch
        {
            >= 82 => CN.Skills.落陷凶星,
            >= 72 => CN.Skills.煞星,
            >= 64 => CN.Skills.祸星,
            >= 54 => CN.Skills.灾星,
            _ => CN.Skills.凶星
        },
        CN.Skills.焚灼 or CN.Skills.炽灼 or CN.Skills.烧灼 => HelperRuntime.GetCurrentLevel() switch
        {
            >= 72 => CN.Skills.焚灼,
            >= 46 => CN.Skills.炽灼,
            _ => CN.Skills.烧灼
        },
        CN.Skills.中重力 or CN.Skills.重力 => HelperRuntime.GetCurrentLevel() >= 82 ? CN.Skills.中重力 : CN.Skills.重力,
        CN.Skills.阳星合相 or CN.Skills.阳星相位 => HelperRuntime.GetCurrentLevel() >= 96 ? CN.Skills.阳星合相 : CN.Skills.阳星相位,
        CN.Skills.福星 => HelperRuntime.GetCurrentLevel() >= 26 ? CN.Skills.福星 : CN.Skills.吉星,
        _ => 技能ID
    };

    #endregion
}
