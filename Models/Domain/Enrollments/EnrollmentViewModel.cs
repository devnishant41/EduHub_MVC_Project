using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Domain.Enrollments
{
    public class EnrollmentViewModel
    {

        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Status { get; set; }

    }
}
