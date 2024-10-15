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
    public class MaterialController : Controller
    {

         private readonly IMaterialService _materialService;
        public MaterialController(IMaterialService materialService)
        {
            _materialService = materialService;
        }

        
        public IActionResult Index()
        {
            return View();
        }

    }
}