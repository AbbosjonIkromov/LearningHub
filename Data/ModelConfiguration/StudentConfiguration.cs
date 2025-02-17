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
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Pk
            builder.HasKey(r => r.StudentId);
            // Identity
            builder.Property(r => r.StudentId)
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
                .IsUnique(); // Email wu holatda unique qilamiz

            builder.Property(r => r.PhoneNumber)
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(r => r.Address)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(r => r.DateOfBirth)
                .HasColumnType("date");

        }
    }
}
