using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities;

namespace LearningHub.DataAccess.Repository.Contracts
{
    public interface IEnrollmentRepository
    {
        Task<IEnumerable<Enrollment>> GetAll();
        Task<Enrollment>? GetById(int id);
        Task Create(Enrollment enrollment);
        Task Update(Enrollment enrollment);
        Task Delete(Enrollment enrollment);

    }
}
