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
    public class InstructorRepository : IInstructorRepository
    {
        private readonly LearningHubDbContext _context;

        public InstructorRepository(LearningHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Instructor>> GetAll()
        {
            return await _context.Instructors
                .Where(r => r.Active)
                .OrderByDescending(r => r.InstructorId)
                .ToListAsync();
        }

        public async Task<Instructor>? GetById(int id)
        {
            return await _context.Instructors
                .FirstOrDefaultAsync(r => r.InstructorId == id);
        }

        public async Task Create(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Instructor instructor)
        {
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
        }
    }
}
