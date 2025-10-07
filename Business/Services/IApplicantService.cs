using Business.Requests;
using Business.Responses;

namespace Business.Services
{
    public interface IApplicantService
    {
        Task<BlacklistResponse> CreateAsync(CreateBlacklistRequest request);
        Task<BlacklistResponse> UpdateAsync(UpdateBlacklistRequest request);
        Task DeleteAsync(int id);
        Task<BlacklistResponse> GetByIdAsync(int id);
        Task<List<BlacklistResponse>> GetAllAsync();
    }
}
