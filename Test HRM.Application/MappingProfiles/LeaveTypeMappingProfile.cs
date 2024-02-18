using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveType.Dto;


namespace Test_HRM.Application.MappingProfile
{
    public class LeaveTypeMappingProfile : Profile
    {

        public LeaveTypeMappingProfile()
        {
            CreateMap<HRM.Domin.Entities.LeaveType.LeaveType, LeaveTypeDto>().ReverseMap(); 

            CreateMap<HRM.Domin.Entities.LeaveType.LeaveType, CreateLeaveTypeDto>().ReverseMap();

            CreateMap<HRM.Domin.Entities.LeaveType.LeaveType, UpdateLeaveTypeDto>().ReverseMap();

        }
    }
}
