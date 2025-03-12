using FluentValidation;
using LearningHub.App.Dtos.Enrollment;
using LearningHub.App.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IValidator<CreateEnrollmentDto> _createEnrollmentValidator;
        private readonly IValidator<UpdateEnrollmentDto> _updateEnrollmentValidator;

        public EnrollmentController(IEnrollmentService enrollmentService,
            IValidator<CreateEnrollmentDto> createEnrollmentValidator,
            IValidator<UpdateEnrollmentDto> updateEnrollmentValidator)
        {
            _enrollmentService = enrollmentService;
            _createEnrollmentValidator = createEnrollmentValidator;
            _updateEnrollmentValidator = updateEnrollmentValidator;
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {
            var enrollments = await _enrollmentService.GetAll();
            return Ok(enrollments);
        }

        [HttpGet("get-by-id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            var enrollment = await _enrollmentService.GetById(id);
            return Ok(enrollment);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateEnrollmentDto createEnrollmentDto)
        {
            var validation = await _createEnrollmentValidator.ValidateAsync(createEnrollmentDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var enrollment = await _enrollmentService.Create(createEnrollmentDto);
            return Ok(enrollment);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] int id, [FromBody] UpdateEnrollmentDto updateEnrollmentDto)
        {
            var validation = await _updateEnrollmentValidator.ValidateAsync(updateEnrollmentDto);

            if (!validation.IsValid)
            {
                return BadRequest(validation.Errors);
            }

            var enrollment = await _enrollmentService.Update(id, updateEnrollmentDto);
            return Ok(enrollment);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            var isDeleted = await _enrollmentService.Delete(id);
            return Ok(isDeleted);
        }
    }
}
