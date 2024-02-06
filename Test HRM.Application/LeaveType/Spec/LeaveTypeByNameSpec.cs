using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveType.Spec
{
    public class LeaveTypeByNameSpec : Specification<HRM.Domin.Entities.LeaveType.LeaveType>
    {
        public LeaveTypeByNameSpec(string name)
        {
            Query.Where(x => x.Name == name);
        }
    }
}
