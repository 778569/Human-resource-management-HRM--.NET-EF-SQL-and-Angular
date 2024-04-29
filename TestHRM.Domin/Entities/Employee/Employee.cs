using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Shared.Interfaces;
using Test_HRM.Shared.Models;

namespace HRM.Domin.Entities.Employee
{
    public class Employee : EntityBase 
    {

        public Guid EmployeeId { get; set; }
    }
}
