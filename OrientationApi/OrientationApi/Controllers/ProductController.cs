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
    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {
        
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPut]
        //UpdateProduct
        public HttpResponseMessage RoutingForUpdateProduct(Product updatedProduct)
        {
            if (string.IsNullOrWhiteSpace(updatedProduct.ProductName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid product name");
            }
            else if (updatedProduct.ProductPrice <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid. Product Price cannot be 0 or negative.");
            }

            _productRepository.UpdateProductInfo(updatedProduct);
            
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        //GetAllProducts
        public HttpResponseMessage RoutingCallForGetAllProducts()
        {
            var allProducts = _productRepository.GetAllProducts();

            return Request.CreateResponse(HttpStatusCode.OK, allProducts);
        }

        [HttpGet]
        //GetSingleProduct
        public HttpResponseMessage RoutingCallForGetSingleProduct(int productId)
        {
            var singleProduct = _productRepository.GetSingleProduct(productId);

            return Request.CreateResponse(HttpStatusCode.OK, singleProduct);
        }

        [HttpPost]
        //AddProduct
        public HttpResponseMessage RoutingForAddProduct(Product newProduct) //newProduct bc we are adding
        {
            if (string.IsNullOrWhiteSpace(newProduct.ProductName))
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid product name");
            }
            else if (newProduct.ProductPrice == 0 || newProduct.ProductPrice < 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Invalid product price");
            }

            //_productRepository.Save(newProduct);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        //DeleteProduct
        public HttpResponseMessage RoutingForDeleteProduct (int productIdToDelete)
        {
            if (productIdToDelete <= 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product doesnt exist");
            }

            _productRepository.DeleteProduct(productIdToDelete);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
