using Azure;
using HRM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_HRM.Application.LeaveAct.Dto;
using Test_HRM.Application.LeaveAct.Filters;
using Test_HRM.Application.LeaveAct.Interfaces;

namespace Test_HRM.Controllers
{
    [Route("api/leaveact")]
    
    public class LeaveActController : BaseController
    {
        private readonly ILeaveActService _leaveActService;

        public LeaveActController(ILeaveActService  leaveActService)
        {
            _leaveActService = leaveActService;
        }

        [HttpPost]

        public async Task<ActionResult> AddLeaveAct([FromBody] CreateLeaveActDto model, CancellationToken token)
        {

          var responce = await _leaveActService.Add(model, token);

          return Ok(responce);

        }


        [HttpGet]

        public async Task<ActionResult> GetLeaveActByList([FromQuery] Paginator paginator, [FromQuery] LeaveActFilter model,CancellationToken token)
        {
            var response = await _leaveActService.GetList(paginator, model,token);

            return response.Success ? Ok(response) : UnsuccessfullResponse(response);
        }
    }
}
