﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Test_EduHub.Models;

namespace Test_EduHub.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()

    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }
  
}
