using AutoMapper;
using Business.Requests;
using Business.Responses;
using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeManager(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request)
        {
            // Business rule: aynı TC kimlik ile duplicate olamaz
            if (await _repository.ExistsByNationalIdAsync(request.NationalityIdentity))
                throw new Exception("Bu TC kimlik numarası ile kayıtlı bir çalışan zaten var.");

            var entity = _mapper.Map<Employee>(request);

            // Password hash işlemi burada yapılmıyorsa AuthService çağırılmalı.
            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<EmployeeResponse>(entity);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Çalışan bulunamadı.");

            _repository.Delete(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task<List<EmployeeResponse>> GetAllAsync()
        {
            var list = await _repository.GetAllAsync();
            return _mapper.Map<List<EmployeeResponse>>(list);
        }

        public async Task<EmployeeResponse> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new Exception("Çalışan bulunamadı.");

            return _mapper.Map<EmployeeResponse>(entity);
        }

        public async Task<EmployeeResponse> UpdateAsync(UpdateEmployeeRequest request)
        {
            var entity = await _repository.GetByIdAsync(request.Id);
            if (entity == null)
                throw new Exception("Çalışan bulunamadı.");

            // Manuel alan güncelleme (map ile de yapılabilir)
            entity.FirstName = request.FirstName ?? entity.FirstName;
            entity.LastName = request.LastName ?? entity.LastName;
            entity.Email = request.Email ?? entity.Email;
            entity.Position = request.Position ?? entity.Position;

            _repository.Update(entity);
            await _repository.SaveChangesAsync();

            return _mapper.Map<EmployeeResponse>(entity);
        }
    }
}
