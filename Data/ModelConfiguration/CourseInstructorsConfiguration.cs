using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningHub.Data.ModelConfiguration
{
    public class CourseInstructorsConfiguration : IEntityTypeConfiguration<CourseInstructor>
    {
        public void Configure(EntityTypeBuilder<CourseInstructor> builder)
        {
            builder.HasKey(r => new { r.CourseId, r.InstructorId });

            builder.HasOne(r => r.Course)
                .WithMany(r => r.CourseInstructors)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Instructor)
                .WithMany(r => r.CourseInstructors)
                .HasForeignKey(r => r.InstructorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
