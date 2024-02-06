using HRM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Test_HRM.Application.LeaveType.Dto;
using Test_HRM.Application.LeaveType.Filter;
using Test_HRM.Application.LeaveType.Interfaces;

namespace Test_HRM.Controllers
{
    [Route("api/leavetype")]
    [ApiController]
    public class LeaveTypeController : BaseController
    {
        private readonly ILeaveTypeService _leaveTypeService;

        public LeaveTypeController(ILeaveTypeService leaveTypeService)
        {
            _leaveTypeService = leaveTypeService;
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetLeaveType([FromRoute]Guid id, CancellationToken token)
        {

            var responce = await _leaveTypeService.GetById(id, token);


            return responce.Success ? Ok(responce) : UnsuccessfullResponse(responce);

        }

        [HttpPost]

        public async Task<ActionResult> AddLeaveType([FromBody] CreateLeaveTypeDto model, CancellationToken token)
        {

            var response = await _leaveTypeService.Add(model, token);

            //return Ok(response);

            return response.Success ? CreatedAtRoute(nameof(GetLeaveType), new { id = response.Data!.Id }, response) : UnsuccessfullResponse(response);

        }


        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateLeaveType([FromRoute] Guid id, [FromBody] UpdateLeaveTypeDto model, CancellationToken token)
        {

            var respone = await _leaveTypeService.Update(id,model,token);

            return respone.Success ? NoContent() : UnsuccessfullResponse(respone);

        }




        [HttpGet]

        
        public async Task<ActionResult> GetLeaveTypeList([FromQuery] Paginator paginator, [FromQuery] LeaveTypeFilter filter, CancellationToken token)
        {
            var response = await _leaveTypeService.GetList(paginator, filter, token);

            return response.Success ? Ok(response) : UnsuccessfullResponse(response);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteLeavetype([FromRoute] Guid id, CancellationToken token)
        {

            var response = await _leaveTypeService.Delete(id, token);

            return response.Success ? NoContent() : UnsuccessfullResponse(response);

        }











        //[HttpPost]

        //public async Task<ActionResult> AddLeaveType([FromBody] CreateLeaveTypeDto model)
        //{

        //    var responce = await _leaveTypeService.Add(model);

        //    //return Ok(responce);

        //    return NoContent();
        //}


        //[HttpGet("{id}")]
        //public async Task<ActionResult> GetLeaveType(Guid id)
        //{

        //    var responce = await _leaveTypeService.GetById(id);

        //    return Ok(responce);
        //}

        //[HttpPut("{id}")]

        //public async Task<ActionResult> UpdateLeaveType(Guid id, UpdateLeaveTypeDto model)
        //{
        //    var response = await _leaveTypeService.Update(id, model);

        //    return Ok(response);
        //}
    }
}
