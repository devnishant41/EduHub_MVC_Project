using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;
using Test_EduHub.Models.Domain.Enrollments;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly ICourseService _courseService;

        public EnrollmentController(IEnrollmentService enrollmentService, ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _courseService = courseService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/student/newenrollment")]
        [HttpGet]
        public IActionResult CreateNewEnrollment()
        {
            try
            {
                var courses = _courseService.GetAllCoursesList();
                var viewModel = new CreateEnrollmentViewModel
                {
                    Courses = courses
                };

                foreach (var item in courses)
                {
                    Console.WriteLine($"{item.Title}");

                }
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
                Console.WriteLine($"{ex.StackTrace}");
                throw new Exception();

            }
        }


        [Route("student/enrollment/past")]

        [HttpGet]
        public IActionResult GetPreviousEnrollments()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var enrollments = _enrollmentService.GetPreviousEnrollment(userId);
            return View(enrollments);

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/student/newenrollment")]
        public IActionResult CreateNewEnrollment(CreateEnrollmentViewModel viewModel)

        {
            var enrollment = new Enrollment
            {
                EnrollmentDate = DateTime.UtcNow,
                CourseId = viewModel.SelectedCourseId,
                Status = "Pending",
                UserId = Convert.ToInt32(HttpContext.Session.GetString("UserId"))
            };
            _enrollmentService.CreateEnrollment(enrollment);
            TempData["SuccessMessage"] = "Enrollment Requested Successfully!";

            return RedirectToAction("Dashboard", "Dashboard");
        }





        [HttpGet]
        [Route("educator/enrollments")]
        public IActionResult GetMyEnrollments()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var data = _enrollmentService.GetAllEnrollmentsByUserId(userId).ToList();
            return View(data);
        }

        [HttpGet]
        [Route("educator/enrollments/update/{id}")]
        public IActionResult UpdateEnrollmentStatus(int id)
        {
            var data = _enrollmentService.GetEnrollmentById(id);
            return View(data);
        }

        [HttpPost]
        [Route("educator/enrollments/update/{id}")]
        public IActionResult UpdateEnrollmentStatus(int id, string status)
        {
            _enrollmentService.UpdateEnrollment(id, status);
            TempData["SuccessMessage"] = "Enrollment Status Updated!";
            return RedirectToAction("GetMyEnrollments", "Enrollment");
        }




    }
}