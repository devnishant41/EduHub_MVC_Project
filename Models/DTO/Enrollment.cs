using System;
using System.Collections.Generic;

namespace Test_EduHub.Models
{
    public partial class Enrollment
    {
        // public Enrollment()
        // {
        //     Requests = new HashSet<Request>();
        // }

        public int Id { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        

        // public virtual Course Course { get; set; } = null!;
        // public virtual User User { get; set; } = null!;
        // public virtual ICollection<Request> Requests { get; set; }
    }
}
