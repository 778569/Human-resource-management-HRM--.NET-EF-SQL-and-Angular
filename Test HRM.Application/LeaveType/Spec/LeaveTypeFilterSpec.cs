using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveType.Filter;

namespace Test_HRM.Application.LeaveType.Spec
{
    public sealed class LeaveTypeFilterSpec : Specification<HRM.Domin.Entities.LeaveType.LeaveType>, ISingleResultSpecification
    {

        public LeaveTypeFilterSpec(LeaveTypeFilter filter)
        {
            //Query.OrderByDescending(o => o.CreatedOn);

            //if (!string.IsNullOrEmpty(leaveTypeFilter.Name))
            //{
            //    Query.Search(x => x.Name, "%" + leaveTypeFilter.Name + "%");
            //}
            Query.OrderByDescending(o => o.CreatedOn);
            if (!string.IsNullOrWhiteSpace(filter.Name)) Query.Search(x => x.Name, "%" + filter.Name + "%");

        }
    }
}
