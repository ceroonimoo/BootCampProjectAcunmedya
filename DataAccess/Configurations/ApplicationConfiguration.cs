using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Entity.Entities;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.ApplicationState)
               .HasConversion<int>()
               .IsRequired();

        builder.HasOne<Applicant>()
               .WithMany()
               .HasForeignKey(a => a.ApplicantId);

        builder.HasOne<Bootcamp>()
               .WithMany()
               .HasForeignKey(a => a.BootcampId);
    }
}
