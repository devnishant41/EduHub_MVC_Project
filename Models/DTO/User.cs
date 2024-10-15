using System;
using System.Collections.Generic;

namespace Test_EduHub.Models
{
    public partial class User
    {
        // public User()
        // {
        //     Courses = new HashSet<Course>();
        //     Enrollments = new HashSet<Enrollment>();
        //     Profiles = new HashSet<Profile>();
        // }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string? Password { get; set; }
        public string Role { get; set; } = null!;

        // public virtual ICollection<Course> Courses { get; set; }
        // public virtual ICollection<Enrollment> Enrollments { get; set; }
        // public virtual ICollection<Profile> Profiles { get; set; }
    }
}
