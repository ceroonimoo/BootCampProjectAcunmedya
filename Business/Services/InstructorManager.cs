using AutoMapper;
using Business.Requests;
using Business.Responses;
using DataAccess.Repositories;
using Entity.Entities;

namespace Business.Services
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _repository;
        private readonly IMapper _mapper;

        public InstructorManager(IInstructorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<InstructorResponse> CreateAsync(CreateInstructorRequest request)
        {
            // Kurallar (Business Rules) kontrolü
            if (await _repository.ExistsByNationalIdAsync(request.NationalityIdentity))
                throw new Exception("Bu TC kimlik numarasıyla zaten bir eğitmen var.");

            var entity = _mapper.Map<Instructor>(request);
            // Password hash vs. burada yapılabilir
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<InstructorResponse>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Eğitmen bulunamadı.");

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<InstructorResponse>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<InstructorResponse>>(list);
        }

        public async Task<InstructorResponse> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Eğitmen bulunamadı.");

            return _mapper.Map<InstructorResponse>(entity);
        }

        public async Task<InstructorResponse> UpdateAsync(UpdateInstructorRequest request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new Exception("Eğitmen bulunamadı.");

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.CompanyName = request.CompanyName;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();
            return _mapper.Map<InstructorResponse>(entity);
        }
    }
}
