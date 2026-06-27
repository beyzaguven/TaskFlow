using TaskFlow.Application.DTOs.Projects;

namespace TaskFlow.Application.Interfaces;

public interface IProjectService
{
    Task<ProjectResponse> CreateAsync(CreateProjectRequest request);

    Task<List<ProjectResponse>> GetByWorkspaceAsync(Guid workspaceId);
}