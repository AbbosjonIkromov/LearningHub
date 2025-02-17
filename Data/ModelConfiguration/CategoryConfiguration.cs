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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(r => r.CategoryId);
            builder.Property(r => r.CategoryId)
                .ValueGeneratedOnAdd();

            builder.Property(r => r.CategoryName)
                .HasMaxLength(255)
                .IsRequired();

        }
    }
}
