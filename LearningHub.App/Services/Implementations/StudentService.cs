using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Student;
using LearningHub.App.Services.Contracts;
using LearningHub.DataAccess.Repository.Contracts;
using LearningHub.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace LearningHub.App.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public async Task<IEnumerable<StudentDto>> GetAll()
        {
            var students = await _studentRepository.GetAll();

            return students
                .Select(s => new StudentDto
                {
                    StudentId = s.StudentId,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    Email = s.Email,
                    PhoneNumber = s.PhoneNumber,
                    Address = s.Address,
                    DateOfBirth = s.DateOfBirth
                });
        }

        public async Task<StudentDto>? GetById(int id)
        {
            var student = await _studentRepository.GetById(id);

            if (student is null)
            {
                throw new KeyNotFoundException($"Student with {id} not found");
            }

            return new StudentDto
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth
            };
        }

        public async Task<StudentDto> Create(CreateStudentDto createStudentDto)
        {
            var student = new Student
            {
                FirstName = createStudentDto.FirstName,
                LastName = createStudentDto.LastName,
                Email = createStudentDto.Email,
                PhoneNumber = createStudentDto.PhoneNumber,
                Address = createStudentDto.Address,
                DateOfBirth = createStudentDto.DateOfBirth
            };

            await _studentRepository.Create(student);

            return new StudentDto
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth
            };
        }

        public async Task<StudentDto>? Update(int id, UpdateStudentDto updateStudentDto)
        {
            var student = await _studentRepository.GetById(id);

            if (student is null)
            {
                throw new KeyNotFoundException($"Student with {id} not found"); 
            }

            student.FirstName = updateStudentDto.FirstName;
            student.LastName = updateStudentDto.LastName;
            student.Email = updateStudentDto.Email;
            student.PhoneNumber = updateStudentDto.PhoneNumber;
            student.Address = updateStudentDto.Address;
            student.DateOfBirth = updateStudentDto.DateOfBirth;

            await _studentRepository.Update(student);

            return new StudentDto
            {
                StudentId = student.StudentId,
                FirstName = student.FirstName,
                LastName = student.LastName,
                Email = student.Email,
                PhoneNumber = student.PhoneNumber,
                Address = student.Address,
                DateOfBirth = student.DateOfBirth
            };
        }

        public async Task<bool> Delete(int id)
        {
            var student = await _studentRepository.GetById(id);

            if (student is null)
            {
                throw new KeyNotFoundException($"Student with {id} not found");
            }

            await _studentRepository.Delete(student);
            return true;
        }
    }
}
