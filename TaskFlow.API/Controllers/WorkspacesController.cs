using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.DTOs.Workspaces;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.API.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class WorkspacesController : ControllerBase
{
    private readonly IWorkspaceService _workspaceService;

    public WorkspacesController(IWorkspaceService workspaceService)
    {
        _workspaceService = workspaceService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateWorkspaceRequest request)
    {
        var result = await _workspaceService.CreateAsync(request);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetMyWorkspaces()
    {
        var result = await _workspaceService.GetMyWorkspacesAsync();

        return Ok(result);
    }
}