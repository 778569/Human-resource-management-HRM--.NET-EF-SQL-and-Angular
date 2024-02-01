using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Test_HRM.Shared.Responses
{
    public sealed class ResponseResult : ResponseResult<object>
    {

        public ResponseResult() : base(default(object))
        {
            Success = true;
        }

        public ResponseResult(IList<KeyValuePair<string, IEnumerable<string>>> validationFailures) : base(validationFailures) { }

        public ResponseResult(ApplicationException ex) : base(ex) { }

        [JsonIgnore]
        public override List<KeyValuePair<string, IEnumerable<string>>> Errors { get; init; } = new();
    }
}
