using LearningHub.Data;
using LearningHub.Entities;
using LearningHub.Entities.Enums;
using LearningHub.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace LearningHub;

internal class Program
{
    static void Main(string[] args)
    {
        using LearningHubDbContext context = new LearningHubDbContext();
        var categoryService = new CategoryService(context);
        var courseService = new CourseService(context);
        var studentService = new StudentService(context);
        var instructorService = new InstructorService(context);
        var enrollmentService = new EnrollmentService(context);

        // Eager loading 
        var cateoryByCategory = context.Categories
            .Include(r => r.Courses)
            .Where(r => r.CategoryId == 44);

        foreach (var category in cateoryByCategory)
        {
            Console.WriteLine($"CategoryId: {category.CategoryId}, CategoryName: {category.CategoryName}");
            foreach (var course in category.Courses)
            {
                Console.WriteLine($"CourseId: {course.CourseId}, CourseName: {course.CourseName}");
            }
        }


        Console.Write("Press any key to exit...");
        Console.ReadKey();
    }
}
