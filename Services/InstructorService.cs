using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Data;
using LearningHub.Entities;

namespace LearningHub.Services
{
    public class InstructorService
    { 
        private readonly LearningHubDbContext _context;
        public InstructorService(LearningHubDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Instructor> GetAll()
        {
            return _context.Instructors;
        }

        public async Task AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
        }

        public async Task<Instructor> GetById(int id)
        {
            return await _context.Instructors.FindAsync(id);
        }

        public int SaveChanges() => _context.SaveChanges();
    }
}
