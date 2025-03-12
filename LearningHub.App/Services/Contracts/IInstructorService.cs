using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Instructor;

namespace LearningHub.App.Services.Contracts
{
    public interface IInstructorService
    {
        Task<IEnumerable<InstructorDto>> GetAll();
        Task<InstructorDto>? GetById(int id);
        Task<InstructorDto> Create(CreateInstructorDto createInstructorDto);
        Task<InstructorDto>? Update(int id, UpdateInstructorDto updateInstructorDto);
        Task<bool> Delete(int id);
    }
}
