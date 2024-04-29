using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Shared.Interfaces;
using Test_HRM.Shared.Models;

namespace HRM.Domin.Entities.Department
{
    public sealed class Department : EntityBase, ICreatedAudit, IUpdatedAudit, IDeletedAudit
    {

        public DateTimeOffset CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public string DeletedBy { get; set; }

        public bool IsDeleted { get; private set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }


        public int DepartmentCode { get; set; }

        public string DepartmentName { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
