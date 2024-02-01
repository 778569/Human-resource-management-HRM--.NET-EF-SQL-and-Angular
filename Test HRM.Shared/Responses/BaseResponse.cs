using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Shared.Responses
{
    public abstract class BaseResponse
    {
        public bool Success { get; protected init; }


        public virtual List<KeyValuePair<string, IEnumerable<string>>> Errors { get; init; } = new();

        public BaseResponse()
        {
            Success = false;
        }
    }
}

