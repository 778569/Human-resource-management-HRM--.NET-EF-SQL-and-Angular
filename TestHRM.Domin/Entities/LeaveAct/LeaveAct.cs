using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Shared.Interfaces;
using Test_HRM.Shared.Models;

namespace HRM.Domin.Entities.LeaveAct
{
    public sealed class LeaveAct : EntityBase, ICreatedAudit ,IUpdatedAudit,IDeletedAudit
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Guid LeaveTypeId { get; set; }

        public LeaveType.LeaveType LeaveType { get; set; }
        
        public DateTimeOffset CreatedOn { get ; set ; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get ; set ; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public string? DeletedBy { get ; set; }

        public bool IsDeleted { get; private set; }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
