using Business.Requests;
using Business.Responses;

namespace Business.Services
{
    public interface IBootcampService
    {Task<BootcampResponse> AddAsync(CreateBootcampRequest request);
        Task<BootcampResponse> UpdateAsync(UpdateBootcampRequest request);
        Task DeleteAsync(DeleteBootcampRequest request);
        Task <List<BootcampResponse>> GetAllAsync();
        Task<BootcampResponse> GetByIdAsync(int id);
    }
}
