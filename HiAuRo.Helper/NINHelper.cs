namespace HiAuRo.Helper;

/// <summary>
/// 忍者 (NIN) 职业快捷入口 —— 常用状态短路径
/// </summary>
public class NINHelper
{

    #region CN — 中文名称 (verified via xivapi-v2.xivcdn.com)

    public static class CN
    {
        public static class Skills
        {
            public const uint
                双刃旋 = 2240,
                残影 = 2241,
                绝风 = 2242,
                隐遁 = 2245,
                断绝 = 2246,
                飞刀 = 2247,
                夺取 = 2248,
                血雨飞花 = 2254,
                旋风刃 = 2255,
                攻其不备 = 2258,
                天之印 = 2259,
                忍术 = 2260,
                地之印 = 2261,
                缩地 = 2262,
                人之印 = 2263,
                生杀予夺 = 2264,
                风魔手里剑 = 2265,
                火遁之术 = 2266,
                雷遁之术 = 2267,
                冰遁之术 = 2268,
                风遁之术 = 2269,
                土遁之术 = 2270,
                水遁之术 = 2271,
                通灵之术 = 2272,
                强甲破点突 = 3563,
                梦幻三段 = 3566,
                通灵之术_大虾蟆 = 7401,
                六道轮回 = 7402,
                天地人 = 7403,
                内丹 = 7541,
                浴血 = 7542,
                真北 = 7546,
                亲疏自行 = 7548,
                牵制 = 7549,
                扫腿 = 7863,
                八卦无刃杀 = 16488,
                命水 = 16489,
                劫火灭却之术 = 16491,
                冰晶乱流之术 = 16492,
                分身之术 = 16493,
                残影镰鼬 = 25774,
                幻影野槌 = 25776,
                月影雷兽爪 = 25777,
                月影雷兽牙 = 25778,
                介毒之术 = 36957,
                百雷铳 = 36958,
                通灵之术_虾蟆仙 = 36959,
                是生灭法 = 36960,
                天理人道 = 36961;
        }
        public static class Buffs
        {
            public const uint
                生杀予夺 = 497,
                天地人 = 1186,
                分身之术 = 1954;
        }
    }

    #endregion

    #region EN — English Names (verified via xivapi-v2.xivcdn.com)

    public static class EN
    {
        public static class Skills
        {
            public const uint
                SpinningEdge = 2240,
                ShadeShift = 2241,
                GustSlash = 2242,
                Hide = 2245,
                Assassinate = 2246,
                ThrowingDagger = 2247,
                Mug = 2248,
                DeathBlossom = 2254,
                AeolianEdge = 2255,
                TrickAttack = 2258,
                Ten = 2259,
                Ninjutsu = 2260,
                Chi = 2261,
                Shukuchi = 2262,
                Jin = 2263,
                Kassatsu = 2264,
                FumaShuriken = 2265,
                Katon = 2266,
                Raiton = 2267,
                Hyoton = 2268,
                Huton = 2269,
                Doton = 2270,
                Suiton = 2271,
                RabbitMedium = 2272,
                ArmorCrush = 3563,
                DreamWithinADream = 3566,
                HellfrogMedium = 7401,
                Bhavacakra = 7402,
                TenChiJin = 7403,
                SecondWind = 7541,
                Bloodbath = 7542,
                TrueNorth = 7546,
                ArmsLength = 7548,
                Feint = 7549,
                LegSweep = 7863,
                HakkeMujinsatsu = 16488,
                Meisui = 16489,
                GokaMekkyaku = 16491,
                HyoshoRanryu = 16492,
                Bunshin = 16493,
                PhantomKamaitachi = 25774,
                HollowNozuchi = 25776,
                ForkedRaiju = 25777,
                FleetingRaiju = 25778,
                Dokumori = 36957,
                KunaisBane = 36958,
                DeathfrogMedium = 36959,
                ZeshoMeppo = 36960,
                TenriJindo = 36961;
        }
        public static class Buffs
        {
            public const uint
                Kassatsu = 497,
                TenChiJin = 1186,
                Bunshin = 1954;
        }
    }

    #endregion

    public const uint Kassatsu = 497;           // 生杀予夺
    public const uint TenChiJin = 1186;         // 天地人
    public const uint Bunshin = 1954;           // 分身之术

    /// <summary>忍者职业量谱</summary>
    public static NINGauge? Gauge => HelperRuntime.GetGauge<NINGauge>();

    /// <summary>忍气值</summary>
    public static byte Ninki => Gauge?.Ninki ?? 0;

    /// <summary>是否拥有最大忍气</summary>
    public static bool HasMaxNinki => Ninki >= 100;

    /// <summary>生杀予夺是否激活</summary>
    public static bool HasKassatsu => HelperRuntime.HasStatus(Kassatsu);

    /// <summary>天地人是否激活</summary>
    public static bool HasTenChiJin => HelperRuntime.HasStatus(TenChiJin);

    /// <summary>分身之术是否激活</summary>
    public static bool HasBunshin => HelperRuntime.HasStatus(Bunshin);
}