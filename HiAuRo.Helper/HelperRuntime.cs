namespace HiAuRo.Helper;

public static class HelperRuntime
{
    private static IHelperContext? _ctx;

    internal static void Initialize(IHelperContext context)
    {
        _ctx = context;
    }

    internal static bool HasStatus(uint statusId) =>
        _ctx?.HasStatus(statusId) ?? false;

    internal static bool HasStatusOnTarget(uint statusId) =>
        _ctx?.HasStatusOnTarget(statusId) ?? false;
}
