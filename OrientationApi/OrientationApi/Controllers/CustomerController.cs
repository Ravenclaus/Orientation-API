using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
        [Route("{customerId}")]
        public HttpResponseMessage PutUpdateCustomer([FromBody]Customer editingCustomer,int customerId)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No customers to update");

            editingCustomer.CustomerId = customerId;

            _customerRepository.Update(editingCustomer);
            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPost]
        public HttpResponseMessage RegisterCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You entered an incorrect Username");

            _customerRepository.Save(customer);


            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{customerId}")]
        public HttpResponseMessage DeleteCustomer( int customerId)
        {
            
            if (customerId <=0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "No customers to delete");

            _customerRepository.Delete(customerId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage GrabAllCustomers()
        {
            var customers = _customerRepository.GetAllCustomers() as List<Customer>;

            if (customers == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "No Customers exist");

            return Request.CreateResponse(HttpStatusCode.OK, customers);
        }

        [HttpGet]
        [Route("{customerId}")]
        public HttpResponseMessage GrabSingleCustomer(int customerId)
        {
            var customer = _customerRepository.GetSingleCustomer(customerId);
            if (customer == null)
                return Request.CreateErrorResponse(HttpStatusCode.NoContent, "User doesnt exist");

            return Request.CreateResponse(HttpStatusCode.OK, customer);
        }
    }
}