using AutoMapper;
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

    }
}
