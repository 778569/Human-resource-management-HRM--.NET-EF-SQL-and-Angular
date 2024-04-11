using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Persistence.Repositories.LeaveType;
using Test_HRM.Application.LeaveType.Interfaces;
using Test_HRM.Application.LeaveAct.Interfaces;
using Test_HRM.Persistence.Repositories.LeaveAct;
using Test_HRM.Application.Designation.Interface;
using Test_HRM.Persistence.Repositories.Designation;
//using Test_HRM.Persistence.Repositories.LeaveType;

namespace Test_HRM.Persistence
{
    public static class PersistenceServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Leave Type

            services.TryAddScoped<ILeaveTypeRepository, LeaveTypeRepository>();

            //Leave Act

            services.TryAddScoped<ILeaveActRepository, LeaveActRepository>();


            //Designation

            services.TryAddScoped<IDesignationRepository, DesignationRepository>();

            return services;

        }
    }
}
