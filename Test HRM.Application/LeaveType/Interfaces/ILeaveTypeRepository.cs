using Ardalis.Specification;
using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.PersisteanceInterfaces;

namespace Test_HRM.Application.LeaveType.Interfaces
{
    public interface ILeaveTypeRepository : IBaseRepository
    {
        //Task<IReadOnlyList<HRM.Domin.Entities.LeaveType.LeaveType>> GetListBySpec();
        //Task<ICollection<HRM.Domin.Entities.LeaveType.LeaveType>> GetListBySpec();

        //Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByNameSpec(HRM.Domin.Entities.LeaveType.LeaveType createLeaveTypeDto);

        //Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByIdSpec(Guid id);

        //Task<HRM.Domin.Entities.LeaveType.LeaveType> GetById(Guid id, HRM.Domin.Entities.LeaveType.LeaveType leaveType);

        //Task<(IReadOnlyList<HRM.Domin.Entities.LeaveType.LeaveType> list, int totalRecords)> GetListBySpec(Paginator paginator, ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification, CancellationToken token);

        Task<(IReadOnlyList<HRM.Domin.Entities.LeaveType.LeaveType> list, int totalRecocrds)> GetListBySpec(Paginator paginator, ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification, CancellationToken token);

        Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByIdSpec(ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification, CancellationToken token, bool asTracking = false);

        Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByNameSpec(ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification, CancellationToken token, bool asTracking = false);

        HRM.Domin.Entities.LeaveType.LeaveType Add(HRM.Domin.Entities.LeaveType.LeaveType leaveTypeItem);

        Task<HRM.Domin.Entities.LeaveType.LeaveType?> GetById(Guid id, CancellationToken token, bool asTracking = false);
    }
}
