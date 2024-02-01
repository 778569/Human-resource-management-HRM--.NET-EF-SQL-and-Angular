using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Shared.Responses
{
    public sealed class ErrorResponse : BaseResponse
    {
        public string? TraceId { get; init; }

        public ErrorResponse()
        {
            base.Success = false;
        }

    }
}
