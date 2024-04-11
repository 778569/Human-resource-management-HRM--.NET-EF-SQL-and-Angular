using HRM.Domin.Entities.Designation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Persistence.Configurations.DesignationConfig
{
    public class DesignationConfig : IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasQueryFilter(e => e.IsDeleted == false);

            builder.Property(e => e.Name).IsRequired().HasMaxLength(250);

            builder.HasIndex(e => e.Name).IsUnique();

            builder.Property(e => e.ShortCode).HasMaxLength(250);

            builder.Property(e => e.Description).HasMaxLength(500);

            
        }
    }
}
