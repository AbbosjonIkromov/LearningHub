using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Instructor;
using LearningHub.App.Exceptions;
using LearningHub.App.Services.Contracts;
using LearningHub.DataAccess.Repository.Contracts;
using LearningHub.Entities;

namespace LearningHub.App.Services.Implementations
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public async Task<IEnumerable<InstructorDto>> GetAll()
        {
            var instructors = await _instructorRepository.GetAll();

            return instructors.Select(instructor => new InstructorDto
            {
                InstructorId = instructor.InstructorId,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                HireDate = instructor.HireDate
            });
        }

        public async Task<InstructorDto>? GetById(int id)
        {
            var instructor = await _instructorRepository.GetById(id);

            if (instructor is null)
            {
                throw new RecordNotFoundException($"Instructor with {id} not found");
            }

            return new InstructorDto()
            {
                InstructorId = instructor.InstructorId,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                HireDate = instructor.HireDate
            };
        }

        public async Task<InstructorDto> Create(CreateInstructorDto createInstructorDto)
        {
            var instructor = new Instructor
            {
                FirstName = createInstructorDto.FirstName,
                LastName = createInstructorDto.LastName,
                Email = createInstructorDto.Email,
                PhoneNumber = createInstructorDto.PhoneNumber,
                HireDate = createInstructorDto.HireDate
            };

            await _instructorRepository.Create(instructor);

            return new InstructorDto
            {
                InstructorId = instructor.InstructorId,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                HireDate = instructor.HireDate
            };

        }

        public async Task<InstructorDto>? Update(int id, UpdateInstructorDto updateInstructorDto)
        {
            var instructor = await _instructorRepository.GetById(id);

            if (instructor is null)
            {
                throw new RecordNotFoundException($"Instructor with {id} not found");
            }

            instructor.FirstName = updateInstructorDto.FirstName;
            instructor.LastName = updateInstructorDto.LastName;
            instructor.Email = updateInstructorDto.Email;
            instructor.PhoneNumber = updateInstructorDto.PhoneNumber;
            instructor.HireDate = updateInstructorDto.HireDate;

            await _instructorRepository.Update(instructor);

            return new InstructorDto
            {
                InstructorId = instructor.InstructorId,
                FirstName = instructor.FirstName,
                LastName = instructor.LastName,
                Email = instructor.Email,
                PhoneNumber = instructor.PhoneNumber,
                HireDate = instructor.HireDate
            };
        }

        public async Task<bool> Delete(int id)
        {
            var instructor = await _instructorRepository.GetById(id);

            if (instructor is null)
            {
                throw new RecordNotFoundException($"Instructor with {id} not found");
            }
            await _instructorRepository.Delete(instructor);
            return true;
        }
    }
}
