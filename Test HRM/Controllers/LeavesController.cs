using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_HRM.Controllers
{
    [Route("api/leave")]
    [ApiController]
    public class LeavesController : ControllerBase
    {
        public LeavesController()
        {

        }

        [HttpGet("employee/{id}/count")]

        public async Task<ActionResult> GetLeavesCount(Guid Id, CancellationToken token)
        {
            return Ok();
        }







        [HttpGet("history")]

        public async Task<ActionResult> GetEmployeeLeaveHistory()
        {


            return Ok();
        }


        [HttpGet("{date}")]

        public async Task<ActionResult> GetLeaveByData(DateTimeOffset date, CancellationToken token)
        {
            return Ok();
        }
    }
}
