using AutoMapper;
using AutoMapper.Internal;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Designation.Interface;
using Test_HRM.Application.Designation.Service;
using Test_HRM.Application.LeaveAct.Interfaces;
using Test_HRM.Application.LeaveAct.Services;
using Test_HRM.Application.LeaveType.Interfaces;
using Test_HRM.Application.LeaveType.Service;
using Test_HRM.Application.MappingProfile;

namespace Test_HRM.Application
{
    public static class ApplicationServiceRegistration
    {


        public static IServiceCollection AddApplicationServices( this IServiceCollection services)
        {

            //var mapperConfig = new MapperConfiguration(mc =>
            //{
            //    mc.Internal().MethodMappingEnabled = false;
            //    mc.AddProfile(new LeaveTypeMappingProfile());
            //});
            //IMapper mapper = mapperConfig.CreateMapper();
            //services.AddSingleton(mapper);

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.TryAddScoped< ILeaveTypeService, LeaveTypeService>();

            services.TryAddScoped<ILeaveActService, LeaveActService>();

            services.TryAddScoped<IDesingationService, DesignationService>();





            return services;

        }

    }
}
