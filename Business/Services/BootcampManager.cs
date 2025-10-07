using AutoMapper;
using Business.BusinessRules;
using Business.Requests;
using Business.Responses;
using DataAccess.Repositories;
using Entity.Entities;

namespace Business.Services
{
    public class BootcampManager(IBootcampRepository _repository, IMapper _mapper, BootcampBusinessRules _rules) : IBootcampService
    {
        public async Task<BootcampResponse> AddAsync(CreateBootcampRequest request)
        {
            await _rules.CheckCreateRulesAsync(request);
            var entity = _mapper.Map<Bootcamp>(request);
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<BootcampResponse>(entity);
        }

        public async Task DeleteAsync(DeleteBootcampRequest request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<BootcampResponse>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<BootcampResponse>>(entities);
        }

        public async Task<BootcampResponse> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<BootcampResponse>(entity);
        }

        public async Task<BootcampResponse> UpdateAsync(UpdateBootcampRequest request)
        {
            await _rules.CheckUpdateRulesAsync(request);
            var entity = _mapper.Map<Bootcamp>(request);
            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<BootcampResponse>(entity);
        }
    }
}
