using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LearningHub.App.Dtos.Category;

namespace LearningHub.App.Validation.Categories
{
    public class CreateCategoryDtoValidation : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidation()
        {
            RuleFor(r => r.CategoryName)
                .NotEmpty()
                .WithMessage("Category name is required")
                .MaximumLength(255);
        }
    }
}
