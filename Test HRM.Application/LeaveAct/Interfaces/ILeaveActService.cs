using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveAct.Dto;
using Test_HRM.Application.LeaveAct.Filters;
using Test_HRM.Shared.Responses;

namespace Test_HRM.Application.LeaveAct.Interfaces
{
    public interface ILeaveActService
    {

        Task<ResponseResult<LeaveActDto>> Add(CreateLeaveActDto model, CancellationToken token);

        Task<ResponseResult<IReadOnlyList<LeaveActDto>>> GetList(Paginator paginator, LeaveActFilter model, CancellationToken token);

        Task<ResponseResult<LeaveActDto>> GetById(Guid id, CancellationToken token);

        Task<ResponseResult> Update(Guid id, UpdateLeaveTyepDto model, CancellationToken token);

        Task<ResponseResult> Delete(Guid id, CancellationToken token);
    }
}
