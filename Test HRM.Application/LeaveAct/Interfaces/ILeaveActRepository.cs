using Ardalis.Specification;
using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.PersisteanceInterfaces;

namespace Test_HRM.Application.LeaveAct.Interfaces
{
    public interface ILeaveActRepository : IBaseRepository
    {
        HRM.Domin.Entities.LeaveAct.LeaveAct Add(HRM.Domin.Entities.LeaveAct.LeaveAct leaveAct);

        Task<(IReadOnlyList<HRM.Domin.Entities.LeaveAct.LeaveAct> list, int totalRecords)> GetListBySepec(Paginator paginator, ISpecification<HRM.Domin.Entities.LeaveAct.LeaveAct> specification, CancellationToken token);
    }
}
