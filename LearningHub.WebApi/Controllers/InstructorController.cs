using FluentValidation;
using LearningHub.App.Dtos.Instructor;
using LearningHub.App.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        private readonly IValidator<CreateInstructorDto> _createInstructorValidator;
        private readonly IValidator<UpdateInstructorDto> _updateInstructorValidator;

        public InstructorController(IInstructorService instructorService,
            IValidator<CreateInstructorDto> createInstructorValidator,
            IValidator<UpdateInstructorDto> updateInstructorValidator)
        {
            _instructorService = instructorService;
            _createInstructorValidator = createInstructorValidator;
            _updateInstructorValidator = updateInstructorValidator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var instructors = await _instructorService.GetAll();
            return Ok(instructors);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var instructor = await _instructorService.GetById(id);
            return Ok(instructor);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateInstructorDto createInstructorDto)
        {
            var validation = await _createInstructorValidator.ValidateAsync(createInstructorDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var instructor = await _instructorService.Create(createInstructorDto);
            return Ok(instructor);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateInstructorDto updateInstructorDto)
        {
            var validation = await _updateInstructorValidator.ValidateAsync(updateInstructorDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var instructor = await _instructorService.Update(id, updateInstructorDto);
            return Ok(instructor);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var isDeleted = await _instructorService.Delete(id);
            return Ok(isDeleted);
        }
    }
}
