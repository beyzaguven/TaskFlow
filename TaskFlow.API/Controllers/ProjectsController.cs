using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.Projects;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProjectRequest request)
    {
        var result = await _projectService.CreateAsync(request);

        return Ok(result);
    }

    [HttpGet("workspace/{workspaceId:guid}")]
    public async Task<IActionResult> GetByWorkspace(Guid workspaceId)
    {
        var result = await _projectService.GetByWorkspaceAsync(workspaceId);

        return Ok(result);
    }
}