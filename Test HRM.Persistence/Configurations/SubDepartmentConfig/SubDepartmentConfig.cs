using HRM.Domin.Entities.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Persistence.Configurations.SubDepartmentConfig
{
    public class SubDepartmentConfig : IEntityTypeConfiguration<SubDepartment>
    {
        public void Configure(EntityTypeBuilder<SubDepartment> builder)
        {
            builder.HasKey(k => k.Id);

            builder.HasIndex(i => i.IsDeleted);
            builder.HasQueryFilter(i => i.IsDeleted == false);

            builder.Property(p => p.SubDepartmentCode).IsRequired().HasMaxLength(250);
            builder.Property(p => p.SubDepartmentName).IsRequired().HasMaxLength(500);

            builder.HasOne(s => s.Department)
                .WithMany()
                .HasForeignKey(s => s.DepartmemntId);
        }
    }
}
