using Entity.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
{
    public void Configure(EntityTypeBuilder<Blacklist> builder)
    {
        builder.ToTable("Blacklists");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Reason)
               .IsRequired()
               .HasMaxLength(255);

        builder.Property(b => b.Date)
               .IsRequired();

        builder.HasOne(b => b.Applicant)  // Navigation property burada olmalı
                .WithMany()  // Eğer Applicant sınıfında Blacklist koleksiyonu yoksa
                .HasForeignKey(b => b.ApplicantId)
                .OnDelete(DeleteBehavior.Restrict);
    }
}
