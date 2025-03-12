using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities;

namespace LearningHub.DataAccess.Repository.Contracts
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAll();
        Task<Course>? GetById(int id);
        Task Create(Course course);
        Task Update(Course course);
        Task Delete(Course course);
    }
}
