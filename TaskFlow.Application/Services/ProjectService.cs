using TaskFlow.Application.DTOs.Projects;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IWorkspaceAuthorizationService _workspaceAuthorizationService;

    public ProjectService(
        IProjectRepository projectRepository,
        ICurrentUserService currentUserService,
        IWorkspaceAuthorizationService workspaceAuthorizationService)
    {
        _projectRepository = projectRepository;
        _currentUserService = currentUserService;
        _workspaceAuthorizationService = workspaceAuthorizationService;
    }

    public async Task<ProjectResponse> CreateAsync(CreateProjectRequest request)
    {
        var userId = _currentUserService.UserId;

        if (userId == Guid.Empty)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var canCreateProject =
            await _workspaceAuthorizationService
                .IsOwnerOrAdminAsync(request.WorkspaceId, userId);

        if (!canCreateProject)
        {
            throw new UnauthorizedAccessException(
                "You are not authorized to create projects in this workspace.");
        }

        var project = new Project
        {
            WorkspaceId = request.WorkspaceId,
            Name = request.Name,
            Description = request.Description,
            Status = ProjectStatus.Active
        };

        await _projectRepository.AddAsync(project);
        await _projectRepository.SaveChangesAsync();

        return new ProjectResponse
        {
            Id = project.Id,
            WorkspaceId = project.WorkspaceId,
            Name = project.Name,
            Description = project.Description,
            Status = project.Status,
            CreatedAt = project.CreatedAt
        };
    }

    public async Task<List<ProjectResponse>> GetByWorkspaceAsync(Guid workspaceId)
    {
        var userId = _currentUserService.UserId;

        if (userId == Guid.Empty)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var isMember =
            await _workspaceAuthorizationService
                .IsMemberAsync(workspaceId, userId);

        if (!isMember)
        {
            throw new UnauthorizedAccessException(
                "You are not a member of this workspace.");
        }

        var projects =
            await _projectRepository.GetByWorkspaceIdAsync(workspaceId);

        return projects.Select(project => new ProjectResponse
        {
            Id = project.Id,
            WorkspaceId = project.WorkspaceId,
            Name = project.Name,
            Description = project.Description,
            Status = project.Status,
            CreatedAt = project.CreatedAt
        }).ToList();
    }
}