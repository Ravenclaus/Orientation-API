using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Dapper;

namespace OrientationApi.Controllers
{
    [RoutePrefix("api/products")]
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPut]
        //UpdateProduct
        public HttpResponseMessage UpdateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid product name");
            _productRepository.UpdateProductInfo(product);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        //GetAllProducts
        public HttpResponseMessage GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        //GetSingleProduct
        public HttpResponseMessage GetSingleProduct(int productId)
        {
            var product = _productRepository.GetSingleProduct(productId);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        //AddProduct
        public HttpResponseMessage AddProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid product name");
            }

            _productRepository.Save(product);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        //DeleteProduct
        public HttpResponseMessage DeleteProduct (int productIdToDelete)
        {
            if (string.IsNullOrWhiteSpace(product.ProductName))
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product doesnt exist");
            _productRepository.DeleteProduct(productIdToDelete);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
