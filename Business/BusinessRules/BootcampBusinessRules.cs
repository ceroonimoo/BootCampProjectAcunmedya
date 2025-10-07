using Business.Requests;
using DataAccess.Repositories;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class BootcampBusinessRules(IBootcampRepository _bootcampRepository, IInstructorRepository _instructorRepository)
    {
        
        public async Task CheckCreateRulesAsync(CreateBootcampRequest request)
        {
            if (request.StartDate >= request.EndDate)
                throw new Exception("Başlangıç tarihi, bitiş tarihinden önce olmalıdır.");

            var exists = await _bootcampRepository.GetAllAsync();
            if (exists.Any(b => b.Name == request.Name))
                throw new Exception("Aynı isimde bir bootcamp zaten mevcut.");

            var instructor = await _instructorRepository.GetByIdAsync(request.InstructorId);
            if (instructor == null)
                throw new Exception("Eğitmen sistemde bulunamadı.");
        }

        public async Task CheckUpdateRulesAsync(UpdateBootcampRequest request)
        {
            await CheckCreateRulesAsync(new CreateBootcampRequest
            {
                Name = request.Name,
                InstructorId = request.InstructorId,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                BootcampState = request.BootcampState
            });
        }
    }

}
