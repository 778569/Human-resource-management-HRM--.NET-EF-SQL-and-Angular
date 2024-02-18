using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using HRM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveAct.Interfaces;
using Test_HRM.Shared.Responses;

namespace Test_HRM.Persistence.Repositories.LeaveAct
{
    public class LeaveActRepository : BaseRepository , ILeaveActRepository
    {
        private readonly HRMDBContext _hRMDBContext;

        public LeaveActRepository(HRMDBContext hRMDBContext) : base(hRMDBContext) 
        {
           _hRMDBContext = hRMDBContext;
        }

        public HRM.Domin.Entities.LeaveAct.LeaveAct Add(HRM.Domin.Entities.LeaveAct.LeaveAct leaveAct)
        {
            _hRMDBContext.LeaveAct.Add(leaveAct);

            return leaveAct;
        }


        public async Task<(IReadOnlyList<HRM.Domin.Entities.LeaveAct.LeaveAct> list , int totalRecords)> GetListBySepec(Paginator paginator, ISpecification<HRM.Domin.Entities.LeaveAct.LeaveAct> specification, CancellationToken token)
        {
            var query = _hRMDBContext.LeaveAct.WithSpecification(specification);

            var total = await query.CountAsync(cancellationToken: token);

            var entity = await query.Skip((paginator.PageNumber - 1) * paginator.PageSize).Take(paginator.PageSize).ToListAsync(cancellationToken : token);

            return (entity,total);
        }

        public async Task<HRM.Domin.Entities.LeaveAct.LeaveAct> GetByIdSpec(ISpecification<HRM.Domin.Entities.LeaveAct.LeaveAct> specification, CancellationToken token, bool asTracking = false)
        {
            var query = asTracking ? _hRMDBContext.LeaveAct.AsTracking() : _hRMDBContext.LeaveAct;

            var entity = await query.WithSpecification(specification).FirstOrDefaultAsync(cancellationToken: token);

            return entity;
        }

        public async Task<HRM.Domin.Entities.LeaveAct.LeaveAct> GetById(Guid id, CancellationToken token, bool asTracking = false)
        {
            var query = asTracking ? _hRMDBContext.LeaveAct.AsTracking() : _hRMDBContext.LeaveAct; 
            
            var entity = await _hRMDBContext.LeaveAct.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: token);

            return entity;
        }


        public async Task<HRM.Domin.Entities.LeaveAct.LeaveAct?> GetByNameSpec(ISpecification<HRM.Domin.Entities.LeaveAct.LeaveAct> specification, CancellationToken token , bool asTracking = false )
        {
            var querry = asTracking ? _hRMDBContext.LeaveAct.AsTracking() : _hRMDBContext.LeaveAct;

            var entity = await querry.WithSpecification(specification).FirstOrDefaultAsync(cancellationToken: token);

            return entity;
        }
    }
}
