using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Enums
{
    public enum ActivityType
    {
        Created = 1,
        Updated = 2,
        Deleted = 3,
        StatusChanged = 4,
        Assigned = 5,
        Commented = 6
    }
}
