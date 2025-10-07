using Core.Repositories;
using Entity.Entities;

namespace DataAccess.Repositories
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        Task<bool> ExistsByNationalIdAsync(string nationalId);
    }
}
