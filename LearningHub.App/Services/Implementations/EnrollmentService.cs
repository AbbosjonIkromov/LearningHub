using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Enrollment;
using LearningHub.App.Exceptions;
using LearningHub.App.Services.Contracts;
using LearningHub.DataAccess.Repository.Contracts;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace LearningHub.App.Services.Implementations
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }
        public async Task<IEnumerable<EnrollmentDto>> GetAll()
        {
            var enrollments = await _enrollmentRepository.GetAll();

            return enrollments
                .Select(e => new EnrollmentDto
                {
                    EnrollmentId = e.EnrollmentId,
                    CourseId = e.CourseId,
                    StudentId = e.StudentId,
                    CompletionStatus = e.CompletionStatus,
                    Score = e.Score
                });
        }

        public async Task<EnrollmentDto>? GetById(int id)
        {
            var enrollment = await _enrollmentRepository.GetById(id);

            if (enrollment is null)
            {
                throw new RecordNotFoundException($"Enrollment with {id} not found");
            }

            return new EnrollmentDto
            {
                EnrollmentId = enrollment.EnrollmentId,
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId,
                CompletionStatus = enrollment.CompletionStatus,
                Score = enrollment.Score
            };
        }

        public async Task<EnrollmentDto> Create(CreateEnrollmentDto createCourseDto)
        {
            var enrollment = new Entities.Enrollment
            {
                CourseId = createCourseDto.CourseId,
                StudentId = createCourseDto.StudentId,
                CompletionStatus = createCourseDto.CompletionStatus,
                Score = createCourseDto.Score
            };

            await _enrollmentRepository.Create(enrollment);

            return new EnrollmentDto
            {
                EnrollmentId = enrollment.EnrollmentId,
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId,
                CompletionStatus = enrollment.CompletionStatus,
                Score = enrollment.Score
            };

        }

        public async Task<EnrollmentDto>? Update(int id, UpdateEnrollmentDto updateCourseDto)
        {
            var enrollment = await _enrollmentRepository.GetById(id);

            if (enrollment is null)
            {
                throw new RecordNotFoundException($"Enrollment with {id} not found");
            }

            enrollment.CourseId = updateCourseDto.CourseId;
            enrollment.StudentId = updateCourseDto.StudentId;
            enrollment.CompletionStatus = updateCourseDto.CompletionStatus;
            enrollment.Score = updateCourseDto.Score;

            await _enrollmentRepository.Update(enrollment);

            return new EnrollmentDto
            {
                EnrollmentId = enrollment.EnrollmentId,
                CourseId = enrollment.CourseId,
                StudentId = enrollment.StudentId,
                CompletionStatus = enrollment.CompletionStatus,
                Score = enrollment.Score
            };
        }

        public async Task<bool> Delete(int id)
        {
            var enrollment = await _enrollmentRepository.GetById(id);

            if (enrollment is null)
            {
                throw new RecordNotFoundException($"Enrollment with {id} not found");
            }

            await _enrollmentRepository.Delete(enrollment);
            return true;
        }
    }
}
