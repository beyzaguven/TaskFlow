using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public class User : BaseEntity
{
    public string FullName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string PasswordHash { get; set; } = string.Empty;

    public ICollection<WorkspaceMember> WorkspaceMembers { get; set; }
        = new List<WorkspaceMember>();


    public ICollection<TaskItem> AssignedTasks { get; set; }
        = new List<TaskItem>();


    public ICollection<Comment> Comments { get; set; }
        = new List<Comment>();
}
