﻿using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrientationApi.Controllers
{
    public class ProductController : ApiController
    {
        readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //Get Single
        [HttpGet]
        [Route("api/product/{productId}")]
        public HttpResponseMessage RoutingCallForGettingSingleProduct(int productId)
        {
            var singleProduct = _productRepository.GetSingleProduct(productId);

            return Request.CreateResponse(HttpStatusCode.OK, singleProduct);
        }


        //Get All
        [HttpGet]
        [Route("api/product")]
        public HttpResponseMessage RoutingCallForGettingAllProducts()
        {
            var allProducts = _productRepository.GetAllProducts();

            return Request.CreateResponse(HttpStatusCode.OK, allProducts);
        }


        [HttpPost]
        [Route("api/product/")]
        public HttpResponseMessage RoutingForAddingProduct(Product newProduct)
        {
            if(string.IsNullOrWhiteSpace(newProduct.ProductName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid. Product Name cannot be blank.");
            }
            else if(newProduct.ProductPrice == 0 || newProduct.ProductPrice < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid. Product Price cannot be 0 or negative.");
            }

            _productRepository.AddProduct(newProduct);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpPut]
        [Route("api/product/{productIdToUpdate}")]
        public HttpResponseMessage RoutingForEditingProduct([FromBody]Product updatedProduct, int productIdToUpdate)
        {
            if (string.IsNullOrWhiteSpace(updatedProduct.ProductName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid. Product Name cannot be blank.");
            }
            else if (updatedProduct.ProductPrice <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid. Product Price cannot be 0 or negative.");
            }

            updatedProduct.ProductId = productIdToUpdate;

            _productRepository.UpdateProductInfo(updatedProduct);

            return Request.CreateResponse(HttpStatusCode.OK);
        }


        [HttpDelete]
        [Route("api/product/{deleteTargetProductId}")]
        public HttpResponseMessage RoutingForDeletingProduct(int deleteTargetProductId)
        {
            if (deleteTargetProductId <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid. Choose an existing product to delete.");
            }

            _productRepository.DeleteProduct(deleteTargetProductId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
