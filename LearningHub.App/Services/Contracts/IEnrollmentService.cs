using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Enrollment;

namespace LearningHub.App.Services.Contracts
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentDto>> GetAll();
        Task<EnrollmentDto>? GetById(int id);
        Task<EnrollmentDto> Create(CreateEnrollmentDto createCourseDto);
        Task<EnrollmentDto>? Update(int id, UpdateEnrollmentDto updateCourseDto);
        Task<bool> Delete(int id);
    }
}
