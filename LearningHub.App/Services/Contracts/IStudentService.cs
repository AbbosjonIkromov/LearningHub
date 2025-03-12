using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Student;

namespace LearningHub.App.Services.Contracts
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentDto>> GetAll();
        Task<StudentDto>? GetById(int id);
        Task<StudentDto> Create(CreateStudentDto createStudentDto);
        Task<StudentDto>? Update(int id, UpdateStudentDto updateStudentDto);
        Task<bool> Delete(int id);
    }
}
