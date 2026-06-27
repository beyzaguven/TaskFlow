using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Persistence;

namespace TaskFlow.Infrastructure.Repositories;

public class WorkspaceRepository : IWorkspaceRepository
{
    private readonly AppDbContext _context;

    public WorkspaceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Workspace workspace)
    {
        await _context.Workspaces.AddAsync(workspace);
    }

    public async Task<List<Workspace>> GetByUserIdAsync(Guid userId)
    {
        return await _context.WorkspaceMembers
            .Where(x => x.UserId == userId)
            .Select(x => x.Workspace)
            .ToListAsync();
    }

    public async Task<Workspace?> GetByIdAsync(Guid id)
    {
        return await _context.Workspaces
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public async Task<WorkspaceMember?> GetMemberAsync(Guid workspaceId, Guid userId)
    {
        return await _context.WorkspaceMembers
            .FirstOrDefaultAsync(x =>
                x.WorkspaceId == workspaceId &&
                x.UserId == userId);
    }
}