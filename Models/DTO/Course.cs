using System;
using System.Collections.Generic;

namespace Test_EduHub.Models
{
    public partial class Course
    {
       
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CourseStartDate { get; set; }
        public DateTime CourseEndDate { get; set; }
        public string Level { get; set; } = null!;
        public bool? Status { get; set; } = true;
        public int? Userid { get; set; } 
        public int? Categoryid { get; set; }
        public decimal Price { get; set; }
        public virtual Category? Category { get; set; }
       public override string ToString()
    {
        return $"Course ID: {Id}, Title: {Title}, Description: {Description}, " +
               $"Category ID: {Categoryid}, Start Date: {CourseStartDate}, End Date: {CourseEndDate}, " +
               $"Level: {Level}, Price: {Price} {Userid} {Categoryid}";
        }
    }
}
