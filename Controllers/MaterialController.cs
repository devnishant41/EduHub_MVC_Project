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

        [Route("educator/material/edit/{id}")]
        public async Task<IActionResult> EditMaterial(int id)
        {
            Console.WriteLine($"material");

            var material = _materialService.GetMaterialByMaterialId(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        [Route("educator/material/edit/{id}")]
        [HttpPost]
        public async Task<IActionResult> EditMaterial(int id, Material material)
        {
            var oldmaterial = _materialService.GetMaterialByMaterialId(id);
            material.Courseid = oldmaterial.Courseid;
            material.UploadDate = oldmaterial.UploadDate;
            material.ContentType = oldmaterial.ContentType;

            // if (ModelState.IsValid)
            // {
            await _materialService.UpdateMaterial(material);
            TempData["SuccessMessage"] = "Material updated successfully.";
            return RedirectToAction("CourseDetails", "Course", new { id = material.Courseid });
            // }
            return View(material);
        }

        [HttpGet]
        [Route("educator/material/delete/{id}")]
        public async Task<IActionResult> DeleteMaterial(int id)
        {
            var material = _materialService.GetMaterialByMaterialId(id);
            if (material == null)
            {
                return NotFound();
            }
            return View(material);
        }

        [HttpPost]
        [Route("educator/material/delete/{id}")]
        public async Task<IActionResult> DeleteMaterial(int id, Material material)
        {
            var oldmaterial = _materialService.GetMaterialByMaterialId(id);
            _materialService.DeleteMaterial(id);
            TempData["SuccessMessage"] = "Material deleted successfully.";
            return RedirectToAction("CourseDetails", "Course", new { id = oldmaterial.Courseid });
        }

    }
}