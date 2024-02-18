using AutoMapper;
using HRM.Domin.Entities.LeaveAct;
using HRM.Shared.Exceptions;
using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.LeaveAct.Dto;
using Test_HRM.Application.LeaveAct.Filters;
using Test_HRM.Application.LeaveAct.Interfaces;
using Test_HRM.Application.LeaveAct.Spec;
using Test_HRM.Application.MappingProfiles;
using Test_HRM.Shared.Responses;

namespace Test_HRM.Application.LeaveAct.Services
{
    public class LeaveActService : ILeaveActService
    {
        private readonly IMapper _mapper;
        private readonly ILeaveActRepository _leaveActRepository;

        public LeaveActService(IMapper mapper, ILeaveActRepository leaveActRepository)
        {
            _mapper = mapper;
            _leaveActRepository = leaveActRepository;
        }


        public async Task<ResponseResult<LeaveActDto>> Add(CreateLeaveActDto model, CancellationToken token)
        {
            var leaveActToCreate = _mapper.Map<HRM.Domin.Entities.LeaveAct.LeaveAct>(model);

            var createLeaveAct =  _leaveActRepository.Add(leaveActToCreate);

            await _leaveActRepository.SaveChangesAsync(token);

            var AfterMapLeaveAct = _mapper.Map<LeaveActDto>(createLeaveAct);

            return new ResponseResult<LeaveActDto>(AfterMapLeaveAct);

        }


        public async Task<ResponseResult<IReadOnlyList<LeaveActDto>>> GetList(Paginator paginator, LeaveActFilter model, CancellationToken token)
        {
            var (list, totalRecoreds) = await _leaveActRepository.GetListBySepec(paginator, new LeaveActFilterSpec(model),token);

            var leaveActItem = _mapper.Map<IReadOnlyList<LeaveActDto>>(list);

            return new ResponseResult<IReadOnlyList<LeaveActDto>>(leaveActItem,totalRecoreds);
        }



        public async Task<ResponseResult<LeaveActDto>> GetById(Guid id,CancellationToken token) 
        {

            var leaveact = await _leaveActRepository.GetByIdSpec(new LeaveActByIdSpec(id), token);

            if (leaveact is null)
            {
                return new ResponseResult<LeaveActDto>(new NotFoundException(nameof(id), nameof(HRM.Domin.Entities.LeaveAct.LeaveAct), id));
            }

           var LeaveActmap = _mapper.Map<LeaveActDto>(leaveact);

            return new ResponseResult<LeaveActDto>(LeaveActmap);
        
        }

        public async Task<ResponseResult> Update(Guid id, UpdateLeaveTyepDto model,CancellationToken token)
        {
            var TakeLeaveActName = await _leaveActRepository.GetById(id, asTracking: true, token: token);

            var seletedLeaveAct = await _leaveActRepository.GetByNameSpec(new LeaveActByNamea_AndIdSpec(model.Name,id),token);

            if (seletedLeaveAct is not null)
            {
                return new ResponseResult(new RecordAlreadyExistException(nameof(model.Name), nameof(HRM.Domin.Entities.LeaveType.LeaveType), model.Name));
            }

            //if (TakeLeaveActName is not null) return new ResponseResult(new RecordAlreadyExistException(nameof(model.Name), nameof(HRM.Domin.Entities.LeaveAct.LeaveAct), TakeLeaveActName.Name));


            _mapper.Map(model, TakeLeaveActName);

            await _leaveActRepository.SaveChangesAsync(token);

            return new ResponseResult();
        }

        public async Task<ResponseResult> Delete(Guid id, CancellationToken token)
        {

            var LeaveAct = await _leaveActRepository.GetById(id, token : token, asTracking: true);

            if (LeaveAct is null) return new ResponseResult(new NotFoundException(nameof(id), nameof(HRM.Domin.Entities.LeaveAct.LeaveAct), id));

            LeaveAct.Delete();

            await _leaveActRepository.SaveChangesAsync(token);

            return new ResponseResult();

        }
    }
}
