using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces;

public interface IProjectRepository
{
    Task AddAsync(Project project);

    Task<List<Project>> GetByWorkspaceIdAsync(Guid workspaceId);

    Task<Project?> GetByIdAsync(Guid id);

    Task SaveChangesAsync();
}