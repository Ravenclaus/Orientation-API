using OrientationApi.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrientationApi.Models;
using System.Data;
using Dapper;

namespace OrientationApi.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _dbConnection;
        
        public ProductRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }


        public IEnumerable<Product> GetAllProducts()
        {
            var sql = @"SELECT ProductId, ProductName, ProductPrice FROM Product";

            return _dbConnection.Query<Product>(sql);
        }

        public Product GetSingleProduct(int productId)
        {
            var sql = @"SELECT ProductName, ProductPrice FROM Product WHERE ProductId = @ProductId";

            return _dbConnection.QuerySingle<Product>(sql, new { ProductId = productId });
        }

        public void AddProduct(Product newProduct)
        {
            
            var sql = @"INSERT INTO Product(ProductName, ProductPrice)
                        VALUES(@ProductName, @ProductPrice)";

            _dbConnection.Execute(sql, newProduct);
        }

        public void UpdateProductInfo(Product updatedProduct)
        {
            var sql = @"UPDATE Product SET 
                            ProductName = @ProductName, 
                            ProductPrice = @ProductPrice 
                        WHERE ProductId = @ProductId";

            _dbConnection.Execute(sql, updatedProduct);
        }

        public void DeleteProduct(int productIdToDelete)
        {
            var sql = @"DELETE FROM Product WHERE ProductId = @ProductId";

            _dbConnection.Execute(sql, new { ProductId = productIdToDelete });
        }
    }
}