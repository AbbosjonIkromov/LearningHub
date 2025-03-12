using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities;

namespace LearningHub.DataAccess.Repository.Contracts
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAll();
        Task<Category>? GetById(int id);
        Task Create(Category category);
        Task Update(Category category);
        Task Delete(Category category);
    }
}
