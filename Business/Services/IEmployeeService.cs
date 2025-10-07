using Business.Requests;
using Business.Responses;

namespace Business.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request);
        Task<EmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
        Task DeleteAsync(int id);
        Task<EmployeeResponse> GetByIdAsync(int id);
        Task<List<EmployeeResponse>> GetAllAsync();
    }
}
