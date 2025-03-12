using LearningHub.App.Dtos.Course;
using LearningHub.Entities.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Course
{
    public class UpdateCourseExample : IExamplesProvider<UpdateCourseDto>
    {
        public UpdateCourseDto GetExamples()
        {
            return new UpdateCourseDto
            {
                CourseName = "Software Development",
                CategoryId = 25,
                DifficultyLevel = DifficultyLevel.Easy,
                Price = 99.90m
            };
        }
    }
}
