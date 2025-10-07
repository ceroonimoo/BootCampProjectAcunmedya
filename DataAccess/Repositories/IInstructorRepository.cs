using Core.Repositories;
using Entity.Entities;

namespace DataAccess.Repositories
{
    public interface IInstructorRepository:IRepository<Instructor>
    {
        Task<bool> ExistsByNationalIdAsync(string nationalId);
    }
}
