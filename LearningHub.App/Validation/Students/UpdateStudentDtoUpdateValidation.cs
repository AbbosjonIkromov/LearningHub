using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LearningHub.App.Dtos.Student;

namespace LearningHub.App.Validation.Students
{
    public class UpdateStudentDtoUpdateValidation : AbstractValidator<UpdateStudentDto>
    {
        public UpdateStudentDtoUpdateValidation()
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
                .MaximumLength(50);

            RuleFor(r => r.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required")
                .MaximumLength(15);

            RuleFor(r => r.Address)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(r => r.DateOfBirth)
                .NotEmpty()
                .WithMessage("Date of birth is required")
                .LessThan(DateTime.Now)
                .WithMessage("Date of birth must be in the past.");

        }
    }
}
