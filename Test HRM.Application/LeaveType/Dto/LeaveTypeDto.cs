using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveType.Dto
{
    public sealed record class LeaveTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
