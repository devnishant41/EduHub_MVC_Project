using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models;
using Test_EduHub.Models.Domain;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;

        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("/student/newenrollment")]
        [HttpGet]
        public IActionResult CreateNewEnrollment()
        {
            Console.WriteLine($"here is course");

            return View();
        }
        // [HttpPost]
        // public IActionResult CreateNewEnrollment(EnrollmentViewModel enrollmentViewModel)
        // {
        //     if (enrollmentViewModel == null || enrollmentViewModel.Courses == null)
        //     {
        //         // Handle the case where the view model or its properties are null
        //         return BadRequest();
        //     }
        //     var enrollment = new Enrollment
        //     {
        //         EnrollmentDate = enrollmentViewModel.EnrollmentDate,
        //         UserId = enrollmentViewModel.UserId,
        //         CourseId = enrollmentViewModel.CourseId
        //     };
        //     _enrollmentService.AddEnrollment(enrollment);
        //     return RedirectToAction("Index");
        // }


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
            return RedirectToAction("GetMyEnrollments","Enrollment");
        }




    }
}