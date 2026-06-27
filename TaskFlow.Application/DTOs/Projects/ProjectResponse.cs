using TaskFlow.Domain.Enums;

namespace TaskFlow.Application.DTOs.Projects;

public class ProjectResponse
{
    public Guid Id { get; set; }

    public Guid WorkspaceId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ProjectStatus Status { get; set; }

    public DateTime CreatedAt { get; set; }
}