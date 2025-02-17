using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Data;
using LearningHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Services
{
    public class EnrollmentService
    {
        private readonly LearningHubDbContext _context;
        public EnrollmentService(LearningHubDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<List<Enrollment>> GetAll()
        {
            return await _context.Enrollments
                .Include(r => r.Student)
                .Include(r => r.Course)
                .ToListAsync();
        }

        public async Task AddEnrollment(Enrollment enrollment)
        {
            _context.Enrollments.Add(enrollment);
        }

        public async Task<Enrollment> GetById(int id)
        {
            return await _context.Enrollments.FindAsync(id);
        }

        public int SaveChanges() => _context.SaveChanges();
    }
}
