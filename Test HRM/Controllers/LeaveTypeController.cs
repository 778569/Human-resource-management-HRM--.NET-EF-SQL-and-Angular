using HRM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_HRM.Application.LeaveType.Interfaces;

namespace Test_HRM.Controllers
{
    [Route("api/leavetype")]
    [ApiController]
    public class LeaveTypeController : ControllerBase
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }
        
        
        [HttpGet]

        public async Task<ActionResult> GetLeaveTypeList()
        {
            var responce = _leaveTypeService.GetList();

            return Ok(responce);
        }
    }
}
