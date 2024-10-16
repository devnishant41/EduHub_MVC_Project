using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Test_EduHub.Models.Domain
{
    public class AllFeedbackModel
    {
        [Key]
        public int CourseId { get; set; }      // Corresponds to f.FeedbackId
        public string Title { get; set; }         // Corresponds to c.Title
        public string CategoryName { get; set; }  // Corresponds to cat.CategoryName
        public int FeedbackCount { get; set; }    // Corresponds to @FeedbackCount
    }
}
