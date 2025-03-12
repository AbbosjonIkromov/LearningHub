using LearningHub.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningHub.App.Dtos.Enrollment
{
    public class UpdateEnrollmentDto
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public CompletionStatus? CompletionStatus { get; set; }
        public decimal Score { get; set; }
    }
}
