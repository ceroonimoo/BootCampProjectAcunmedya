using DataAccess.Connection;
using Entity.Entities;

namespace DataAccess.Repositories
{
    public class BootcampRepository(AppDbContext context):Repository<Bootcamp>(context),IBootcampRepository
    {
    }
}
