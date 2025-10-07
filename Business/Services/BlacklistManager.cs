using AutoMapper;
using Business.BusinessRules;
using Business.Requests;
using Business.Responses;
using DataAccess.Connection;
using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class BlacklistManager(IBlacklistRepository _repository,IMapper _mapper, BlacklistBusinessRules _rules):IBlacklistService
    {
        public async Task<BlacklistResponse> CreateAsync(CreateBlacklistRequest request)
        {
            await _rules.ApplicantCannotBeBlacklistedTwice(request.ApplicantId);
            await _rules.ReasonCannotBeEmpty(request.Reason);

            var entity = _mapper.Map<Blacklist>(request);
            _repository.AddAsync(entity);
            _repository.SaveChangesAsync();

            return _mapper.Map<BlacklistResponse>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity= await _repository.GetByIdAsync(id);
            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<BlacklistResponse> UpdateAsync(UpdateBlacklistRequest request)
        {
            await _rules.ReasonCannotBeEmpty(request.Reason);

            var entity= await _repository.GetByIdAsync(request.Id);
            _mapper.Map(request, entity);
            _repository.Update(entity);

            return _mapper.Map<BlacklistResponse>(entity);

        }

        async Task<List<BlacklistResponse>> IBlacklistService.GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<List<BlacklistResponse>>(entities);
        }

        async Task<BlacklistResponse> IBlacklistService.GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return _mapper.Map<BlacklistResponse>(entity);
        }
    }
}
