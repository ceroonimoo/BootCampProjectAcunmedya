using DataAccess.Connection;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class EmployeeRepository(AppDbContext context):Repository<Employee>(context),IEmployeeRepository
    {
        public async Task<bool> ExistsByNationalIdAsync(string nationalId)
        {
            return await context.Set<Employee>().AnyAsync(i => i.NationalityIdentity == nationalId);
        }
    }
}
