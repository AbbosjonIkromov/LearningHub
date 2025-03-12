using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.App.Dtos.Category;

namespace LearningHub.App.Services.Contracts
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();
        Task<CategoryDto>? GetById(int id);
        Task<CategoryDto> Create(CreateCategoryDto createCategoryDto);
        Task<CategoryDto>? Update(int id, UpdateCategoryDto updateCategoryDto);
        Task<bool> Delete(int id);
    }
}
