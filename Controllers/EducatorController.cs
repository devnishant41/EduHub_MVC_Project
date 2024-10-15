using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class EducatorController : Controller
    {

        private readonly ICourseService _courseservice;
        public EducatorController(ICourseService courseService)
        {
            _courseservice = courseService;
        }

        [Route("educator/mycourses")]
        public IActionResult GetMyCourses()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var data = _courseservice.GetAllEducatorCoursesById(Convert.ToInt32(userId));
            return View(data);
        }
        [Route("educator/enrollments")]
        public IActionResult GetAllEnrollments()
        {
            return View();
        }

        [Route("educator/enquiries")]
        public IActionResult GetAllEnquiries()
        {
            return View();
        }
        [Route("educator/feedbacks")]
        public IActionResult GetAllFeedbacks()
        {
            return View();
        }


        //courses routes
        [Route("educator/mycourses/details/{id?}")]
        public IActionResult GetCourseDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course = _courseservice.GetCourseById(id.Value);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [Route("educator/addcourse")]
        public IActionResult AddCourse()
        {
            ViewBag.Categories =_courseservice.GetAllCategories().ToList();
            return View();
        }

        [Route("educator/addcourse")]
        [HttpPost]
        public IActionResult AddCourse(Course course)
        {
           if (ModelState.IsValid)
            {   course.Userid = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
                _courseservice.AddCourse(course);
                return RedirectToAction(nameof(GetMyCourses));
            }
            return View(course);
        }



    }
}


/*

public IActionResult EditCourse(int id)
{
    var course = _courseService.GetCourseById(id);
    if (course == null)
    {
        return NotFound();
    }
    return View(course);
}

[HttpPost]
public IActionResult EditCourse(Course course)
{
    if (ModelState.IsValid)
    {
        _courseService.UpdateCourse(course);
        return RedirectToAction("GetCourseDetails", new { id = course.Id });
    }
    return View(course);
}

public IActionResult DeleteCourse(int id)
{
    var course = _courseService.GetCourseById(id);
    if (course == null)
    {
        return NotFound();
    }
    return View(course);
}

[HttpPost]
public IActionResult DeleteCourse(Course course)
{
    _courseService.DeleteCourse(course.Id);
    return RedirectToAction("MyCourses");
}

*/