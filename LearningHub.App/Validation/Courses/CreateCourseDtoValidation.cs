using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LearningHub.App.Dtos.Course;
using LearningHub.App.Services.Contracts;

namespace LearningHub.App.Validation.Courses
{
    public class CreateCourseDtoValidation : AbstractValidator<CreateCourseDto>
    {
        private readonly ICategoryService _categoryService;

        public CreateCourseDtoValidation(ICategoryService categoryService)
        {
            _categoryService = categoryService;


            RuleFor(r => r.CourseName)
                .NotEmpty()
                .WithMessage("Course name is required")
                .MaximumLength(255);

            RuleFor(r => r.CategoryId)
                .NotEmpty()
                .WithMessage("Category is required")
                .MustAsync(CategoryExists)
                .WithMessage("CategoryId does not exist");

            RuleFor(r => r.DifficultyLevel)
                .NotEmpty()
                .WithMessage("Difficulty level is required")
                .IsInEnum();

            RuleFor(r => r.Price)
                .NotEmpty()
                .WithMessage("Price is required")
                .GreaterThan(0);
        }

        private async Task<bool> CategoryExists(int id, CancellationToken arg2)
        {
            var category = await _categoryService.GetById(id);
            return category != null;
        }
    }
}
