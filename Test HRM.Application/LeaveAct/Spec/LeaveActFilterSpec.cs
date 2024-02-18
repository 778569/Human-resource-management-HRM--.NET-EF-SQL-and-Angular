using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveAct.Filters;

namespace Test_HRM.Application.LeaveAct.Spec
{
    public class LeaveActFilterSpec : Specification<HRM.Domin.Entities.LeaveAct.LeaveAct>
    {
        public LeaveActFilterSpec(LeaveActFilter filter)
        {
            Query.Include(i => i.LeaveType).OrderByDescending(o => o.CreatedOn);
            if (!string.IsNullOrWhiteSpace(filter.Name)) Query.Search(x => x.Name, "%" + filter.Name + "%");
        }
    }
}
