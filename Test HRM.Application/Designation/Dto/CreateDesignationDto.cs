using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.Designation.Dto
{
    public sealed record CreateDesignationDto(string Name, string ShortCode, string Description);
}
