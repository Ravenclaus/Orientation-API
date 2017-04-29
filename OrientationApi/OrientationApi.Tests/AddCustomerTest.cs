using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrientationApi.Controllers;
using Moq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;

namespace OrientationApi.Tests
{
    [TestClass]
    public class NewCustomerTests
    {
        CustomerController _controller;
        Mock<ICustomerRepository> _mockedCustomerRepo;

        [TestInitialize]
        public void Initialize()
        {
            _mockedCustomerRepo = new Mock<ICustomerRepository>();

            _controller = new CustomerController(_mockedCustomerRepo.Object);
            _controller.Request = new HttpRequestMessage();
            _controller.Request.SetConfiguration(new HttpConfiguration());
        }

        [TestMethod]
        public void AddANewCustomerSuccessfully()
        {
            var registerNewCustomer = new Customer
            {
                UserName = "GwenKilby",
                FirstName = "Gwen",
                LastName = "Kilby"
            };

            var result = _controller.RegisterCustomer(registerNewCustomer);

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);

            _mockedCustomerRepo.Verify(x => x.Save(registerNewCustomer));
        }

        [TestMethod]
        public void AddANewCustomerFails()
        {
            var registerNewCustomer = new Customer()
            {
                UserName = "",
                FirstName = "",
                LastName = "Feet"
            };

            var result = _controller.RegisterCustomer(registerNewCustomer);

            Assert.AreEqual(HttpStatusCode.BadRequest, result.StatusCode);
        }
    }
}
