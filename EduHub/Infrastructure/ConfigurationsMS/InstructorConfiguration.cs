using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {

        builder.HasKey(i => i.InstructorId);

        builder.Property(i => i.FullName)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(i => i.Email)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(i => i.Bio)
            .HasMaxLength(1000); 

        builder.Property(i => i.ProfileImageUrl)
            .HasMaxLength(255);

        builder.Property(i => i.SocialLink)
            .HasMaxLength(255);

        builder.Property(i => i.RegisteredAt)
            .IsRequired();

        builder.HasMany(i => i.Videos)
            .WithOne(v => v.Instructor)
            .HasForeignKey(v => v.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);


        builder.ToTable("Instructors");
    }
}
