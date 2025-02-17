using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Data;
using LearningHub.Entities;

namespace LearningHub.Services
{
    public class CourseInstructorService
    {
        private readonly LearningHubDbContext _context;
        public CourseInstructorService(LearningHubDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<CourseInstructor>> GetAll()
        {
            return new List<CourseInstructor>();
        }
    }
}
