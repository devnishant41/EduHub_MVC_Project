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
    public class ProfileController : Controller
    {

        private readonly IUserService _userService;

        public ProfileController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("user/profile")]
        public IActionResult UserProfile()
        {
            int userId = Convert.ToInt32(HttpContext.Session.GetString("UserId"));
            var data = _userService.GetUserProfile(userId);
            return View(data);
        }


    }
}