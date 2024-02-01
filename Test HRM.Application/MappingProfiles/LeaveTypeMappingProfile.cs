using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test_HRM.Application.MappingProfile
{
    public class LeaveTypeMappingProfile : Profile
    {

        public LeaveTypeMappingProfile()
        {
            CreateMap<HRM.Domin.Entities.LeaveType.LeaveType, LeaveTypeDto>();

            CreateMap<HRM.Domin.Entities.LeaveType.LeaveType, CreateLeaveTypeDto>().ReverseMap();


        }
    }
}
