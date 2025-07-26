using Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        builder.ToTable("Bootcamps");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Name)
               .IsRequired()
               .HasMaxLength(100);

        builder.Property(b => b.BootcampState)
               .HasConversion<int>();

        builder.HasOne<Instructor>()
               .WithMany()
               .HasForeignKey(b => b.InstructorId);
    }
}
