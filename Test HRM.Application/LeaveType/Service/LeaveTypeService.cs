using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Leave.Interface;
using Test_HRM.Application.LeaveType.Dto;
using Test_HRM.Application.LeaveType.Interfaces;



namespace Test_HRM.Application.LeaveType.Service
{
    public class LeaveTypeService : ILeaveTypeService
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public LeaveTypeService(ILeaveTypeRepository leaveTypeRepository, IMapper mapper) 
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<Application.LeaveType.Dto.LeaveTypeDto>> GetList()
        {
            var list = await _leaveTypeRepository.GetListBySpec();


            var afterMap =  _mapper.Map<IReadOnlyList<LeaveTypeDto>>(list);

            return afterMap;

            //return new IReadOnlyList<LeaveTypeDto>(afterMap);
        }
    }
}
