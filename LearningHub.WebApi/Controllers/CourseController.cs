using FluentValidation;
using LearningHub.App.Dtos.Course;
using LearningHub.App.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly IValidator<CreateCourseDto> _createCourseValidator;
        private readonly IValidator<UpdateCourseDto> _updateCourseValidator;

        public CourseController(ICourseService courseService,
            IValidator<CreateCourseDto> createCourseValidator,
            IValidator<UpdateCourseDto> updateCourseValidator)
        {
            _courseService = courseService;
            _createCourseValidator = createCourseValidator;
            _updateCourseValidator = updateCourseValidator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var courses = await _courseService.GetAll();

            return Ok(courses);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var course = await _courseService.GetById(id);
            return Ok(course);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateCourseDto createCourseDto)
        {
            var validation = await _createCourseValidator.ValidateAsync(createCourseDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var course = await _courseService.Create(createCourseDto);
            return Ok(course);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateCourseDto updateCourseDto)
        {
            var validation = await _updateCourseValidator.ValidateAsync(updateCourseDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var course = await _courseService.Update(id, updateCourseDto);
            return Ok(course);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var course = await _courseService.Delete(id);
            return Ok(course);
        }
    }
}
