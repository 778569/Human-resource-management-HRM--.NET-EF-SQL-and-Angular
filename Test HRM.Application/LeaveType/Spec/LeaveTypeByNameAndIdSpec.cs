using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveType.Spec
{
    public class LeaveTypeByNameAndIdSpec : Specification<HRM.Domin.Entities.LeaveType.LeaveType>, ISingleResultSpecification
    {
        public LeaveTypeByNameAndIdSpec(string name, Guid id)
        {
            Query.Where(x => x.Name.Contains(name) && x.Id != id);
        }
    }
}
