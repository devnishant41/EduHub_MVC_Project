using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models;
using Test_EduHub.Models.Combined;
using Test_EduHub.Models.Domain;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseservice;

        private readonly IMaterialService _materialservice;

        public CourseController(ICourseService courseService, IMaterialService materialService)
        {
            _courseservice = courseService;
            _materialservice = materialService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("courses/allcourses")]
        public IActionResult GetAllCourses()
        {
            var courses = _courseservice.GetAllCourses();
            return View(courses);
        }

        [Route("course/coursedetails/{id}")]
        public IActionResult CourseDetails(int id)
        {
            var course = _courseservice.GetCourseDetailsById(id);
            if (course == null)
            {
                return NotFound();
            }

            var materials = _materialservice.GetMaterialByCourseId(id);

            var courseReviews = _courseservice.GetCourseReviews(id);

            var viewModel = new CourseMaterialViewModel
            {
                courseDetailsViewModel = course,
                Materials = materials,
                CourseReviews = courseReviews
            };

            return View(viewModel);


        }

        [HttpGet]
        [Route("course/editcourse/{id}")]
        public async Task<IActionResult> EditCourse(int id)
        {
            var data = _courseservice.GetCourseById(id);
            // Console.WriteLine($"{data.Title}");
            // Console.WriteLine($"{data.Userid}");

            var categories = _courseservice.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");
            return View(data);
        }

        [HttpPost]
        [Route("course/editcourse/{id}")]
        public IActionResult EditCourse(Course editedCourse, int id)
        {
            if (ModelState.IsValid)
            {
                var data = _courseservice.GetCourseById(id);
                editedCourse.Userid = data.Userid;
                editedCourse.Categoryid = data.Categoryid;
                Console.WriteLine($"Edited {editedCourse.Title}");
                Console.WriteLine($" edited {editedCourse.Userid}");
                _courseservice.EditCourse(editedCourse);

            }
            TempData["SuccessMessage"] = "Course Edited Successfully!";
            return RedirectToAction("GetMyCourses", "Educator");
        }

        [HttpGet]
        // [Route("/course/deletecourse/{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var data = _courseservice.GetCourseDetailsById(id);
            Console.WriteLine($"{data.ElementAt(0).Title}");

            return View(data.ElementAt(0));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id, CourseDetailsViewModel courseDetailsViewModel)
        {
            Console.WriteLine($"here");
            TempData["SuccessMessage"] = "Course Deleted Successfully!";
            await _courseservice.DeleteCourseAsync(id);
            return RedirectToAction("GetMyCourses", "Educator");
        }


    }

}