using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Data;
using LearningHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace LearningHub.Services
{
    public class StudentService
    {
        private readonly LearningHubDbContext _context;
        public StudentService(LearningHubDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return _context.Students;
        }

        public async Task<List<Enrollment>> GetEnrollmentsForStudent(int id)
        {
            var student  = await _context.Students
                .Include(r => r.Enrollments)
                .ThenInclude(r => r.Course)
                .FirstOrDefaultAsync(r => r.StudentId == id);

            if (student is null) return new List<Enrollment>();

            return student.Enrollments.ToList();
        }
        public async Task AddStudent(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task<Student> GetById(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public int SaveChanges => _context.SaveChanges();


    }
}
