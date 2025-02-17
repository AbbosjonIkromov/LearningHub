using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Data;
using LearningHub.Entities;

namespace LearningHub.Services
{
    public class CategoryService
    {
        private readonly LearningHubDbContext _context;
        public CategoryService(LearningHubDbContext dbContext)
        {
            _context = dbContext;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories;
        }

        public async Task AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public async Task<Category> GetBtId(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public int SaveChanges() => _context.SaveChanges();
    }
}
