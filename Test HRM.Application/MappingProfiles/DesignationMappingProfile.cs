using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Designation.Dto;

namespace Test_HRM.Application.MappingProfiles
{
    public class DesignationMappingProfile : Profile
    {
        public DesignationMappingProfile()
        {


            CreateMap<HRM.Domin.Entities.Designation.Designation , DesignationDto>().ReverseMap();

            CreateMap<HRM.Domin.Entities.Designation.Designation, CreateDesignationDto>().ReverseMap();

            CreateMap<HRM.Domin.Entities.Designation.Designation, UpdateDesignationDto>().ReverseMap(); 


        }
    }
}
