using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Designation.Filter;

namespace Test_HRM.Application.Designation.Spec
{
    public sealed class DesignationFilterBySpec : Specification<HRM.Domin.Entities.Designation.Designation>
    {
        public DesignationFilterBySpec(DesignationFilter desigtnationfilter)
        {
            Query.OrderByDescending(o => o.CreatedOn);

            if (!string.IsNullOrEmpty(desigtnationfilter.Name))
                Query.Search(x => x.Name, "%" + desigtnationfilter.Name + "%");
        }
    }
}
