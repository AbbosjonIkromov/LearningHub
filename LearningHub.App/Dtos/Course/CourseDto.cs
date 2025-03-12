using LearningHub.Entities.Enums;
using LearningHub.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.App.Dtos.Course
{
    public class CourseDto
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int CategoryId { get; set; }
        public DifficultyLevel? DifficultyLevel { get; set; }
        public decimal Price { get; set; }

    }
}
