using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Common;

namespace TaskFlow.Domain.Entities;

public class Comment : BaseEntity
{
    public string Content { get; set; } = string.Empty;


    public Guid TaskItemId { get; set; }

    public TaskItem TaskItem { get; set; } = null!;


    public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}