using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities;

namespace LearningHub.DataAccess.Repository.Contracts
{
    public interface IStudentRepository
    {
        Task<IEnumerable<Student>> GetAll();
        Task<Student>? GetById(int id);
        Task Create(Student student);
        Task Update(Student student);
        Task Delete(Student student);
    }
}
