using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using ModernUIApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using ModernUIApp.Models;

namespace ModernUIApp.Tests {
    [TestClass]
    public class CustomersControllerTests {
        private readonly HttpClient _client;
        private IConfigurationRoot _configuration;
        public CustomersControllerTests () {
            // Arrange
            _client = new HttpClient ();
            _configuration = new ConfigurationBuilder ()
                .SetBasePath (Directory.GetCurrentDirectory ())
                .AddJsonFile ("appsettings.json")
                .Build ();

        }

        [TestCategory ("L1")]
        [TestMethod]
        public void Index__ShouldReturnAViewContainingAListOfCustomersSortedAlphabetically () {
            //Arrange
            var customersControllerUnderTest = new CustomersController (_configuration);
            //Act
            var returnedResult = customersControllerUnderTest.Index ();
            // Assert
            Assert.AreEqual (returnedResult.GetType (), typeof (ViewResult));
            var returnedView = returnedResult as ViewResult;
            Assert.AreEqual (returnedView.Model.GetType (), typeof (List<Customer>), "Customers controller index modern is null. The customer API didn't return any customer");
        }
    }
}