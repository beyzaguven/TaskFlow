namespace TaskFlow.Application.DTOs.Projects;

public class CreateProjectRequest
{
    public Guid WorkspaceId { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }
}