using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Shared.Interfaces
{
    public interface IDeletedAudit
    {
        DateTimeOffset? DeletedOn { get; set; }

        string DeletedBy { get; set; }

        public bool IsDeleted { get;  }
    }
}
