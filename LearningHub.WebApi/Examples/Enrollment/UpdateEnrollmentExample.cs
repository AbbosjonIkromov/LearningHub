using LearningHub.App.Dtos.Enrollment;
using LearningHub.Entities.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Enrollment
{
    public class UpdateEnrollmentExample : IExamplesProvider<UpdateEnrollmentDto>
    {
        public UpdateEnrollmentDto GetExamples()
        {
            return new UpdateEnrollmentDto
            {
                StudentId = 25,
                CourseId = 14,
                CompletionStatus = CompletionStatus.InProgress,
                Score = 45.50m
            };
        }
    }
}
