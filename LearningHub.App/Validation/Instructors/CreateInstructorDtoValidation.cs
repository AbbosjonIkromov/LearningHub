using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LearningHub.App.Dtos.Instructor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LearningHub.App.Validation.Instructors
{
    public class CreateInstructorDtoValidation : AbstractValidator<CreateInstructorDto>
    {
        public CreateInstructorDtoValidation()
        {
            RuleFor(r => r.FirstName)
                .NotEmpty()
                .WithMessage("First name is required")
                .MaximumLength(50);

            RuleFor(r => r.LastName)
                .NotEmpty()
                .WithMessage("Last name is required")
                .MaximumLength(50);

            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Email is required")
                .MaximumLength(50)
                .EmailAddress();

            RuleFor(r => r.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required")
                .MaximumLength(15);

            RuleFor(r => r.HireDate)
                .NotEmpty()
                .WithMessage("Hire date is required")
            .LessThan(DateTime.Now)
                .WithMessage("Hire date must be in the past.");
        }
    }
}
