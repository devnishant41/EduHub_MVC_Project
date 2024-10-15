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
    public class MaterialController : Controller
    {

        private readonly IMaterialService _materialService;
        private readonly ICourseService _courseService;

        public MaterialController(IMaterialService materialService,ICourseService courseService)
        {
            _materialService = materialService;
            _courseService = courseService;
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