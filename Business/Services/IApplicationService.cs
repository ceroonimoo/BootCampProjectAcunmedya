using Business.Requests;
using Business.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public interface IApplicationService
    {Task<CreatedApplicationResponse> AddAsync(CreateApplicationRequest request);
        Task<List<CreatedApplicationResponse>> GetAllAsync();
        Task<CreatedApplicationResponse> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<CreatedApplicationResponse> UpdateAsync(UpdateApplicationRequest request);
    }
}
