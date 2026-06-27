using TaskFlow.Application.DTOs.Workspaces;

namespace TaskFlow.Application.Interfaces;

public interface IWorkspaceService
{
    Task<WorkspaceResponse> CreateAsync(CreateWorkspaceRequest request);

    Task<List<WorkspaceResponse>> GetMyWorkspacesAsync();
}