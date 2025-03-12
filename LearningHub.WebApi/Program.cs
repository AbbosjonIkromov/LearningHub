using FluentValidation;
using FluentValidation.AspNetCore;
using LearningHub.App.Dtos.Category;
using LearningHub.App.Dtos.Course;
using LearningHub.App.Dtos.Enrollment;
using LearningHub.App.Dtos.Instructor;
using LearningHub.App.Dtos.Student;
using LearningHub.App.Services.Contracts;
using LearningHub.App.Services.Implementations;
using LearningHub.App.Validation.Categories;
using LearningHub.App.Validation.Courses;
using LearningHub.App.Validation.Enrollments;
using LearningHub.App.Validation.Instructors;
using LearningHub.App.Validation.Students;
using LearningHub.Data.Interceptor;
using LearningHub.DataAccess;
using LearningHub.DataAccess.Repository.Contracts;
using LearningHub.DataAccess.Repository.Implementations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging.Abstractions;

namespace LearningHub.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen();

            // Repositories
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICourseRepository, CourseRepository>();
            builder.Services.AddScoped<IEnrollmentRepository, EnrollmentRepository>();
            builder.Services.AddScoped<IInstructorRepository, InstructorRepository>();
            builder.Services.AddScoped<IStudentRepository, StudentRepository>();

            // Services
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICourseService, CourseService>();
            builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();
            builder.Services.AddScoped<IInstructorService, InstructorService>();
            builder.Services.AddScoped<IStudentService, StudentService>();

           // FluentValidation
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddValidatorsFromAssemblyContaining<CreateCategoryDto>();


            //builder.Services.AddScoped<IValidator<CreateCategoryDto>, CreateCategoryDtoValidation>();
            //builder.Services.AddScoped<IValidator<UpdateCategoryDto>, UpdateCategoryDtoValidation>();
            //builder.Services.AddScoped<IValidator<CreateCourseDto>, CreateCourseDtoValidation>();
            //builder.Services.AddScoped<IValidator<UpdateCourseDto>, UpdateCourseDtoValidation>();
            //builder.Services.AddScoped<IValidator<CreateStudentDto>, CreateStudentDtoValidation>();
            //builder.Services.AddScoped<IValidator<UpdateStudentDto>, UpdateStudentDtoUpdateValidation>();
            //builder.Services.AddScoped<IValidator<CreateInstructorDto>, CreateInstructorDtoValidation>();
            //builder.Services.AddScoped<IValidator<UpdateInstructorDto>, UpdateInstructorDtoValidation>();
            //builder.Services.AddScoped<IValidator<CreateEnrollmentDto>, CreateEnrollmentDtoValidation>();
            //builder.Services.AddScoped<IValidator<UpdateEnrollmentDto>, UpdateEnrollmentDtoValidation>();


            builder.Services.AddDbContext<LearningHubDbContext>(options =>
            {
                options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
                    .UseSnakeCaseNamingConvention()
                    .AddInterceptors(new AuditInterceptor()); ;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.MapControllers();

            app.Run();
        }
    }
}
