using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models.Combined;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICourseService _courseservice;

        private readonly IMaterialService _materialservice;

        public StudentController(ICourseService courseService, IMaterialService materialService)
        {
            _courseservice = courseService;
            _materialservice = materialService;
        }


        public IActionResult Index()
        {
            return View();
        }

        [Route("student/mycourses")]
        public IActionResult GetStudentEnrolledCourses()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var courses = _courseservice.GetEnrolledCoursesByStudentId(userId);
            return View(courses);
        }


          [Route("student/course/mycourse/{id}")]
        public IActionResult MyCourseDetails(int id)
        {
            var course = _courseservice.GetCourseDetailsById(id);
            if (course == null)
            {
                return NotFound();
            }

            var materials = _materialservice.GetMaterialByCourseId(id);

            var viewModel = new CourseMaterialViewModel
            {
                courseDetailsViewModel = course,
                Materials = materials
            };

            return View(viewModel);


        }
    
    }
}