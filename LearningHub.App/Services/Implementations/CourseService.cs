using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Course;
using LearningHub.App.Exceptions;
using LearningHub.App.Services.Contracts;
using LearningHub.DataAccess.Repository.Contracts;
using LearningHub.Entities;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace LearningHub.App.Services.Implementations
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public async Task<IEnumerable<CourseDto>> GetAll()
        {
            var courses = await _courseRepository.GetAll();

            return courses.Select(c => new CourseDto
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                CategoryId = c.CategoryId,
                DifficultyLevel = c.DifficultyLevel,
                Price = c.Price

            });
        }

        public async Task<CourseDto>? GetById(int id)
        {
            var course = await _courseRepository.GetById(id);

            if (course is null)
            {
                throw new RecordNotFoundException($"Course with {id} not found");
            }

            return new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CategoryId = course.CategoryId,
                DifficultyLevel = course.DifficultyLevel,
                Price = course.Price
            };
        }

        public async Task<CourseDto> Create(CreateCourseDto createCourseDto)
        {
            var course = new Course
            {
                CourseName = createCourseDto.CourseName,
                CategoryId = createCourseDto.CategoryId,
                DifficultyLevel = createCourseDto.DifficultyLevel,
                Price = createCourseDto.Price
            };

            await _courseRepository.Create(course);

            return new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CategoryId = course.CategoryId,
                DifficultyLevel = course.DifficultyLevel,
                Price = course.Price
            };
        }

        public async Task<CourseDto>? Update(int id, UpdateCourseDto updateCourseDto)
        {
            var course = await _courseRepository.GetById(id);

            if (course is null)
            {
                throw new RecordNotFoundException($"Course with {id} not found");
            }

            course.CourseName = updateCourseDto.CourseName;
            course.CategoryId = updateCourseDto.CategoryId;
            course.DifficultyLevel = updateCourseDto.DifficultyLevel;
            course.Price = updateCourseDto.Price;

            await _courseRepository.Update(course);

            return new CourseDto
            {
                CourseId = course.CourseId,
                CourseName = course.CourseName,
                CategoryId = course.CategoryId,
                DifficultyLevel = course.DifficultyLevel,
                Price = course.Price
            };
        }

        public async Task<bool> Delete(int id)
        {
            var course = await _courseRepository.GetById(id);

            if (course is null)
            {
                throw new RecordNotFoundException($"Course with {id} not found");
            }

            await _courseRepository.Delete(course);
            return true;
        }
    }
}
