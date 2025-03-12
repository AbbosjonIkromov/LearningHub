using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities.Enums;
using LearningHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Data.ModelBuilderExtension
{
    public static class ModelBuilderExtensions
    {
        public static void Seeding(this ModelBuilder modelBuilder)
        {
            #region DataSeeding
            modelBuilder.Entity<Category>()
                .HasData(
                    new Category
                    {
                        CategoryId = 1,
                        CategoryName = "AI",
                    });

            modelBuilder.Entity<Course>()
                .HasData(
                    new Course
                    {
                        CourseId = 1,
                        CourseName = "Python AI",
                        CategoryId = 1,
                        DifficultyLevel = DifficultyLevel.Easy,
                        Price = 1500_000
                    });

            modelBuilder.Entity<Student>()
                .HasData(
                    new Student
                    {
                        StudentId = 1,
                        FirstName = "Abbosjon",
                        LastName = "Ikromov",
                        Email = "abbosjon25@gmail.com",
                        PhoneNumber = "99-989 - 89 - 98",
                        Address = "Tashkent, Yunisabad",
                        DateOfBirth = new DateTime(2003, 9, 25)
                    });

            modelBuilder.Entity<Instructor>()
                .HasData(
                    new Instructor
                    {
                        InstructorId = 1,
                        FirstName = "Jasur",
                        LastName = "Erkinov",
                        Email = "jasurErkinov@gmail.com",
                        PhoneNumber = "88 888 - 99 - 88",

                    });

            modelBuilder.Entity<Enrollment>()
                .HasData(
                    new Enrollment
                    {
                        EnrollmentId = 1,
                        StudentId = 1,
                        CourseId = 1,
                        CompletionStatus = CompletionStatus.InProgress,
                        Score = 4.1m,

                    });

            modelBuilder.Entity<CourseInstructor>()
                .HasData(
                    new CourseInstructor
                    {
                        InstructorId = 1,
                        CourseId = 1,
                    });
            #endregion
        }

    }
}
