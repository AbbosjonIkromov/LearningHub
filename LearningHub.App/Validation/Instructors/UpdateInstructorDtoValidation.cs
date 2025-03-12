using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LearningHub.App.Dtos.Instructor;

namespace LearningHub.App.Validation.Instructors
{
    public class UpdateInstructorDtoValidation : AbstractValidator<UpdateInstructorDto>
    {
        public UpdateInstructorDtoValidation()
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
        }
    }
}
