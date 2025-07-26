using DataAccess.Connection;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ApplicationRepository(AppDbContext context):Repository<Application>(context),IApplicationRepository
    {
    }
}
