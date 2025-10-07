using Core.Repositories;
using Entity.Entities;

namespace DataAccess.Repositories
{
    public interface IUserRepository:IRepository<User>
    {
        Task<User?> GetByEmailAsync(string email);
    }
}
