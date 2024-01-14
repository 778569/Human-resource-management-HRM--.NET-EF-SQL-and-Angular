using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_HRM.Shared.Interfaces
{
    public interface ILoggedInUserService
    {
        string UserId { get; }

        string? UserRole { get; }
    }
}
