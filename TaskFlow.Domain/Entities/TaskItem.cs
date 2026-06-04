using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities;

public class TaskItem : BaseEntity
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    // Todo, InProgress, InReview, Done
    public TaskItemStatus Status { get; set; } = TaskItemStatus.Todo;

    // Low, Medium, High, Critical
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;

    // teslim tarihi
    public DateTime? DueDate { get; set; }


    public Guid ProjectId { get; set; }

    public Project Project { get; set; } = null!;

    // görevin atandığı kişiye ait id
    public Guid? AssigneeId { get; set; }

    public User? Assignee { get; set; }

    // görevi oluşturan kişiye ait id
    public Guid ReporterId { get; set; }

    public User Reporter { get; set; } = null!;


    public ICollection<Comment> Comments { get; set; }
        = new List<Comment>();

    // görev geçmişi
    public ICollection<ActivityLog> ActivityLogs { get; set; }
        = new List<ActivityLog>();
}
