using System;
using System.Collections.Generic;

namespace Test_EduHub.Models
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<Course> Courses { get; set; }
    }
}
