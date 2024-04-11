using Ardalis.Specification;
using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.PersisteanceInterfaces;

namespace Test_HRM.Application.Designation.Interface
{
    public interface IDesignationRepository : IBaseRepository
    {
        Task<(IReadOnlyList<HRM.Domin.Entities.Designation.Designation> list, int totalRecords)> GetListBySpec(Paginator paginator, ISpecification<HRM.Domin.Entities.Designation.Designation> specification, CancellationToken token);

        Task<HRM.Domin.Entities.Designation.Designation> GetByNameSpec(ISpecification<HRM.Domin.Entities.Designation.Designation> specification, CancellationToken token, bool asTracking = false);

        HRM.Domin.Entities.Designation.Designation Add(HRM.Domin.Entities.Designation.Designation model);

        Task<HRM.Domin.Entities.Designation.Designation> GetByIDSpec(ISpecification<HRM.Domin.Entities.Designation.Designation> specification, CancellationToken token, bool asTracking = false);

    }
}
