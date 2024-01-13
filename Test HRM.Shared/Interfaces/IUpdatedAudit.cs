using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Shared.Interfaces
{
    public interface IUpdatedAudit
    {

        DateTimeOffset? UpdatedOn { get; set; }

        string? UpdatedBy { get; set; }
    }
}
