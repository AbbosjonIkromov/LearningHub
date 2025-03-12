using LearningHub.App.Dtos.Category;
using Swashbuckle.AspNetCore.Filters;

namespace LearningHub.WebApi.Examples.Category
{
    public class UpdateCategoryExample : IExamplesProvider<UpdateCategoryDto>
    {
        public UpdateCategoryDto GetExamples()
        {
            return new UpdateCategoryDto
            {
                CategoryName = "Education"
            };
        }
    }
}
