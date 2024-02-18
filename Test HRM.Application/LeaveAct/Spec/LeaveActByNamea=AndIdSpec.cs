using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveAct.Spec
{
    public class LeaveActByNamea_AndIdSpec : Specification<HRM.Domin.Entities.LeaveAct.LeaveAct> , ISingleResultSpecification
    {
        public LeaveActByNamea_AndIdSpec(string name, Guid id)
        {
            Query.Where(n => n.Name.Contains(name) && n.Id != id);
        }
    }
}
