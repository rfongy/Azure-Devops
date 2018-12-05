using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernApiApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using ModernApiApp.Models;

namespace ModernApiApp.Tests {
    [TestClass]
    public class CustomersControllerTests {

        [TestMethod]
        public void TestGetCustomerById_ShouldReturnAValidCustomerWhenGivenAValidId () {
            //Arrange
            var customersControllerUnderTest = new CustomersController ();
            const int idUnderTest = 1;
            //Act
            var returnedResult = customersControllerUnderTest.GetById (idUnderTest);
            //Assert
            Assert.IsNotNull (returnedResult, $"The GetbyId method didn't return any customer for ID= {idUnderTest}");
            Assert.AreEqual (returnedResult.GetType (), typeof (ObjectResult),
                $"The GetbyId returned type: {returnedResult.GetType()} instead of {typeof(ObjectResult)}");
            Assert.IsInstanceOfType ((returnedResult as ObjectResult).Value, typeof (Customer),
                $"The object result returned GetbyId contains type: {(returnedResult as ObjectResult).Value.GetType()} instead of {typeof(Customer)}");
            Customer returnedCustomer = (Customer) (returnedResult as ObjectResult).Value;
            Assert.AreEqual (idUnderTest, returnedCustomer.Id,
                $"The customer result returned GetbyId has Id: {returnedCustomer.Id} instead of {idUnderTest}");
        }

    }
}