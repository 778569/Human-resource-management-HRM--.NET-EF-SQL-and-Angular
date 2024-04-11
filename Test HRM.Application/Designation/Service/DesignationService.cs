using AutoMapper;
using HRM.Shared.Exceptions;
using HRM.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_HRM.Application.Designation.Dto;
using Test_HRM.Application.Designation.Filter;
using Test_HRM.Application.Designation.Interface;
using Test_HRM.Application.Designation.Spec;
using Test_HRM.Shared.Responses;

namespace Test_HRM.Application.Designation.Service
{
    public sealed class DesignationService : IDesingationService
    {
        private readonly IDesignationRepository _designation;
        private readonly IMapper _mapper;

        public DesignationService(IDesignationRepository designation, IMapper mapper)
        {
            _designation = designation;
            _mapper = mapper;
        }


        public async Task<ResponseResult<IReadOnlyList<DesignationDto>>> GetList(Paginator paginator, DesignationFilter filter, CancellationToken token)
        {


            var (list,totalRecords) = await _designation.GetListBySpec(paginator, new DesignationFilterBySpec(filter), token);

            var designationItemTodoList = _mapper.Map<IReadOnlyList<DesignationDto>>(list);


            return new ResponseResult<IReadOnlyList<DesignationDto>>(designationItemTodoList);

            
        }


        public async Task<ResponseResult<DesignationDto>> Add(CreateDesignationDto model,CancellationToken token)
        {
            var testName = await _designation.GetByNameSpec(new DesignationTypeByName(model.Name), token);

            if (testName is not null) return new ResponseResult<DesignationDto>(new RecordAlreadyExistException(nameof(HRM.Domin.Entities.Designation.Designation), model.Name, testName.Id));

            var designationToCreate = _mapper.Map<HRM.Domin.Entities.Designation.Designation>(model);


            var crateDesignation = _designation.Add(designationToCreate);

            await _designation.SaveChangesAsync(token);

            var createdDesignationDto = _mapper.Map<DesignationDto>(crateDesignation);

            return new ResponseResult<DesignationDto>(createdDesignationDto);
        }


        public async Task<ResponseResult<DesignationDto>> GetById(Guid id, CancellationToken token)
        {
            var getDesignation = await _designation.GetByIDSpec(new DesignationFilterById(id), token);

            if (getDesignation is null) return new ResponseResult<DesignationDto>(new NotFoundException(nameof (id), nameof(HRM.Domin.Entities.Designation.Designation),id));


            var mapGetDesignation = _mapper.Map<DesignationDto>(getDesignation);


            return new ResponseResult<DesignationDto>(mapGetDesignation);
        }


        public async Task<ResponseResult> Update(Guid id, UpdateDesignationDto model, CancellationToken token)
        {
            var designationItem = await _designation.GetByIDSpec(new DesignationFilterById(id), asTracking: true, token: token);

            if (designationItem is null) return new ResponseResult (new NotFoundException(nameof(id), nameof(HRM.Domin.Entities.Designation.Designation), id));

            _mapper.Map(model, designationItem);

            await _designation.SaveChangesAsync(token);

            return new ResponseResult();
        }


        public async Task<ResponseResult> Delete(Guid id, CancellationToken token)
        {
            var deleteDesignation = await _designation.GetByIDSpec(new DesignationFilterById(id), token);

            if (deleteDesignation is null) return new ResponseResult(new NotFoundException(nameof(id), nameof(HRM.Domin.Entities.Designation.Designation), id));

            deleteDesignation.Deleted();

            await _designation.SaveChangesAsync(token);

            return new ResponseResult();  
        }

    }
}
