using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.Entities
{
    public class Category : IAuditable
    {
        public Category()
        {
            Courses = new List<Course>();
        }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Course> Courses { get; set; }
    }
}
