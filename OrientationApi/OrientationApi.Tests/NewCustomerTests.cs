using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrientationApi.Controllers;
using OrientationApi.Models;
using System.Net;
using OrientationApi.Controllers.Interfaces;
using Moq;
using System.Net.Http;

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
        }

        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
