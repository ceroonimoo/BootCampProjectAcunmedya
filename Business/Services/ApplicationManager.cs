using AutoMapper;
using Business.BusinessRules;
using Business.Requests;
using Business.Responses;
using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class ApplicationManager(IApplicationRepository _repository, IMapper _mapper, ApplicationBusinessRules _rules) : IApplicationService
    {
        public async Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest request)
        {
            await _rules.CheckIfDuplicateExists(request.ApplicantId, request.BootcampId);

            var application = _mapper.Map<Application>(request);
            await _repository.AddAsync(application);
            await _repository.SaveChangesAsync();

            return _mapper.Map<CreatedApplicationResponse>(application);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<CreatedApplicationResponse>> GetAllAsync()
        {
           var entities=await _repository.GetAllAsync();
            return _mapper.Map<List<CreatedApplicationResponse>>(entities);
        }

        public async Task<CreatedApplicationResponse> GetByIdAsync(int id)
        {
            var entity= await _repository.GetByIdAsync(id);
            return _mapper.Map<CreatedApplicationResponse>(entity);
        }

        public async Task<CreatedApplicationResponse> UpdateAsync(UpdateApplicationRequest request)
        {
           
            var application = await _repository.GetByIdAsync(request.Id);
            if (application == null)
                throw new Exception("Başvuru bulunamadı.");

            application.ApplicationState = request.ApplicationState;

            _repository.Update(application);  
            await _repository.SaveChangesAsync(); 

            return _mapper.Map<CreatedApplicationResponse>(application);
        }

    }

}
