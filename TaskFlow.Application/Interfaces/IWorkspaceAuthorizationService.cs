namespace TaskFlow.Application.Interfaces;

public interface IWorkspaceAuthorizationService
{
    Task<bool> IsOwnerOrAdminAsync(Guid workspaceId, Guid userId);

    Task<bool> IsMemberAsync(Guid workspaceId, Guid userId);
}