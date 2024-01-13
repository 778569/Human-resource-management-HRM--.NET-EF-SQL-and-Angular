using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Shared.Interfaces
{
    public interface ICreatedAudit
    {
        DateTimeOffset CreatedOn { get; set; }

        string? CreatedBy { get; set; }
    }
}
