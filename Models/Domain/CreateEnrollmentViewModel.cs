using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Domain
{
    public class CreateEnrollmentViewModel
    {
        public int SelectedCourseId { get; set; }
        public IEnumerable<Course> Courses { get; set; }
    }
}