using LearningHub.App.Dtos.Enrollment;
using LearningHub.Entities.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Enrollment
{
    public class CreateEnrollmentExample : IExamplesProvider<CreateEnrollmentDto>
    {
        public CreateEnrollmentDto GetExamples()
        {
            return new CreateEnrollmentDto
            {
                StudentId = 25,
                CourseId = 14,
                CompletionStatus = CompletionStatus.InProgress,
                Score = 45.50m
            };
        }
    }
}
