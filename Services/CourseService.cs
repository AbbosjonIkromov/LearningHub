using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Data;
using LearningHub.Entities;

namespace LearningHub.Services
{
    public class CourseService
    {
        private readonly LearningHubDbContext _context;
        public CourseService(LearningHubDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Course> GetAll()
        {
            return _context.Courses;
        }

        public async Task AddCourse(Course course)
        {
            _context.Courses.Add(course);
        }

        public async Task<Course> GetById(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public int SaveChanges() => _context.SaveChanges();
    }
}
