﻿// <auto-generated />
using System;
using LearningHub.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LearningHub.Migrations
{
    [DbContext(typeof(LearningHubDbContext))]
    partial class LearningHubDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LearningHub.Entities.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)")
                        .HasColumnName("category_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("CategoryId")
                        .HasName("pk_categories");

                    b.ToTable("categories", (string)null);

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "AI",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("LearningHub.Entities.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer")
                        .HasColumnName("category_id");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("course_name");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Medium")
                        .HasColumnName("difficulty_level");

                    b.Property<decimal>("Price")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(10, 2)
                        .HasColumnType("numeric(10,2)")
                        .HasDefaultValue(0.00m)
                        .HasColumnName("price");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("CourseId")
                        .HasName("pk_courses");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_courses_category_id");

                    b.ToTable("courses", (string)null);

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CategoryId = 1,
                            CourseName = "Python AI",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DifficultyLevel = "Easy",
                            Price = 1500000m
                        });
                });

            modelBuilder.Entity("LearningHub.Entities.CourseInstructor", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<int>("InstructorId")
                        .HasColumnType("integer")
                        .HasColumnName("instructor_id");

                    b.HasKey("CourseId", "InstructorId")
                        .HasName("pk_course_instructor");

                    b.HasIndex("InstructorId")
                        .HasDatabaseName("ix_course_instructor_instructor_id");

                    b.ToTable("course_instructor", (string)null);

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            InstructorId = 1
                        });
                });

            modelBuilder.Entity("LearningHub.Entities.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("enrollment_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("EnrollmentId"));

                    b.Property<string>("CompletionStatus")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("NotStarted")
                        .HasColumnName("completion_status");

                    b.Property<int>("CourseId")
                        .HasColumnType("integer")
                        .HasColumnName("course_id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<decimal>("Score")
                        .ValueGeneratedOnAdd()
                        .HasPrecision(5, 2)
                        .HasColumnType("numeric(5,2)")
                        .HasDefaultValue(0.00m)
                        .HasColumnName("score");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer")
                        .HasColumnName("student_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("EnrollmentId")
                        .HasName("pk_enrollments");

                    b.HasIndex("CourseId")
                        .HasDatabaseName("ix_enrollments_course_id");

                    b.HasIndex("StudentId")
                        .HasDatabaseName("ix_enrollments_student_id");

                    b.ToTable("enrollments", (string)null);

                    b.HasData(
                        new
                        {
                            EnrollmentId = 1,
                            CompletionStatus = "InProgress",
                            CourseId = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Score = 4.1m,
                            StudentId = 1
                        });
                });

            modelBuilder.Entity("LearningHub.Entities.Instructor", b =>
                {
                    b.Property<int>("InstructorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("instructor_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("InstructorId"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("first_name");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("date")
                        .HasColumnName("hire_date");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("phone_number");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("InstructorId")
                        .HasName("pk_instructors");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_instructors_email");

                    b.ToTable("instructors", (string)null);

                    b.HasData(
                        new
                        {
                            InstructorId = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jasurErkinov@gmail.com",
                            FirstName = "Jasur",
                            LastName = "Erkinov",
                            PhoneNumber = "88 888 - 99 - 88"
                        });
                });

            modelBuilder.Entity("LearningHub.Entities.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("student_id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar")
                        .HasColumnName("address");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("last_name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar")
                        .HasColumnName("phone_number");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("StudentId")
                        .HasName("pk_students");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_students_email");

                    b.ToTable("students", (string)null);

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Address = "Tashkent, Yunisabad",
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOfBirth = new DateTime(2003, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "abbosjon25@gmail.com",
                            FirstName = "Abbosjon",
                            LastName = "Ikromov",
                            PhoneNumber = "99-989 - 89 - 98"
                        });
                });

            modelBuilder.Entity("LearningHub.Entities.Course", b =>
                {
                    b.HasOne("LearningHub.Entities.Category", "Category")
                        .WithMany("Courses")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_courses_categories_category_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("LearningHub.Entities.CourseInstructor", b =>
                {
                    b.HasOne("LearningHub.Entities.Course", "Course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_course_instructor_courses_course_id");

                    b.HasOne("LearningHub.Entities.Instructor", "Instructor")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_course_instructor_instructors_instructor_id");

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("LearningHub.Entities.Enrollment", b =>
                {
                    b.HasOne("LearningHub.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_enrollments_courses_course_id");

                    b.HasOne("LearningHub.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_enrollments_students_student_id");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("LearningHub.Entities.Category", b =>
                {
                    b.Navigation("Courses");
                });

            modelBuilder.Entity("LearningHub.Entities.Course", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("LearningHub.Entities.Instructor", b =>
                {
                    b.Navigation("CourseInstructors");
                });

            modelBuilder.Entity("LearningHub.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
