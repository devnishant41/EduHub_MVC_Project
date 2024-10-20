
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Combined
{

    public class CourseReviewModel
    {   [Key]
        public int FeedbackId { get; set; }      // Corresponds to FeedbackId
        public string Feedback { get; set; }      // Corresponds to Feedback
        public string FirstName { get; set; }     // Corresponds to FirstName
        public string LastName { get; set; }      // Corresponds to LastName
        public DateTime Date { get; set; }        // Corresponds to Date
    }
}



