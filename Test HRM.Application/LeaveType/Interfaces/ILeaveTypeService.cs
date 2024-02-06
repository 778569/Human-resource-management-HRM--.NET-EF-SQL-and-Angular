using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveType.Dto;
using Test_HRM.Application.LeaveType.Filter;
using Test_HRM.Shared.Responses;


namespace Test_HRM.Application.LeaveType.Interfaces
{
    public interface ILeaveTypeService
    {
        //Task<IReadOnlyList<LeaveTypeDto>> GetList();
        //Task<ICollection<LeaveTypeDto>> GetList();

        //Task<LeaveTypeDto> Add(CreateLeaveTypeDto model);

        //Task<LeaveTypeDto> GetById(Guid id);

        //Task<LeaveTypeDto> Update(Guid id, UpdateLeaveTypeDto model);

        Task<ResponseResult<IReadOnlyList<LeaveTypeDto>>> GetList(Paginator paginator, LeaveTypeFilter filter, CancellationToken token);

        Task<ResponseResult<LeaveTypeDto>> GetById(Guid id, CancellationToken token);

        Task<ResponseResult<LeaveTypeDto>> Add(CreateLeaveTypeDto model, CancellationToken token);

        Task<ResponseResult> Update(Guid id, UpdateLeaveTypeDto model, CancellationToken token);

        Task<ResponseResult> Delete(Guid id, CancellationToken token);


    }
}
