using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Test_EduHub.Controllers
{
    public class DashboardController : Controller
    {
        // [Authorize]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }

       
    }
}