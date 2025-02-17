using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Data.Interceptor;
using LearningHub.Data.ModelBuilderExtension;
using LearningHub.Entities;
using LearningHub.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LearningHub.Data
{
    public class LearningHubDbContext : DbContext
    {
        private readonly string _connectionString =
            "Host=localhost;Port=5432;Database=learning_hub; User Id=postgres;Password=postgresql;";
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .UseSnakeCaseNamingConvention()
                .AddInterceptors(new AuditInterceptor());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IEntityTypeConfiguration dan voris olgan class larni congifigu methodini iwlatib yuboradi 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // DataSeeding 
            modelBuilder.Seeding();
           
        }
    }
}
