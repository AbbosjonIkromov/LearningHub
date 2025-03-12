using LearningHub.App.Dtos.Student;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Student
{
    public class UpdateStudentExample : IExamplesProvider<UpdateStudentDto>
    {
        public UpdateStudentDto GetExamples()
        {
            return new UpdateStudentDto
            {
                FirstName = "Abbosjon",
                LastName = "Ikromov",
                Email = "abbosjonIkromov25@gmail.com",
                PhoneNumber = "94 336 56 55",
                Address = "Tashkent Yunisabad 2/32/38",
                DateOfBirth = DateTime.Parse("2025-01-19"),
            };
        }
    }
}
