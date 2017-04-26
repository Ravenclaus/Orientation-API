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

        //[api/customer/{customerId}]
        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(Customer customer)
        {
            if (string.IsNullOrWhiteSpace(customer.FirstName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "User doesnt exist");
            _customerRepository.Delete(customer);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}