using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class StudentController : Controller
    {
       private readonly ICourseService _courseservice;

        public StudentController(ICourseService courseService)
        {
            _courseservice = courseService;
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
    
    }
}