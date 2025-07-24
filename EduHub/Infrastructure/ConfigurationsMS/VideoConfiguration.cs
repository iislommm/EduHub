using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VideoConfiguration : IEntityTypeConfiguration<Video>
{
    public void Configure(EntityTypeBuilder<Video> builder)
    {
        // Primary Key
        builder.HasKey(v => v.VideoId);

        // Properties
        builder.Property(v => v.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(v => v.Description)
            .HasMaxLength(1000);

        builder.Property(v => v.MB)
            .IsRequired();

        builder.Property(v => v.Views)
            .IsRequired();

        builder.Property(v => v.Comments)
            .HasMaxLength(2000); // You can change this as needed

        builder.Property(v => v.Duration)
            .IsRequired();

        builder.Property(v => v.VideoUrl)
            .IsRequired()
            .HasMaxLength(255);

        // Relationships
        builder.HasOne(v => v.Category)
            .WithMany(c => c.Videos)
            .HasForeignKey(v => v.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(v => v.Instructor)
            .WithMany(i => i.Videos)
            .HasForeignKey(v => v.InstructorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Table name
        builder.ToTable("Videos");
    }
}
