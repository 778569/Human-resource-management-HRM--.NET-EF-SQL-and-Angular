using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveAct.Dto
{
    public class LeaveActDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid LeaveTypeId { get; set; }
    }
}
