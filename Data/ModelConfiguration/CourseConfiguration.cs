using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities;
using LearningHub.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningHub.Data.ModelConfiguration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(r => r.CourseId);
            builder.Property(r => r.CourseId)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.CourseName)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(r => r.Price)
                .HasPrecision(10, 2)
                .HasDefaultValue(0.00m);

            builder.Property(r => r.DifficultyLevel)
                .HasConversion<string>()
                .HasDefaultValue(DifficultyLevel.Medium);

            // category course ga birga kop
            builder.HasOne(r => r.Category)
                .WithMany(r => r.Courses)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
