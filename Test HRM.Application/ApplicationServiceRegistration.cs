using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveType.Interfaces;
using Test_HRM.Application.LeaveType.Service;

namespace Test_HRM.Application
{
    public static class ApplicationServiceRegistration
    {


        public static IServiceCollection AddApplicationServices( this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.TryAddScoped< ILeaveTypeService, LeaveTypeService>();

            return services;

        }

    }
}
