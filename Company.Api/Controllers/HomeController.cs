﻿using Microsoft.AspNetCore.Mvc;

namespace Company.Api.Controllers
{
    public class HomeController: Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
