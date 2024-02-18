using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Application.LeaveAct.Dto;

public sealed record UpdateLeaveTyepDto(string Name, string Description, Guid LeaveTypeId);
