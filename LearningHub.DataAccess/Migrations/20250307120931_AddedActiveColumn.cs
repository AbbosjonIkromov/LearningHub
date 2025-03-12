using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningHub.Migrations
{
    /// <inheritdoc />
    public partial class AddedActiveColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "course_instructor",
                keyColumns: new[] { "course_id", "instructor_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "enrollments",
                keyColumn: "enrollment_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "courses",
                keyColumn: "course_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "instructors",
                keyColumn: "instructor_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "students",
                keyColumn: "student_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "categories",
                keyColumn: "category_id",
                keyValue: 1);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "students",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "instructors",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "completion_status",
                table: "enrollments",
                type: "text",
                nullable: true,
                defaultValue: "NotStarted",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "NotStarted");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "enrollments",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "difficulty_level",
                table: "courses",
                type: "text",
                nullable: true,
                defaultValue: "Medium",
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "Medium");

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "courses",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<bool>(
                name: "active",
                table: "categories",
                type: "boolean",
                nullable: false,
                defaultValue: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "active",
                table: "students");

            migrationBuilder.DropColumn(
                name: "active",
                table: "instructors");

            migrationBuilder.DropColumn(
                name: "active",
                table: "enrollments");

            migrationBuilder.DropColumn(
                name: "active",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "active",
                table: "categories");

            migrationBuilder.AlterColumn<string>(
                name: "completion_status",
                table: "enrollments",
                type: "text",
                nullable: false,
                defaultValue: "NotStarted",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "NotStarted");

            migrationBuilder.AlterColumn<string>(
                name: "difficulty_level",
                table: "courses",
                type: "text",
                nullable: false,
                defaultValue: "Medium",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldDefaultValue: "Medium");

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "category_id", "category_name", "created_at", "updated_at" },
                values: new object[] { 1, "AI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.InsertData(
                table: "instructors",
                columns: new[] { "instructor_id", "created_at", "email", "first_name", "hire_date", "last_name", "phone_number", "updated_at" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jasurErkinov@gmail.com", "Jasur", null, "Erkinov", "88 888 - 99 - 88", null });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "student_id", "address", "created_at", "date_of_birth", "email", "first_name", "last_name", "phone_number", "updated_at" },
                values: new object[] { 1, "Tashkent, Yunisabad", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2003, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "abbosjon25@gmail.com", "Abbosjon", "Ikromov", "99-989 - 89 - 98", null });

            migrationBuilder.InsertData(
                table: "courses",
                columns: new[] { "course_id", "category_id", "course_name", "created_at", "difficulty_level", "price", "updated_at" },
                values: new object[] { 1, 1, "Python AI", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Easy", 1500000m, null });

            migrationBuilder.InsertData(
                table: "course_instructor",
                columns: new[] { "course_id", "instructor_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "enrollments",
                columns: new[] { "enrollment_id", "completion_status", "course_id", "created_at", "score", "student_id", "updated_at" },
                values: new object[] { 1, "InProgress", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4.1m, 1, null });
        }
    }
}
