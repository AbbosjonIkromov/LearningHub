using LearningHub.App.Dtos.Instructor;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Instructor
{
    public class UpdateInstructorExample : IExamplesProvider<UpdateInstructorDto>
    {
        public UpdateInstructorDto GetExamples()
        {
            return new UpdateInstructorDto
            {
                FirstName = "Abbosjon",
                LastName = "Ikromov",
                Email = "abbosjonIkromov25@mail.com",
                PhoneNumber = "94 336 56 55",
                HireDate = DateTime.Parse("2025-01-24")
            };
        }
    }
}
