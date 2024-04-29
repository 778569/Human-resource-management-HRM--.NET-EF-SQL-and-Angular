using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Shared.Interfaces;
using Test_HRM.Shared.Models;

namespace HRM.Domin.Entities.Department
{
    public sealed class SubDepartment : EntityBase, ICreatedAudit, IDeletedAudit, IUpdatedAudit
    {
        public DateTimeOffset CreatedOn { get ; set; }
        public string? CreatedBy { get ; set ; }
        public DateTimeOffset? DeletedOn { get; set; }
        public string DeletedBy { get ; set ; }

        public bool IsDeleted { get; private set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }

        public int SubDepartmentCode { get; set; }

        public string SubDepartmentName { get; set; }

        public Guid DepartmemntId { get; set; }

        public Department Department { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
