using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Domain
{
    public class DetailedFeedbackModel
    {
        [Key]
        public int FeedbackId { get; set; }      // Corresponds to f.Feedbackid
        public int UserId { get; set; }          // Corresponds to f.UserId
        public int CourseId { get; set; }        // Corresponds to f.CourseId
        public string Feedback { get; set; }      // Corresponds to f.Feedback
        public DateTime Date { get; set; }        // Corresponds to f.Date
        public string FirstName { get; set; }     // Corresponds to p.firstname
        public string LastName { get; set; }      // Corresponds to p.lastname
        public string Title { get; set; }   // Corresponds to c.Title
    }
}
