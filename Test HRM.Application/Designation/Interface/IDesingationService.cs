using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Designation.Dto;
using Test_HRM.Application.Designation.Filter;
using Test_HRM.Application.PersisteanceInterfaces;
using Test_HRM.Shared.Responses;

namespace Test_HRM.Application.Designation.Interface
{
    public interface IDesingationService
    {

        Task<ResponseResult<IReadOnlyList<DesignationDto>>> GetList(Paginator paginator, DesignationFilter filter, CancellationToken token);

        Task<ResponseResult<DesignationDto>> Add(CreateDesignationDto model, CancellationToken token);

        Task<ResponseResult<DesignationDto>> GetById(Guid id, CancellationToken token);

        Task<ResponseResult> Update(Guid id, UpdateDesignationDto model, CancellationToken token);

        Task<ResponseResult> Delete(Guid id, CancellationToken token);
    }
}
