using Core.Repositories;
using Entity.Entities;

namespace DataAccess.Repositories
{
    public interface IApplicationRepository:IRepository<Application>
    {
        Task<bool> ExistsAsync(int applicantId, int bootcampId);
    }
}
