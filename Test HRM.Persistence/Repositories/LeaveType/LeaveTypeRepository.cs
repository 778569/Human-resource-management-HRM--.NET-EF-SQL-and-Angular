using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveType.Interfaces;

using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;

namespace Test_HRM.Persistence.Repositories.LeaveType
{
    public class LeaveTypeRepository : ILeaveTypeRepository
    {
        private readonly HRMDBContext _hRMDBContext;

        public LeaveTypeRepository(HRMDBContext hRMDBContext) 
        {
            //_hRMDBContext = hRMDBContext.Set<HRM.Domin.Entities.LeaveType.LeaveType>();

            _hRMDBContext = hRMDBContext;

        }

        public async Task<IReadOnlyList<HRM.Domin.Entities.LeaveType.LeaveType>> GetListBySpec()
        {
            var query = _hRMDBContext.Leavetype.ToList();

            
            return query;
        }
    }
}
