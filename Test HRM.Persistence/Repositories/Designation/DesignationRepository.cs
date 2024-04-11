using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using HRM.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Designation.Interface;

namespace Test_HRM.Persistence.Repositories.Designation
{
    public sealed class DesignationRepository : BaseRepository, IDesignationRepository
    {
        private readonly HRMDBContext _dbContext;

        public DesignationRepository(HRMDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(IReadOnlyList<HRM.Domin.Entities.Designation.Designation> list , int totalRecords)> GetListBySpec(Paginator paginator,ISpecification<HRM.Domin.Entities.Designation.Designation> specification, CancellationToken token)
        {
            var query = _dbContext.Designation.WithSpecification(specification);

            var total = await query.CountAsync(cancellationToken: token);

            var entity = await query
                                .Skip((paginator.PageNumber - 1) * paginator.PageSize)
                                .Take(paginator.PageSize)
                                .ToListAsync(cancellationToken: token);
            return (entity, total);
        }


        public async Task<HRM.Domin.Entities.Designation.Designation> GetByNameSpec(ISpecification<HRM.Domin.Entities.Designation.Designation> specification, CancellationToken token, bool asTracking = false)
        {


            var query = asTracking ? _dbContext.Designation.AsTracking() : _dbContext.Designation;

            var entity = await query.WithSpecification(specification).FirstOrDefaultAsync(cancellationToken: token);


            return entity;


        }


        public HRM.Domin.Entities.Designation.Designation Add(HRM.Domin.Entities.Designation.Designation model)
        {
            _dbContext.Designation.Add(model);
            return model;
        }

        public async Task<HRM.Domin.Entities.Designation.Designation> GetByIDSpec(ISpecification<HRM.Domin.Entities.Designation.Designation> specification, CancellationToken token, bool asTracking = false)
        {

            var query = asTracking ? _dbContext.Designation.AsTracking() :  _dbContext.Designation;

            var entity = await query.FirstOrDefaultAsync(cancellationToken: token);

            return entity;
        }
    }
}
