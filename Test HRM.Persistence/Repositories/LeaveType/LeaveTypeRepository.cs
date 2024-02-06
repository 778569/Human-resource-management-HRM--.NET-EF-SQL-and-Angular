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
        private readonly HRMDBContext _hRMDBContext;

        public LeaveTypeRepository(HRMDBContext hRMDBContext) : base(hRMDBContext)
        {
            _hRMDBContext = hRMDBContext;
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
                var query = _hRMDBContext.LeaveType.WithSpecification(specification);

                var totalRecords = await query.CountAsync(cancellationToken: token);

                var entity = await query
                            .Skip((paginator.PageNumber - 1) * paginator.PageSize)
                            .Take(paginator.PageSize)
                            .ToListAsync(cancellationToken: token);

                return (entity, totalRecords);
            }

        }


        public async Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByIdSpec(ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification , CancellationToken token, bool asTracking = false)
        {
            var query = asTracking ? _hRMDBContext.LeaveType.AsTracking() : _hRMDBContext.LeaveType;

            var entity = await query.WithSpecification(specification).FirstOrDefaultAsync(cancellationToken: token);

            return entity;

        }

        public async Task<HRM.Domin.Entities.LeaveType.LeaveType> GetByNameSpec(ISpecification<HRM.Domin.Entities.LeaveType.LeaveType> specification, CancellationToken token, bool asTracking = false)
        {
            var query = asTracking ? _hRMDBContext.LeaveType.AsTracking() : _hRMDBContext.LeaveType;

            var entity = await query.WithSpecification(specification).FirstOrDefaultAsync(cancellationToken: token);

            return entity;
        }

        public HRM.Domin.Entities.LeaveType.LeaveType Add(HRM.Domin.Entities.LeaveType.LeaveType leaveTypeItem)
        {
            _hRMDBContext.LeaveType.Add(leaveTypeItem);
            //_hRMDBContext.SaveChanges();
            return leaveTypeItem;
        }

        public async Task<HRM.Domin.Entities.LeaveType.LeaveType?> GetById(Guid id, CancellationToken token, bool asTracking = false)
        {
            var query = asTracking ? _hRMDBContext.LeaveType.AsTracking() : _hRMDBContext.LeaveType;

            var entity = await query.FirstOrDefaultAsync(f => f.Id == id, cancellationToken: token);

            return entity;
        }


    }
}
