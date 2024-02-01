using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveType.Interfaces;

using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HRM.Shared.Models;

namespace Test_HRM.Persistence.Repositories.LeaveType
{
    public class LeaveTypeRepository : BaseRepository , ILeaveTypeRepository
    {
        private readonly DbSet<HRM.Domin.Entities.LeaveType.LeaveType> _leaveTypeTable;

        public LeaveTypeRepository(HRMDBContext hRMDBContext) : base(hRMDBContext)
        {

            _leaveTypeTable = hRMDBContext.Set<HRM.Domin.Entities.LeaveType.LeaveType>();

        }

       

        //public async Task<(IReadOnlyList<HRM.Domin.Entities.LeaveType.LeaveType> list, int totalRecords)> GetListBySpec(Paginator paginator, ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification, CancellationToken token )
        //{

        //    var query = _table.WithSpecification(specification);

        //    var totalRecords = await query.CountAsync(cancellationToken : token);

        //   var entity = await query.Skip((paginator.PageNumber - 1) * paginator.PageSize).Take(paginator.PageSize).ToListAsync(cancellationToken : token);

        //    return (entity, totalRecords);

        //}

        //public async Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByNameSpec(HRM.Domin.Entities.LeaveType.LeaveType leavetype)
        //{

        //    _hRMDBContext.Leavetype.Add(leavetype);
        //    _hRMDBContext.SaveChanges();

        //    return _hRMDBContext.Leavetype.Find(leavetype.Id);



        //}

        //public async Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByIdSpec(Guid id)
        //{

        //    return _hRMDBContext.Leavetype.Find(id);



        //}


        //public async Task<HRM.Domin.Entities.LeaveType.LeaveType> GetById(Guid id, HRM.Domin.Entities.LeaveType.LeaveType leaveType)
        //{

        //    leaveType.Id = id;
        //    _hRMDBContext.Leavetype.Add(leaveType);
        //    _hRMDBContext.SaveChanges();

        //    return _hRMDBContext.Leavetype.Find(leaveType.Id);



        //}

        public async Task<(IReadOnlyList<HRM.Domin.Entities.LeaveType.LeaveType> list, int totalRecocrds)> GetListBySpec(Paginator paginator, ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification, CancellationToken token)
        {
            {
                var query = _leaveTypeTable.WithSpecification(specification);

                var totalRecords = await query.CountAsync(cancellationToken: token);

                var entity = await query
                            .Skip((paginator.PageNumber - 1) * paginator.PageSize)
                            .Take(paginator.PageSize)
                            .ToListAsync(cancellationToken: token);

                return (entity, totalRecords);
            }

        }
    }
}
