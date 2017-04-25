using OrientationApi.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationApi.Controllers
{
    [RoutePrefix("api/customer")]

    public class CustomerController : ApiController
    {

        readonly ICustomerRepository _customerRepository;

       
    }
}
