using HRM.Domin.Entities.Department;
using HRM.Domin.Entities.Designation;
using HRM.Domin.Entities.LeaveAct;
using HRM.Domin.Entities.LeaveType;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Persistence
{
    public class HRMDBContext :DbContext
    {

        public DbSet<LeaveType> LeaveType { get; set; }

        public DbSet<LeaveAct> LeaveAct { get; set; }

        public DbSet<Designation> Designation { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<SubDepartment> SubDepartment { get; set; }



        // public SampleDbContext(DbContextOptions<HRMDBContext> options)
        //: base(options)
        // {
        // }

        //public HRMDBContext(DbContextOptions<HRMDBContext> options) : base(options)
        //{

        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionStraing = "Server=DESKTOP-0D8DMT4;Initial Catalog=Test_HRM;Integrated Security=true; User Id=sa;password =778569119119; MultipleActiveResultSets=True;TrustServerCertificate=True;";
            optionsBuilder.UseSqlServer(connectionStraing);
        }


    }
}
