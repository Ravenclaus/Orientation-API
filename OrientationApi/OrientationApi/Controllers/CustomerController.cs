using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationApi.Controllers
{
    public class CustomerController : ApiController
    {
        readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        [Route("api/customer")]
        public HttpResponseMessage RegisterCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.Username))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You entered an incorrect Username");
            }

            _customerRepository.Save(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("api/customer")]
        public HttpResponseMessage GetAll()
        {
            var customers = _customerRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

    }
}
