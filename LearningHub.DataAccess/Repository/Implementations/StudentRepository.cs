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
    public class StudentRepository : IStudentRepository
    {
        private readonly LearningHubDbContext _context;

        public StudentRepository(LearningHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Student>> GetAll()
        {
            return await _context.Students
                .AsNoTracking()
                .Where(r => r.Active)
                .OrderByDescending(r => r.StudentId)
                .ToListAsync();
        }

        public async Task<Student>? GetById(int id)
        {
            return await _context.Students
                .FirstOrDefaultAsync(r => r.StudentId == id);
        }

        public async Task Create(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Student student)
        {
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Student student)
        {
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
