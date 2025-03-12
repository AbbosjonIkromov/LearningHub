using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Course;

namespace LearningHub.App.Services.Contracts
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseDto>> GetAll();
        Task<CourseDto>? GetById(int id);
        Task<CourseDto> Create(CreateCourseDto createCourseDto);
        Task<CourseDto>? Update(int id, UpdateCourseDto updateCourseDto);
        Task<bool> Delete(int id);
    }
}
