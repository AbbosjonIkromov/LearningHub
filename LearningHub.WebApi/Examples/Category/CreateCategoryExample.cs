using LearningHub.App.Dtos.Category;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Category
{
    public class CreateCategoryExample : IExamplesProvider<CreateCategoryDto>
    {
        public CreateCategoryDto GetExamples()
        {
            return new CreateCategoryDto
            {
                CategoryName = "Education"
            };
        }
    }
}
