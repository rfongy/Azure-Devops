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

namespace ModernUIApp.Controllers
{
    public class CustomersController : Controller
    {
        private HttpClient _customersApiClient;
        private string _customerApiUrl;
        public CustomersController(IConfiguration configuration)
        {
            _customersApiClient = new HttpClient();
            _customerApiUrl = configuration.GetValue<string>("ApiURL");
        }
        public IActionResult Index()
        {
            var customers = getCustomersFromApi();
            return View(customers);
        }
        private List<Customer> getCustomersFromApi()
        {
            
            HttpResponseMessage response = _customersApiClient.GetAsync(_customerApiUrl).Result;
            response.EnsureSuccessStatusCode();
            string jsonResponse = response.Content.ReadAsStringAsync().Result;
            var customers = JsonConvert.DeserializeObject<List<Customer>>(jsonResponse);
            return customers;
        }
    }
}