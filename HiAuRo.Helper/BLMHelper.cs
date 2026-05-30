
namespace HiAuRo.Helper;

/// <summary>
/// 黑魔法师 (BLM) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class BLMHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)
    public static class CN
    {
        public static class Skills
        {
            public const uint
                火炎 = 141,
                冰结 = 142,
                闪雷 = 144,
                烈炎 = 147,
                星灵移位 = 149,
                爆炎 = 152,
                暴雷 = 153,
                冰封 = 154,
                以太步 = 155,
                崩溃 = 156,
                魔罩 = 157,
                魔泉 = 158,
                玄冰 = 159,
                核爆 = 162,
                黑魔纹 = 3573,
                冰澈 = 3576,
                炽炎 = 3577,
                魔纹步 = 7419,
                霹雷 = 7420,
                三连咏唱 = 7421,
                秽浊 = 7422,
                震雷 = 7447,
                沉稳咏唱 = 7559,
                昏乱 = 7560,
                即刻咏唱 = 7561,
                醒梦 = 7562,
                绝望 = 16505,
                灵极魂 = 16506,
                异言 = 16507,
                冰冻 = 25793,
                高烈炎 = 25794,
                高冰冻 = 25795,
                详述 = 25796,
                悖论 = 25797,
                催眠 = 25880,
                高闪雷 = 36986,
                高震雷 = 36987,
                魔纹重置 = 36988,
                耀星 = 36989;
        }

        public static class Buffs
        {
            public const uint 醒梦 = 1204,
                              即刻咏唱 = 167,
                              沉稳咏唱 = 160,
                              魔罩 = 168,
                              三连咏唱 = 1211,
                              云砧 = 3870,
                              火苗 = 165,
                              黑魔纹 = 737,
                              魔纹环 = 738,
                              高闪雷 = 3871,
                              高震雷 = 3872,
                              暴雷 = 163,
                              霹雷 = 1210;
        }
    }
    #endregion
    #region EN — English Names (verified via xivapi-v2.xivcdn.com)
    public static class EN
    {
        public static class Skills
        {
            public const uint
                Fire = 141,
                Blizzard = 142,
                Thunder = 144,
                FireII = 147,
                Transpose = 149,
                FireIII = 152,
                ThunderIII = 153,
                BlizzardIII = 154,
                AetherialManipulation = 155,
                Scathe = 156,
                Manaward = 157,
                Manafont = 158,
                Freeze = 159,
                Flare = 162,
                LeyLines = 3573,
                BlizzardIV = 3576,
                FireIV = 3577,
                BetweenTheLines = 7419,
                ThunderIV = 7420,
                Triplecast = 7421,
                Foul = 7422,
                ThunderII = 7447,
                Surecast = 7559,
                Addle = 7560,
                Swiftcast = 7561,
                LucidDreaming = 7562,
                Despair = 16505,
                UmbralSoul = 16506,
                Xenoglossy = 16507,
                BlizzardII = 25793,
                HighFireII = 25794,
                HighBlizzardII = 25795,
                Amplifier = 25796,
                Paradox = 25797,
                Sleep = 25880,
                HighThunder = 36986,
                HighThunderII = 36987,
                Retrace = 36988,
                FlareStar = 36989;
        }

        public static class Buffs
        {
            public const uint LucidDreaming = 1204,
                              Swiftcast = 167,
                              Surecast = 160,
                              Manaward = 168,
                              Triplecast = 1211,
                              Thunderhead = 3870,
                              Firestarter = 165,
                              LeyLines = 737,
                              CircleOfPower = 738,
                              HighThunder = 3871,
                              HighThunderII = 3872,
                              ThunderIII = 163,
                              ThunderIV = 1210;
        }
    }
    #endregion

    #region 技能

    public const uint 冰结 = 142;
    public const uint 火炎 = 141;
    public const uint 崩溃 = 156;
    public const uint 爆炎 = 152;
    public const uint 冰封 = 154;
    public const uint 灵极魂 = 16506;
    public const uint 玄冰 = 159;
    public const uint 核爆 = 162;
    public const uint 冰澈 = 3576;
    public const uint 炽焰 = 3577;
    public const uint 秽浊 = 7422;
    public const uint 绝望 = 16505;
    public const uint 异言 = 16507;
    public const uint 高烈炎 = 25794;
    public const uint 高冰冻 = 25795;
    public const uint 烈炎 = 147;
    public const uint 冰冻 = 25793;
    public const uint 高闪雷 = 36986;
    public const uint 高震雷 = 36987;
    public const uint 闪雷 = 144;
    public const uint 暴雷 = 153;
    public const uint 震雷 = 7447;
    public const uint 霹雷 = 7420;
    public const uint 耀星 = 36989;
    public const uint 悖论 = 25797;
    public const uint 催眠 = 25880;

    public const uint 星灵移位 = 149;
    public const uint 魔罩 = 157;
    public const uint 魔泉 = 158;
    public const uint 以太步 = 155;
    public const uint 黑魔纹 = 3573;
    public const uint 魔纹步 = 7419;
    public const uint 三连咏唱 = 7421;
    public const uint 详述 = 25796;
    public const uint 魔纹重置 = 36988;
    public const uint 昏乱 = 7560;
    public const uint 醒梦 = 7562;
    public const uint 即可咏唱 = 7561;
    public const uint 沉稳咏唱 = 7559;

    #endregion

    #region BUFF

    public const uint 醒梦buff = 1204;
    public const uint 即刻buff = 167;
    public const uint 沉稳buff = 160;
    public const uint 魔罩buff = 168;
    public const uint 三连buff = 1211;
    public const uint 雷云buff = 3870;
    public const uint 火苗buff = 165;
    public const uint 魔纹存在buff = 737;
    public const uint 魔纹加速buff = 738;

    #endregion

    #region BUFF检测

    public static bool Has醒梦 => HelperRuntime.HasStatus(醒梦buff);
    public static bool Has即刻 => HelperRuntime.HasStatus(即刻buff);
    public static bool Has沉稳 => HelperRuntime.HasStatus(沉稳buff);
    public static bool Has魔罩 => HelperRuntime.HasStatus(魔罩buff);
    public static bool Has三连 => HelperRuntime.HasStatus(三连buff);
    public static bool Has雷云 => HelperRuntime.HasStatus(雷云buff);
    public static bool Has火苗 => HelperRuntime.HasStatus(火苗buff);
    public static bool Has魔纹存在 => HelperRuntime.HasStatus(魔纹存在buff);
    public static bool Has魔纹加速 => HelperRuntime.HasStatus(魔纹加速buff);

    #endregion

    #region 辅助方法

    public static bool 可瞬发 => Has即刻 || Has三连;

    public static bool 补dot()
    {
        var level = HelperRuntime.GetCurrentLevel();
        if (level >= 92)
        {
            var time = Math.Max(HelperRuntime.GetStatusTimeLeftOnTarget(3871), HelperRuntime.GetStatusTimeLeftOnTarget(3872));
            return time < 3f;
        }
        if (level >= 45)
        {
            var time = Math.Max(HelperRuntime.GetStatusTimeLeftOnTarget(163), HelperRuntime.GetStatusTimeLeftOnTarget(1210));
            return time < 3f;
        }
        return false;
    }

    public static bool 三目标aoe()
    {
        return HelperRuntime.GetEnemyCountNearTarget(5) >= 3;
    }

    public static bool 双目标aoe()
    {
        var count = HelperRuntime.GetEnemyCountNearTarget(5);
        return count >= 2 && count < 3;
    }

    public static bool 群怪模式 => 三目标aoe() || 双目标aoe();

    public static uint 冰火状态()
    {
        if (冰状态) return 1;
        if (火状态) return 2;
        return 0;
    }

    #endregion
    
    /// <summary>黑魔法师职业量谱</summary>
    public static BLMGauge Gauge => HelperRuntime.GetGauge<BLMGauge>();

    /// <summary>是否处于星极火状态</summary>
    public static bool 火状态 => Gauge.InAstralFire;
    
    public static bool 冰状态 => Gauge.InUmbralIce;

    public static uint 火层数 => Gauge.AstralFireStacks;
    public static uint 冰层数 => Gauge.UmbralIceStacks;
    public static uint 冰针数 => Gauge.UmbralHearts;
    public static int 耀星层数 => Gauge.AstralSoulStacks;
    public static uint 通晓数 => Gauge.PolyglotStacks;
    public static bool 悖论指示 => Gauge.IsParadoxActive;
    public static bool 天语状态 => Gauge.IsEnochianActive;
    public static short 通晓计时 => Gauge.EnochianTimer;
    
}