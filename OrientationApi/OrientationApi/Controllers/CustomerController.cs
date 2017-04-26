using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;

namespace OrientationApi.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {

        private readonly ICustomerRepository _customerRepository;


        public CustomerController(ICustomerRepository customerRepository)
        {

            _customerRepository = customerRepository;
        }

        [HttpPut]
        public HttpResponseMessage PutUpdateCustomer(Customer customer)
        {

            if (string.IsNullOrWhiteSpace(customer.UserName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Username");
            _customerRepository.Update(customer);
            return Request.CreateResponse(HttpStatusCode.OK);

        }





        [HttpPost]
        [Route("api/customer")]
        public HttpResponseMessage RegisterCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.UserName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You entered an incorrect Username");
            }

            _customerRepository.Save(customer);


            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //[api/customer/{customerId}]
        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User doesnt exist");
            _customerRepository.Delete(customer);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //[HttpGet]
        //[Route("api/customer/{id}")]
        //public HttpResponseMessage GetOne()
        //{
        //    var customers = _customerRepository.GetOne();

        //    return Request.CreateResponse(HttpStatusCode.OK, customers);
        //}

        [HttpGet]
        [Route("api/customer")]
        public HttpResponseMessage GetAll()
        {
            var customers = _customerRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

    }
}