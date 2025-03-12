using FluentValidation;
using LearningHub.App.Dtos.Category;
using LearningHub.App.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IValidator<CreateCategoryDto> _createCategoryValidator;
        private readonly IValidator<UpdateCategoryDto> _updateCategoryValidator;

        public CategoryController(ICategoryService categoryService,
            IValidator<CreateCategoryDto> createCategoryValidator,
            IValidator<UpdateCategoryDto> updateCategoryValidator)
        {
            _categoryService = categoryService;
            _createCategoryValidator = createCategoryValidator;
            _updateCategoryValidator = updateCategoryValidator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetAll();

            return Ok(categories);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var category = await _categoryService.GetById(id);
            return Ok(category);
        }


        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoryDto createCategoryDto)
        {
            var validation = await _createCategoryValidator.ValidateAsync(createCategoryDto);

            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .Select(r => new
                    {
                        r.PropertyName,
                        r.ErrorMessage
                    });
                return BadRequest(errors);
            }

            var category = await _categoryService.Create(createCategoryDto);
            return Ok(category);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var validation = await _updateCategoryValidator.ValidateAsync(updateCategoryDto);

            if (!validation.IsValid)
            {
                var errors = validation.Errors
                    .Select(r => new
                    {
                        r.PropertyName,
                        r.ErrorMessage
                    });
                return BadRequest(errors);
            }

            var category = await _categoryService.Update(id, updateCategoryDto);
            return Ok(category);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var isDeleted = await _categoryService.Delete(id);
            return Ok(isDeleted);
        }
    }
}
