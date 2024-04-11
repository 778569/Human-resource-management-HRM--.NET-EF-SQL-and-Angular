using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.Designation.Spec
{
    public class DesignationTypeByName : Specification<HRM.Domin.Entities.Designation.Designation>
    {

        public DesignationTypeByName(string name)
        {
            Query.Where(x => x.Name == name);
        }
    }
}
