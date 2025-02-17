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
    public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.HasKey(r => r.EnrollmentId);
            builder.Property(r => r.EnrollmentId)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.CompletionStatus)
                .HasConversion<string>()
                .HasDefaultValue(CompletionStatus.NotStarted);

            builder.Property(r=> r.Score)
                .HasPrecision(5, 2)
                .HasDefaultValue(0.00m);

            // student
            builder.HasOne(r => r.Student)
                .WithMany(r => r.Enrollments)
                .HasForeignKey(r => r.StudentId)
                .OnDelete(DeleteBehavior.Cascade);
            // course
            builder.HasOne(r => r.Course)
                .WithMany(r => r.Enrollments)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
