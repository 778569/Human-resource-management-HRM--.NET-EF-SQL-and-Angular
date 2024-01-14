using HRM.Domin.Entities.LeaveType;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Persistence.Configurations.LeaveTypeConfig
{
    public class LeaveTypeConfig : IEntityTypeConfiguration<HRM.Domin.Entities.LeaveType.LeaveType>
    {
        //public void Configure( EntityTypeBuilder<HRM.Domin.Entities.LeaveType.LeaveType> builder)
        //{

        //}
        public void Configure(EntityTypeBuilder<LeaveType> builder)
        {
           builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.IsDeleted);
            builder.HasQueryFilter(e => e.IsDeleted == false);
            builder.HasIndex(e => e.Name).IsUnique();

            builder.Property(e=>e.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);
        }
    }
}
