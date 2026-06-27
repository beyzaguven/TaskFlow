using TaskFlow.Application.DTOs.Workspaces;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Services;

public class WorkspaceService : IWorkspaceService
{
    private readonly IWorkspaceRepository _workspaceRepository;
    private readonly ICurrentUserService _currentUserService;

    public WorkspaceService(
        IWorkspaceRepository workspaceRepository,
        ICurrentUserService currentUserService)
    {
        _workspaceRepository = workspaceRepository;
        _currentUserService = currentUserService;
    }

    public async Task<WorkspaceResponse> CreateAsync(CreateWorkspaceRequest request)
    {
        var userId = _currentUserService.UserId;

        if (userId == Guid.Empty)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var workspace = new Workspace
        {
            Name = request.Name,
            Description = request.Description,
            OwnerId = userId
        };

        workspace.Members.Add(new WorkspaceMember
        {
            UserId = userId,
            Role = WorkspaceRole.Owner
        });

        await _workspaceRepository.AddAsync(workspace);
        await _workspaceRepository.SaveChangesAsync();

        return new WorkspaceResponse
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Description = workspace.Description,
            OwnerId = workspace.OwnerId,
            CreatedAt = workspace.CreatedAt
        };
    }

    public async Task<List<WorkspaceResponse>> GetMyWorkspacesAsync()
    {
        var userId = _currentUserService.UserId;

        if (userId == Guid.Empty)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var workspaces = await _workspaceRepository.GetByUserIdAsync(userId);

        return workspaces.Select(workspace => new WorkspaceResponse
        {
            Id = workspace.Id,
            Name = workspace.Name,
            Description = workspace.Description,
            OwnerId = workspace.OwnerId,
            CreatedAt = workspace.CreatedAt
        }).ToList();
    }
}