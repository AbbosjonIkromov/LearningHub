using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities.Enums;

namespace LearningHub.Entities
{
    public class Course : IAuditable
    {
        public Course()
        {
            Enrollments = new List<Enrollment>();
            CourseInstructors = new List<CourseInstructor>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DifficultyLevel DifficultyLevel { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseInstructor> CourseInstructors { get; set; }
    }
}
