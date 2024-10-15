using System;
using System.Collections.Generic;

namespace Test_EduHub.Models
{
    public partial class Profile
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MobileNumber { get; set; }
        public string? ProfileImage { get; set; }
        public bool? AccountStatus { get; set; }
        public bool? ProfileCompleted { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
