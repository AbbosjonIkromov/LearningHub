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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LearningHubDbContext _context;

        public CategoryRepository(LearningHubDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories
                .AsNoTracking()
                .Where(r => r.Active)
                .OrderByDescending(r => r.CategoryId)
                .ToListAsync();
        }

        public async Task<Category>? GetById(int id)
        { 
            return await _context.Categories
                .FirstOrDefaultAsync(r => r.CategoryId == id);
        }

        public async Task Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Category category)
        {
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
        }
    }
}
