using AutoMapper;
using HRM.Shared.Exceptions;
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



        public async Task<ResponseResult<LeaveTypeDto>> GetById(Guid id, CancellationToken token)
        {

            var leavetypeItem = await _leaveTypeRepository.GetByIdSpec(new LeaveTypeByIdSpec(id),token);

            if (leavetypeItem is null) return new ResponseResult<LeaveTypeDto>(new NotFoundException(nameof(id), nameof(HRM.Domin.Entities.LeaveType.LeaveType), id));

            var todoItemDto = _mapper.Map<LeaveTypeDto>(leavetypeItem);

            return new ResponseResult<LeaveTypeDto>(todoItemDto);

        }



        public async Task<ResponseResult<IReadOnlyList<LeaveTypeDto>>> GetList(Paginator paginator, LeaveTypeFilter filter, CancellationToken token)
        {
            var (list, totalRecords) = await _leaveTypeRepository.GetListBySpec(paginator, new LeaveTypeFilterSpec(filter), token);

            var leaveTypeItemDtoList = _mapper.Map<IReadOnlyList<LeaveTypeDto>>(list);

            return new ResponseResult<IReadOnlyList<LeaveTypeDto>>(leaveTypeItemDtoList, totalRecords);
        }





        public async Task<ResponseResult<LeaveTypeDto>> Add(CreateLeaveTypeDto model, CancellationToken token)
        {
            var leavetype = await _leaveTypeRepository.GetByNameSpec(new LeaveTypeByNameSpec(model.Name), token);

            if (leavetype is not null) return new ResponseResult<LeaveTypeDto>(new RecordAlreadyExistException(nameof (HRM.Domin.Entities.LeaveType.LeaveType), model.Name, leavetype.Id));

            var leaveTypeToCreate = _mapper.Map<HRM.Domin.Entities.LeaveType.LeaveType>(model);

            var createLeaveType = _leaveTypeRepository.Add(leaveTypeToCreate);

            await _leaveTypeRepository.SaveChangesAsync(token);

            var createdLeaveTypeDto = _mapper.Map<LeaveTypeDto>(createLeaveType);

            return new ResponseResult<LeaveTypeDto>(createdLeaveTypeDto);
        }   


        public async Task<ResponseResult> Update(Guid id, UpdateLeaveTypeDto model, CancellationToken token)
        {

            var leavetype = await _leaveTypeRepository.GetById(id, asTracking: true, token : token);

            var selectedLeaveType = await _leaveTypeRepository.GetByNameSpec(new LeaveTypeByNameAndIdSpec(model.Name, id), token, asTracking: false);

            if (selectedLeaveType is not null) return new ResponseResult(new RecordAlreadyExistException(nameof(model.Name), nameof(HRM.Domin.Entities.LeaveType.LeaveType), model.Name));

            _mapper.Map(model, leavetype);

            await _leaveTypeRepository.SaveChangesAsync(token);

            return new ResponseResult();

        }


       
        public async Task<ResponseResult> Delete(Guid id, CancellationToken token)
        {
            var leavetype = await _leaveTypeRepository.GetById(id, asTracking: true, token: token);

            if (leavetype is null) return new ResponseResult(new NotFoundException(nameof(id), nameof(HRM.Domin.Entities.LeaveType.LeaveType), id));

            leavetype.Delete();

            await _leaveTypeRepository.SaveChangesAsync(token);

            return new ResponseResult();
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
