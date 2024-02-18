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

        public LeaveActController(ILeaveActService leaveActService)
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

        public async Task<ActionResult> GetLeaveActByList([FromQuery] Paginator paginator, [FromQuery] LeaveActFilter model, CancellationToken token)
        {
            var response = await _leaveActService.GetList(paginator, model, token);

            return response.Success ? Ok(response) : UnsuccessfullResponse(response);
        }

        [HttpGet("{id}", Name ="GetLeaveAct")]

        public async Task<ActionResult> GetLeaveAct([FromRoute] Guid id, CancellationToken token)
        {

            var responce = await _leaveActService.GetById(id, token);

            return responce.Success ? Ok(responce) : UnsuccessfullResponse(responce);
        }

        [HttpPut("{id}")]


        public async Task<ActionResult> UpdateLeaveAct([FromRoute] Guid id, [FromBody]UpdateLeaveTyepDto model, CancellationToken token)
        {
            var responce = await _leaveActService.Update(id, model, token);

            return responce.Success ? NoContent() : UnsuccessfullResponse(responce);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteLeaveAct([FromRoute] Guid id, CancellationToken token)
        {
            var responce = await _leaveActService.Delete(id,token);

            return responce.Success ? NoContent() : UnsuccessfullResponse(responce);
        }
    }
}
