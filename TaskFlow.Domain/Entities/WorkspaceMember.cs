using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class WorkspaceMember : BaseEntity
{
    public Guid WorkspaceId { get; set; }

    public Workspace Workspace { get; set; } = null!;

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    public WorkspaceRole Role { get; set; } = WorkspaceRole.Member;
}
