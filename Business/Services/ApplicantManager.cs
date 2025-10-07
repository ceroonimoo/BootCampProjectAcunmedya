using AutoMapper;
using Business.Requests;
using Business.Responses;
using Core.Repositories;
using Entity.Entities;

namespace Business.Services.Managers
{
    public class ApplicantManager : IApplicantService
    {
        private readonly IRepository<Blacklist> _repository;
        private readonly IMapper _mapper;

        public ApplicantManager(IRepository<Blacklist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<BlacklistResponse> CreateAsync(CreateBlacklistRequest request)
        {
            var blacklist = _mapper.Map<Blacklist>(request);
            await _repository.AddAsync(blacklist);
            await _repository.SaveChangesAsync();
            return _mapper.Map<BlacklistResponse>(blacklist);
        }

        public async Task<BlacklistResponse> UpdateAsync(UpdateBlacklistRequest request)
        {
            var blacklist = await _repository.GetByIdAsync(request.Id);
            if (blacklist == null)
                throw new Exception("Blacklist kaydı bulunamadı.");

            _mapper.Map(request, blacklist); // request'teki verileri blacklist entity'sine aktar
            _repository.Update(blacklist);
            await _repository.SaveChangesAsync();

            return _mapper.Map<BlacklistResponse>(blacklist);
        }

        public async Task DeleteAsync(int id)
        {
            var blacklist = await _repository.GetByIdAsync(id);
            if (blacklist == null)
                throw new Exception("Blacklist kaydı bulunamadı.");

            _repository.Delete(blacklist);
            await _repository.SaveChangesAsync();
        }

        public async Task<BlacklistResponse> GetByIdAsync(int id)
        {
            var blacklist = await _repository.GetByIdAsync(id);
            if (blacklist == null)
                throw new Exception("Blacklist kaydı bulunamadı.");

            return _mapper.Map<BlacklistResponse>(blacklist);
        }

        public async Task<List<BlacklistResponse>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<BlacklistResponse>>(list);
        }
    }
}
