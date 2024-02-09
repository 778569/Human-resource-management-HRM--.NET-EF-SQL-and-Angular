using HRM.Domin.Entities.LeaveAct;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Persistence.Configurations.LeaveActConfig
{
    public class LeaveActConfig : IEntityTypeConfiguration<LeaveAct>
    {
        public void Configure(EntityTypeBuilder<LeaveAct> builder)
        {
            builder.HasKey(k => k.Id);
            builder.HasIndex(k => k.IsDeleted);

            builder.HasQueryFilter(k => k.IsDeleted);
            builder.HasIndex(f => f.Name).IsUnique();

            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(500);

            builder.HasOne(s => s.LeaveType).WithMany().HasForeignKey(s => s.LeaveTypeId);
        }
    }
}
