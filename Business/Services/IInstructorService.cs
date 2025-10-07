using Business.Requests;
using Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IInstructorService
    {
        Task<InstructorResponse> CreateAsync(CreateInstructorRequest request);
        Task<InstructorResponse> UpdateAsync(UpdateInstructorRequest request);
        Task DeleteAsync(int id);
        Task<InstructorResponse> GetByIdAsync(int id);
        Task<List<InstructorResponse>> GetAllAsync();
    }

}
