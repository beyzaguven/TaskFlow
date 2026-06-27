using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces;

public interface IWorkspaceRepository
{
    Task AddAsync(Workspace workspace);

    Task<List<Workspace>> GetByUserIdAsync(Guid userId);

    Task<Workspace?> GetByIdAsync(Guid id);

    Task<WorkspaceMember?> GetMemberAsync(Guid workspaceId, Guid userId);

    Task SaveChangesAsync();
}