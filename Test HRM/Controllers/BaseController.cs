using Microsoft.AspNetCore.Mvc;
using System.Net;
using Test_HRM.Shared.Responses;

namespace Test_HRM.Controllers
{
    public abstract class BaseController : ControllerBase
    {

        [ApiExplorerSettings(IgnoreApi = true)]
        protected ObjectResult UnsuccessfullResponse<T>(ResponseResult<T> responseResult)
        {
            return UnsuccessfullResponseHandler(responseResult);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        protected ObjectResult UnsuccessfullResponse(ResponseResult responseResult)
        {
            return UnsuccessfullResponseHandler(responseResult);
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private ObjectResult UnsuccessfullResponseHandler<T>(ResponseResult<T> responseResult)
        {
            var groupedErrors = responseResult.Errors.GroupBy(x => x.Key).ToList();

            ErrorResponse errorResponse = new()
            {
                Errors = groupedErrors.Select(s => new KeyValuePair<string, IEnumerable<string>>(s.Key, s.SelectMany(er => er.Value).ToList())).ToList()
            };

            if (responseResult.HttpStatusCode == HttpStatusCode.BadRequest)
                return BadRequest(errorResponse);

            else if (responseResult.HttpStatusCode == HttpStatusCode.NotFound)
                return NotFound(errorResponse);

            else if (responseResult.HttpStatusCode == HttpStatusCode.Unauthorized)
                return Unauthorized(errorResponse);

            else
                return StatusCode(statusCode: StatusCodes.Status500InternalServerError, errorResponse);
        }
    }
}
