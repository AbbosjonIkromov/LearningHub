using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using LearningHub.App.Dtos.Enrollment;
using LearningHub.App.Services.Contracts;

namespace LearningHub.App.Validation.Enrollments
{
    public class UpdateEnrollmentDtoValidation : AbstractValidator<UpdateEnrollmentDto>
    {
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public UpdateEnrollmentDtoValidation(IStudentService studentService, ICourseService courseService)
        {
            _studentService = studentService;
            _courseService = courseService;

            RuleFor(r => r.StudentId)
                .MustAsync(StudentExists)
                .WithMessage("StudentId does not exist");

            RuleFor(r => r.CourseId)
                .MustAsync(CourseExists)
                .WithMessage("CourseId does not exist");

            RuleFor(r => r.CompletionStatus)
                .IsInEnum();

            RuleFor(r => r.Score)
                .InclusiveBetween(0, 100);
        }

        private async Task<bool> CourseExists(int arg1, CancellationToken arg2)
        {
            var course = await _courseService.GetById(arg1);
            return course != null;
        }

        private async Task<bool> StudentExists(int id, CancellationToken arg2)
        {
            var student = await _studentService.GetById(id);
            return student != null;
        }
    }
}
