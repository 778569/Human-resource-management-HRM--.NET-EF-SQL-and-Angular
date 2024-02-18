using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveAct.Spec
{
    public class LeaveActByIdSpec : Specification<HRM.Domin.Entities.LeaveAct.LeaveAct>, ISingleResultSpecification
    {
        public LeaveActByIdSpec(Guid id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}
