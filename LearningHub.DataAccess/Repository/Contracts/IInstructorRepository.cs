using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities;

namespace LearningHub.DataAccess.Repository.Contracts
{
    public interface IInstructorRepository
    {
        Task<IEnumerable<Instructor>> GetAll();
        Task<Instructor>? GetById(int id);
        Task Create(Instructor instructor);
        Task Update(Instructor instructor);
        Task Delete(Instructor instructor);

    }
}
