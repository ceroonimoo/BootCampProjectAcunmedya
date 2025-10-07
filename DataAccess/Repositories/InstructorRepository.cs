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
    public class InstructorRepository(AppDbContext context):Repository<Instructor>(context),IInstructorRepository
    {
        public async Task<bool> ExistsByNationalIdAsync(string nationalId)
        {
            return await context.Set<Instructor>().AnyAsync(i => i.NationalityIdentity == nationalId);
        }
    }
}
