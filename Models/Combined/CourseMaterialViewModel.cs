using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_EduHub.Models.Domain;

namespace Test_EduHub.Models.Combined
{
    public class CourseMaterialViewModel
    {
        public IEnumerable<CourseDetailsViewModel> courseDetailsViewModel { get; set; }
        public IEnumerable<Material> Materials { get; set; }

        public IEnumerable<CourseReviewModel> CourseReviews { get; set; }

        public CourseMaterialViewModel
()
        {
            Materials = new List<Material>();
            CourseReviews = new List<CourseReviewModel>();
        }
    }
}