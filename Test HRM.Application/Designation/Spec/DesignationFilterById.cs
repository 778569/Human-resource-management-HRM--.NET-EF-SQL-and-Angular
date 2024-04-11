using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.Designation.Spec
{
    public class DesignationFilterById : Specification<HRM.Domin.Entities.Designation.Designation>
    {
        public DesignationFilterById(Guid id)
        {
            Query.Where(i => i.Id == id);
        }
    }
}
