using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Domain
{
    public class SubmitFeedbackModel
    {

        public int CourseId { get; set; }
        [Required]
        public string Feedback { get; set; }
    }
}