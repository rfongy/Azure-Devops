﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ModernUIApp.Models;

namespace ModernUIApp.Controllers {
    public class HomeController : Controller {
        private string _customerApiUrl;
        public HomeController(IConfiguration configuration)
        {
            _customerApiUrl = configuration.GetValue<string> ("ApiURL");
        }
        public IActionResult Index () {
            return View ();
        }

        public IActionResult About () {
            ViewData["Message"] = $"Your application description page";
            ViewData["ApiURL"] = $"The API can be reached at {_customerApiUrl}";
            return View ();
        }

        public IActionResult Contact () {
            ViewData["Message"] = "This is the contact page.";

            return View ();
        }

        public IActionResult Privacy () {
            return View ();
        }

        [ResponseCache (Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error () {
            return View (new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}