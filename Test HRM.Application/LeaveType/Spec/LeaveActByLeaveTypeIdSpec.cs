using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveType.Spec
{
    public class LeaveActByLeaveTypeIdSpec : Specification<HRM.Domin.Entities.LeaveType.LeaveType>, ISingleResultSpecification
    {
        public LeaveActByLeaveTypeIdSpec(Guid leaveTypeId)
        {
            Query.Where(w => w.Id == leaveTypeId);
        }
    }
}
