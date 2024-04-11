using HRM.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_HRM.Application.Designation.Dto;
using Test_HRM.Application.Designation.Filter;
using Test_HRM.Application.Designation.Interface;

namespace Test_HRM.Controllers
{
    [Route("api/designation")]
    [ApiController]
    public class DesignationController : BaseController
    {
        private readonly IDesingationService _designationService;

        public DesignationController(IDesingationService service)
        {
            _designationService = service;
        }

        [HttpGet]

        public async Task<ActionResult> GetDesignationList([FromQuery] Paginator paginator, [FromQuery] DesignationFilter filter, CancellationToken token)
        {
            var response = await _designationService.GetList(paginator, filter, token);

            return response.Success ? Ok(response) : UnsuccessfullResponse(response);
        }

        [HttpPost]

        public async Task<ActionResult> AddDesignation([FromBody] CreateDesignationDto model, CancellationToken token)
        {
            var response = await _designationService.Add(model, token);

            return response.Success ? CreatedAtRoute(nameof(GetDesignationByID), new { id = response.Data!.Id }, response) : UnsuccessfullResponse(response);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetDesignationByID([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _designationService.GetById(id, token);

            return response.Success ? Ok(response) : UnsuccessfullResponse(response);
        }


        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateDesignation([FromRoute] Guid id, [FromBody] UpdateDesignationDto model, CancellationToken token)
        {
            var response = await _designationService.Update(id, model, token);

            return response.Success ? NoContent() : UnsuccessfullResponse(response);
        }

        [HttpDelete("{id}")]


        public async Task<ActionResult> DeleteDesignation([FromRoute] Guid id, CancellationToken token)
        {
            var response = await _designationService.Delete(id,token);

            return response.Success ? NoContent() : UnsuccessfullResponse(response);
        }
    }
}

