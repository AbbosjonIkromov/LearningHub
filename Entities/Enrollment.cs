using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningHub.Entities.Enums;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LearningHub.Entities
{
    public class Enrollment : IAuditable
    {
        public int EnrollmentId { get; set; }
        public int  StudentId { get; set; }
        public Student Student { get; set; }
        public int  CourseId { get; set; }
        public Course Course { get; set; }
        public CompletionStatus CompletionStatus { get; set; }
        public decimal Score { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

    }
}
