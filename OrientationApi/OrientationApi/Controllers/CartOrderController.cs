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
    [RoutePrefix("api/cartorder")]
    public class CartOrderController : ApiController
    {
        readonly ICartOrderRepository _cartorderRepository;

        public CartOrderController(ICartOrderRepository cartOrderRepository)
        {
            _cartorderRepository = cartOrderRepository;
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            var cartorders = _cartorderRepository.GetAll();

            return Request.CreateResponse(HttpStatusCode.OK, cartorders);
        }

        [HttpPost]
        public HttpResponseMessage AddCartOrder(CartOrder cartorder)
        {
            var customerid = cartorder.CustomerId;
            if (customerid == 0) 
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Action");
            }

            _cartorderRepository.Save(cartorder);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
        [HttpPut]
        public HttpResponseMessage PutUpdateCartOrder(CartOrder cartorder)
        {
            var customerid = cartorder.CustomerId;
            if (customerid == 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Action");
            _cartorderRepository.Update(cartorder);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCartOrder(CartOrder cartorder)
        {

            var customerid = cartorder.CustomerId;
            if (customerid == 0)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Delete Cart Not Available");
            _cartorderRepository.Delete(cartorder);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

      }
}
