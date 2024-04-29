using HRM.Domin.Entities.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Persistence.Configurations.DepartmentConfig
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            
            builder.HasKey(x => x.Id);

            builder.HasIndex(f => f.IsDeleted);
            builder.HasQueryFilter(f => f.IsDeleted == false);

            builder.Property(p => p.DepartmentCode).IsRequired().HasMaxLength(250);
            builder.Property(p => p.DepartmentName).IsRequired().HasMaxLength(500);


        }
    }
}
