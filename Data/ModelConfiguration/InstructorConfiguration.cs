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
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(r => r.InstructorId);
            builder.Property(r => r.InstructorId)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.FirstName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.LastName)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100)
                .IsRequired();

            builder.HasIndex(r => r.Email)
                .IsUnique();

            builder.Property(r => r.PhoneNumber)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.HireDate)
                .HasColumnType("date");
        }
    }
}
