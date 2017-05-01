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
    [RoutePrefix("api/lineItem")]
    public class LineItemController : ApiController
    {
        readonly ILineItemRepository _lineItemRepository;

        public LineItemController(ILineItemRepository lineItemRepository)
        {
            _lineItemRepository = lineItemRepository;
        }

        [HttpPost]
        public HttpResponseMessage PostLineItem(LineItem newItem)
        {
            if (newItem.CartOrderId <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid CartOrderId");
            }

            if (newItem.ProductId <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid ProductId");
            }


            _lineItemRepository.AddLineItem(newItem);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public HttpResponseMessage GetLineItems()
        {
            var lineItems = _lineItemRepository.GetAllLineItems() as List<LineItem>;

            return Request.CreateResponse(HttpStatusCode.OK, lineItems);
        }

        [HttpGet]
        [Route("{itemId}")]
        public HttpResponseMessage GetLineItem(int itemId)
        {
            if (itemId <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid Id");
            }

            var lineItem = _lineItemRepository.RetrieveLineItem(itemId);

            return Request.CreateResponse(HttpStatusCode.OK, lineItem);
        }

        [HttpDelete]
        [Route("{itemId}")]
        public HttpResponseMessage DeleteLineItem(int itemId)
        {
            if (itemId <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid itemId");
            }

            _lineItemRepository.RemoveLineItem(itemId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("{lineItemId}")]
        public HttpResponseMessage UpdateLineItem([FromBody]LineItem newItem, int lineItemId)
        {
            if (newItem.CartOrderId <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid itemId");
            }

            newItem.LineItemId = lineItemId;

            _lineItemRepository.EditLineItem(newItem);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


    }
}
