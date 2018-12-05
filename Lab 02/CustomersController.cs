using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModernApiApp.Models;

namespace ModernApiApp.Controllers {
    [Route ("api/[controller]")]
    public class CustomersController : Controller {
        // GET api/customers
        [HttpGet]
        public IEnumerable<Customer> Get () {
            var customers = new List<Customer> ();
            for (int i = 0; i < 10; i++) {
                var customer = new Customer { Id = i + 1, Name = $"Customer {i+1}", Address = $"{(i+1) * 100} Main St" };
                customers.Add (customer);
            }
            return customers.ToArray ();
        }
    }
}