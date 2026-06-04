using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public class Workspace : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    // workspace sahibinin User Id değeri
    public Guid OwnerId { get; set; }

    // workspace sahibinin User nesnesi
    public User Owner { get; set; } = null!;

    public ICollection<WorkspaceMember> Members { get; set; }
        = new List<WorkspaceMember>();

    public ICollection<Project> Projects { get; set; }
        = new List<Project>();
}
