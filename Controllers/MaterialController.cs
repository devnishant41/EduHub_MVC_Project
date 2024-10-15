using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models;
using Test_EduHub.Models.Combined;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class MaterialController : Controller
    {

        private readonly IMaterialService _materialService;
        private readonly ICourseService _courseService;

        public MaterialController(IMaterialService materialService, ICourseService courseService)
        {
            _materialService = materialService;
            _courseService = courseService;
        }


        [Route("educator/course/addmaterial/{id}")]
        [HttpGet]
        public IActionResult AddCourseMaterial(int id)
        {
            Console.WriteLine($"{id}");

            var model = new Material
            {
                Courseid = id
            };
            return View(model);
        }

        [Route("educator/course/addmaterial/{id}")]
        [HttpPost]
        public IActionResult AddCourseMaterial(int id, Material material)
        {
          
            material.Courseid = id;
            material.UploadDate = DateTime.Now;
            Console.WriteLine($"{material}");
            
            if (ModelState.IsValid)
            {
                Console.WriteLine($"IsValid");
                _materialService.AddNewMaterial(id, material);
                TempData["SuccessMessage"] = "Material Added Successfully!";

                return RedirectToAction("CourseDetails", "Course", new { id });
            }
            return View(material);
        }


        // public IActionResult GetCoursesWithMaterial(int id)
        // {
        //     // var course = _courseService.GetCourseById(id);

        //     // if (course == null)
        //     // {
        //     //     return NotFound();
        //     // }

        //     // var materials = _materialService.GetMaterialByCourseId(id);

        //     // var viewModel = new CourseMaterialViewModel
        //     // {
        //     //     Course = course,
        //     //     Materials = materials
        //     // };

        //     return View(viewModel);
        // }

    }
}