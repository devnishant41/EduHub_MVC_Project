using System;
using System.Collections.Generic;

namespace Test_EduHub.Models
{
    public partial class Request
    {
        public int Id { get; set; }
        public string RequestStatus { get; set; } = null!;
        public int Enrollmentid { get; set; }

        public virtual Enrollment Enrollment { get; set; } = null!;
    }
}
