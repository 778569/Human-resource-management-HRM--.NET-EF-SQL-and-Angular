using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Shared.Interfaces;
using Test_HRM.Shared.Models;

namespace HRM.Domin.Entities.Leave
{
    public class Leave : EntityBase, ICreatedAudit , IUpdatedAudit, IDeletedAudit
    {
        public DateTimeOffset CreatedOn { get ; set ; }
        public string? CreatedBy { get ; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
        public string DeletedBy { get; set; }
        public bool IsDeleted { get; }
    }
}
