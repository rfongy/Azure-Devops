using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModernUIApp.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using ModernUIApp.Services;

namespace ModernUIApp.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerDataService _customerDataService;
        public CustomersController(ICustomerDataService customerDataService)
        {
            _customerDataService = customerDataService;
        }
        public IActionResult Index()
        {
            var customers = _customerDataService.GetAll();
            return View(customers);
        }
    }
}