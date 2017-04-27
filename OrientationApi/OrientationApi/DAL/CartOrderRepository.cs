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
    public class CartOrderRepository : ICartOrderRepository
    {
        readonly IDbConnection _dbConnection;
        public CartOrderRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Save(CartOrder newCartOrder)
        {
            var sql = @"Insert into CartOrder(customerid)
                        Values(@customerid)";

            _dbConnection.Execute(sql, newCartOrder);
        }
        
        public IEnumerable<CartOrder> GetAll()
        {
            var sql = @"Select customerid from CartOrder";

            return _dbConnection.Query<CartOrder>(sql);
        }

        public void Update(CartOrder updatedcartorder)
        {
            var sql = @"UPDATE CartOrder SET CustomerId = 89654  WHERE CustomerId = 4444";
            _dbConnection.Execute(sql, updatedcartorder);
        }

        public void Delete(CartOrder deletecartorder)
        {
            var sql = @"DELETE FROM CartOrder WHERE CustomerId = 5555";
            _dbConnection.Execute(sql, deletecartorder);
        }


    }
}