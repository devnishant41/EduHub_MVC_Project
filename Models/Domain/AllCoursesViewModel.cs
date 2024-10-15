using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test_EduHub.Models.Domain
{
    public class AllCoursesViewModel
    {

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public string Level { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }

}