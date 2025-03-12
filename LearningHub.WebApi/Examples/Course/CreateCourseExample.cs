using LearningHub.App.Dtos.Course;
using LearningHub.Entities.Enums;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Course
{
    public class CreateCourseExample : IExamplesProvider<CreateCourseDto>
    {
        public CreateCourseDto GetExamples()
        {
            return new CreateCourseDto
            {
                CourseName = "Software Development",
                CategoryId = 25,
                DifficultyLevel = DifficultyLevel.Easy,
                Price = 99.90m
            };
        }
    }
}
