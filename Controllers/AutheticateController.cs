using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Test_EduHub.Models.Domain;
using Test_EduHub.Repositories.Abstract;

namespace Test_EduHub.Controllers
{
    public class AutheticateController : Controller
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _env;

        public AutheticateController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _env = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        // [AllowAnonymous]
        [Route("user/login")]
        public IActionResult LoginForm()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("user/login")]
        public IActionResult LoginForm(LoginModel model)
        {
            // if (HttpContext.Session.GetString("LoggedUserName") != null)
            // {
            //     RedirectToAction("Index", "Dashboard");
            // }

            Console.WriteLine($"login model is called");
            if (ModelState.IsValid)
            {
                var user = _userService.GetUserByUsernameAndPassword(model.Username, model.Password);
                if (user == null)
                {
                    TempData["SuccessMessage"] = "Invalid Credentials!";
                }
                else if (user != null)
                {
                    Console.WriteLine($"login success");
                    string loggedUserName = _userService.GetLoggedInUserName(user.Id);
                    string FullName = _userService.GetFullName(user.Id);
                    string profileImagePath = _userService.GetProfileImage(user.Id);
                    Console.WriteLine($"username is {loggedUserName}");

                    HttpContext.Session.SetString("Username", user.Username);
                    HttpContext.Session.SetString("LoggedUserName", loggedUserName);
                    HttpContext.Session.SetString("UserId", user.Id.ToString());
                    HttpContext.Session.SetString("Role", user.Role);
                    HttpContext.Session.SetString("ProfileImage", profileImagePath);
                    HttpContext.Session.SetString("FullName", FullName);
                    TempData["SuccessMessage"] = "Login successful!";
                    if (user.Role == "Student")
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else if (user.Role == "Educator")
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else if (user.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username or password");
                }
            }
            return View(model);
        }
        [Route("user/signup")]
        public IActionResult SignupForm()
        {

            return View();
        }
        [Route("user/signup")]
        [HttpPost]
        public async Task<IActionResult> SignupForm(SignupViewModel model)
        {
            Console.WriteLine($"{model.Password}");
            Console.WriteLine($"{model.Username}");
            Console.WriteLine($"{model.Lastname}");
            Console.WriteLine($"{model.Email}");
            Console.WriteLine($"{model.Role}");
            Console.WriteLine($"{model.ProfileImage}");

            if (ModelState.IsValid)
            {
                Console.WriteLine($"is ValidationMessageTagHelper");

                string? profileImageFileName = null;

                if (model.ProfileImage != null)
                {
                    string uploadsFolder = Path.Combine(_env.WebRootPath, "images/profileImages");
                    profileImageFileName = Path.GetFileNameWithoutExtension(model.ProfileImage.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(model.ProfileImage.FileName);
                    string filePath = Path.Combine(uploadsFolder, profileImageFileName);
                    model.ProfileImage.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Console.WriteLine($"{model.Username} {profileImageFileName}");

                await _userService.RegisterUser(model, profileImageFileName);
                TempData["SuccessMessage"] = "Registration successful!";

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            TempData["SuccessMessage"] = "Logout successful!";
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}