using Entity.Entities;
using Microsoft.EntityFrameworkCore;

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
            // Apply Configurations
            modelBuilder.ApplyConfiguration(new ApplicationConfiguration());
            modelBuilder.ApplyConfiguration(new BootcampConfiguration());
            modelBuilder.ApplyConfiguration(new BlacklistConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new InstructorConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicantConfiguration());
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            // TPH (Table Per Hierarchy): tek tablo "Users"
            modelBuilder.Entity<User>().ToTable("Users");

            // İlişki Konfigürasyonları
            modelBuilder.Entity<Bootcamp>()
                .HasOne(b => b.Instructor)
                .WithMany()
                .HasForeignKey(b => b.InstructorId)
                .OnDelete(DeleteBehavior.Restrict); // Cascade yerine Restrict ✅

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Applicant)
                .WithMany()
                .HasForeignKey(a => a.ApplicantId)
                .OnDelete(DeleteBehavior.Cascade); // Bu cascade kalabilir ✅

            modelBuilder.Entity<Application>()
                .HasOne(a => a.Bootcamp)
                .WithMany()
                .HasForeignKey(a => a.BootcampId)
                .OnDelete(DeleteBehavior.Cascade); // Bu da cascade kalabilir ✅

            base.OnModelCreating(modelBuilder);
        }

        // DbSets
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<Blacklist> Blacklists { get; set; }
        public DbSet<Bootcamp> Bootcamps { get; set; }
        public DbSet<Employee> Employees { get; set; } // Employes yerine Employees ✅
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
