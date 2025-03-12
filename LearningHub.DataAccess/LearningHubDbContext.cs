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
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LearningHub.DataAccess
{
    public class LearningHubDbContext : DbContext
    {
        public LearningHubDbContext(DbContextOptions<LearningHubDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }

        #region OnConfiguring
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var connectionString = "Host=localhost;Port=5432;Database=learning_hub; User Id=postgres;Password=postgresql;";

        //    optionsBuilder.UseNpgsql(connectionString)
        //        .LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuted })
        //        .UseSnakeCaseNamingConvention()
        //        .AddInterceptors(new AuditInterceptor());
        //}
        #endregion  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // IEntityTypeConfiguration dan voris olgan class larni congifigu methodini iwlatib yuboradi 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // DataSeeding 
            //modelBuilder.Seeding();

        }
    }
}


