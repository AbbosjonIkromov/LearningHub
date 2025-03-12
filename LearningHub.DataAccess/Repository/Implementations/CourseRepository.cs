using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.DataAccess.Repository.Contracts;
using LearningHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.DataAccess.Repository.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly LearningHubDbContext _context;

        public CourseRepository(LearningHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Course>> GetAll()
        {
            return await _context.Courses
                .AsNoTracking()
                .Where(r => r.Active)
                .OrderByDescending(r => r.CourseId)
                .ToListAsync();
        }

        public async Task<Course>? GetById(int id)
        {
            return await _context.Courses
                .FirstOrDefaultAsync(r => r.CourseId == id);
        }

        public async Task Create(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Course course)
        {
            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Course course)
        {
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }
    }
}
