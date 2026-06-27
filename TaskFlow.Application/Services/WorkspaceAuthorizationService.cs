using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Services;

public class WorkspaceAuthorizationService : IWorkspaceAuthorizationService
{
    private readonly IWorkspaceRepository _workspaceRepository;

    public WorkspaceAuthorizationService(IWorkspaceRepository workspaceRepository)
    {
        _workspaceRepository = workspaceRepository;
    }

    public async Task<bool> IsOwnerOrAdminAsync(Guid workspaceId, Guid userId)
    {
        var member = await _workspaceRepository.GetMemberAsync(workspaceId, userId);

        if (member is null)
        {
            return false;
        }

        return member.Role == WorkspaceRole.Owner ||
               member.Role == WorkspaceRole.Admin;
    }

    public async Task<bool> IsMemberAsync(Guid workspaceId, Guid userId)
    {
        var member = await _workspaceRepository.GetMemberAsync(workspaceId, userId);

        return member is not null;
    }
}