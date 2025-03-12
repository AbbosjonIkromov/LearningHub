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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly LearningHubDbContext _context;

        public EnrollmentRepository(LearningHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            return await _context.Enrollments
                .AsNoTracking()
                .Where(r => r.Active)
                .OrderByDescending(r => r.EnrollmentId)
                .ToListAsync();
        }

        public async Task<Enrollment>? GetById(int id)
        { 
            return await _context.Enrollments
                .FirstOrDefaultAsync(r => r.EnrollmentId == id);
        }

        public async Task Create(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Enrollment enrollment)
        {
            _context.Enrollments.Update(enrollment);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Enrollment enrollment)
        {
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}
