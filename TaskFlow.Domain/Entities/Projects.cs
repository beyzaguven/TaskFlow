using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class Project : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ProjectStatus Status { get; set; } = ProjectStatus.Active;


    public Guid WorkspaceId { get; set; }

    public Workspace Workspace { get; set; } = null!;


    public ICollection<TaskItem> Tasks { get; set; }
        = new List<TaskItem>();
}
