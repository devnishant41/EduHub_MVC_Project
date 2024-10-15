using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Test_EduHub.Models.Domain
{
    public class EnrollmentViewModel
    {
        public DateTime EnrollmentDate { get; set; }
        public int CourseId { get; set; }
        public SelectList Courses { get; set; }
        public int UserId { get; set; } 
    }
}