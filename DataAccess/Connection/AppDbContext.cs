using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new BootcampConfiguration());
            modelBuilder.ApplyConfiguration(new BlacklistConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
