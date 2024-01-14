using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveType.Interfaces
{
    public interface ILeaveTypeRepository
    {
        Task<IReadOnlyList<HRM.Domin.Entities.LeaveType.LeaveType>> GetListBySpec();
    }
}
