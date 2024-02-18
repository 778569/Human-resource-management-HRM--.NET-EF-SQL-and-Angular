using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveAct.Dto;

namespace Test_HRM.Application.MappingProfiles
{
    public class LeaveActMappingProfile : Profile
    {

        public LeaveActMappingProfile()
        {
            CreateMap<HRM.Domin.Entities.LeaveAct.LeaveAct, LeaveActDto>().ReverseMap();

            CreateMap<HRM.Domin.Entities.LeaveAct.LeaveAct, CreateLeaveActDto>().ReverseMap();
            CreateMap<HRM.Domin.Entities.LeaveAct.LeaveAct, UpdateLeaveTyepDto>().ReverseMap();
        }
    }
}
