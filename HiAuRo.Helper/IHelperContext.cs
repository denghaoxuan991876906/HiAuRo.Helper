using OmenTools.Dalamud.Services.ObjectTable.Abstractions.ObjectKinds;

namespace HiAuRo.Helper;

public interface IHelperContext
{
    bool HasStatus(uint statusId);
    IPlayerCharacter? GetTarget();
    bool HasStatusOnTarget(uint statusId);
}
