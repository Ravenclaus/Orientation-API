using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OrientationApi.Controllers;
using Moq;
using OrientationApi.Controllers.Interfaces;
using System.Net.Http;
using System.Web.Http;
using OrientationApi.Models;
using System.Collections.Generic;
using System.Net;
using System.Linq;

namespace OrientationApi.Tests
{
    [TestClass]
    public class GetCustomerTests
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
        public void EnsureGetAllIsWorking()
        {
            _mockedCustomerRepo.Setup(x => x.GetAll()).Returns(() => new List<Customer>
            {
                new Customer { UserName = "a" },
                new Customer { UserName = "b" },
                new Customer { UserName = "c" }
            });

            var result = _controller.GetAll();

            Assert.AreEqual(HttpStatusCode.OK, result.StatusCode);
        }

        [TestMethod]
        public void EnsureCountOfGetAllIsWorking()
        {
            _mockedCustomerRepo.Setup(x => x.GetAll()).Returns(() => new List<Customer>
            {
                new Customer { UserName = "a" },
                new Customer { UserName = "b" },
                new Customer { UserName = "c" }
            });

            var result = _controller.GetAll();
            var content = result.Content as ObjectContent<IEnumerable<Customer>>;
            var returnValue = content.Value as IEnumerable<Customer>;
            Assert.AreEqual(3, returnValue.Count());
        }

    }
}
