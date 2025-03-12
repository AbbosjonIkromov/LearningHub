using FluentValidation;
using LearningHub.App.Dtos.Student;
using LearningHub.App.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IValidator<CreateStudentDto> _createStudentValidator;
        private readonly IValidator<UpdateStudentDto> _updateStudentValidator;

        public StudentController(IStudentService studentService,
            IValidator<CreateStudentDto> createStudentValidator,
            IValidator<UpdateStudentDto> updateStudentValidator)
        {
            _studentService = studentService;
            _createStudentValidator = createStudentValidator;
            _updateStudentValidator = updateStudentValidator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAll();
            return Ok(students);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var student = await _studentService.GetById(id);
            return Ok(student);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateStudentDto createStudentDto)
        {
            var validation = await _createStudentValidator.ValidateAsync(createStudentDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var student = await _studentService.Create(createStudentDto);
            return Ok(student);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateStudentDto updateStudentDto)
        {
            var validation = await _updateStudentValidator.ValidateAsync(updateStudentDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var student = await _studentService.Update(id, updateStudentDto);
            return Ok(student);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var isDeleted = await _studentService.Delete(id);
            return Ok(isDeleted);
        }
    }
}
