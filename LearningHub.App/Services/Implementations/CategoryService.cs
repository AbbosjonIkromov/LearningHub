using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Category;
using LearningHub.App.Services.Contracts;
using LearningHub.DataAccess.Repository.Contracts;
using LearningHub.Entities;

namespace LearningHub.App.Services.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var categories = await _categoryRepository.GetAll();

            return categories.Select(c => new CategoryDto
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName
            });
        }

        public async Task<CategoryDto>? GetById(int id)
        {
            var  category = await _categoryRepository.GetById(id);

            if (category is null)
            {
                throw new KeyNotFoundException($"Category with {id} not found");
            }

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public async Task<CategoryDto> Create(CreateCategoryDto createCategoryDto)
        {
            var category = new Category
            {
                CategoryName = createCategoryDto.CategoryName
            };

            await _categoryRepository.Create(category);

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public  async Task<CategoryDto>? Update(int id, UpdateCategoryDto updateCategoryDto)
        {
            var category = await _categoryRepository.GetById(id);
            
            if(category is null)
            {
                throw new KeyNotFoundException($"Category with {id} not found");
            }

            category.CategoryName = updateCategoryDto.CategoryName;
            await _categoryRepository.Update(category);

            return new CategoryDto
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName
            };
        }

        public async Task<bool> Delete(int id)
        {
            var category = await _categoryRepository.GetById(id);

            if (category is null)
            {
                throw new KeyNotFoundException($"Category with {id} not found");
            }
            await _categoryRepository.Delete(category);
            return true;
        }
    }
}
