using AutoMapper;
using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Leave.Interface;
using Test_HRM.Application.LeaveType.Dto;
using Test_HRM.Application.LeaveType.Filter;
using Test_HRM.Application.LeaveType.Interfaces;
using Test_HRM.Application.LeaveType.Spec;
using Test_HRM.Shared.Responses;



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

        //public async Task<IReadOnlyList<LeaveTypeDto>> GetList()
        //{
        //    var list = await _leaveTypeRepository.GetListBySpec();


        //    var afterMap =  _mapper.Map<IReadOnlyList<LeaveTypeDto>>(list);

        //    //return afterMap;

        //    //return new IReadOnlyList<LeaveTypeDto>(afterMap);
        //}

        //public async Task<ResponseResult<IReadOnlyList<LeaveTypeDto>>> GetList(Paginator paginator, LeaveTypeFilter filter, CancellationToken token)
        //{
        //    var (list, totalRecords) = await _leaveTypeRepository.GetListBySpec(paginator, new LeaveTypeFilterSpec(filter), token);


        //    var leaveTypeItemDtoList = _mapper.Map<IReadOnlyList<LeaveTypeDto>>(list);

        //    return new ResponseResult<IReadOnlyList<LeaveTypeDto>>(leaveTypeItemDtoList,totalRecords);

        //    //return new Response
        //}


        public async Task<ResponseResult<IReadOnlyList<LeaveTypeDto>>> GetList(Paginator paginator, LeaveTypeFilter filter, CancellationToken token)
        {
            var (list, totalRecords) = await _leaveTypeRepository.GetListBySpec(paginator, new LeaveTypeFilterSpec(filter), token);

            var leaveTypeItemDtoList = _mapper.Map<IReadOnlyList<LeaveTypeDto>>(list);

            return new ResponseResult<IReadOnlyList<LeaveTypeDto>>(leaveTypeItemDtoList, totalRecords);
        }




        //public async Task<LeaveTypeDto> Add(CreateLeaveTypeDto model)
        //{

        //    var aftermap = _mapper.Map<HRM.Domin.Entities.LeaveType.LeaveType>(model);

        //    var leavetype = await _leaveTypeRepository.GetByNameSpec(aftermap);

        //    var LeaveTypeDtoMap = _mapper.Map<LeaveTypeDto>(leavetype);

        //    return LeaveTypeDtoMap;
        //}

        //public async Task<LeaveTypeDto> GetById(Guid id)
        //{

        //    var leavetypeItem = await _leaveTypeRepository.GetByIdSpec(id);


        //    var mappedItem = _mapper.Map<LeaveTypeDto>(leavetypeItem);


        //    return mappedItem;
        //}


        //public async Task<LeaveTypeDto> Update(Guid id, UpdateLeaveTypeDto model)
        //{
        //    var beforeMap = _mapper.Map<HRM.Domin.Entities.LeaveType.LeaveType>(model);

        //    var leaveType = await _leaveTypeRepository.GetById(id, beforeMap);

        //    var afterMap = _mapper.Map<LeaveTypeDto>(model);

        //    return afterMap;
        //}
    }
}
