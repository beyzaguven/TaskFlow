using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Enums
{
    public enum TaskItemStatus
    {
        Todo = 1,
        InProgress = 2,
        InReview = 3,
        Done = 4
    }
}
