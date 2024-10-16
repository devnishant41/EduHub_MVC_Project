using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.DTO
{
    public class FeedbackModel
    {[Key]
        public int FeedbackId { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string Feedback { get; set; }
        public DateTime Date { get; set; }

        public bool IsActive { get; set; } = true;
    }
}
