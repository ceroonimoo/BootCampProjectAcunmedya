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
    public class ApplicationRepository(AppDbContext context):Repository<Application>(context),IApplicationRepository
    {
        public async Task<bool> ExistsAsync(int applicantId, int bootcampId)
        {
            return await context.Applications
                .AnyAsync(a => a.ApplicantId == applicantId && a.BootcampId == bootcampId);
        }
    }
}
