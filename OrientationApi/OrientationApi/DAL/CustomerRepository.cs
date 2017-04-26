using OrientationApi.Controllers.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;
using System.Linq;
using System.Web;
using OrientationApi.Models;
using System.Data;
using Dapper;

namespace OrientationApi.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Update(Customer updatedCustomer)
        {
            var sql = @"UPDATE Customer SET FirstName = 'Mr', LastName = 'O' WHERE CustomerId = 1";

            
            _dbConnection.Execute(sql, updatedCustomer);
        }

        public void Delete(Customer deleteCustomer)
        {
            var sql = @"DELETE FROM Customer WHERE CustomerId = 2";

            _dbConnection.Execute(sql, deleteCustomer);
        }

        public IEnumerable<Customer> GetAll()
        {
            var sql = @"Select customerid, username, firstname, lastname from Customer";

            return _dbConnection.Query<Customer>(sql);
        }

        public void Save(Customer newCustomer)
        {
            var sql = @"Insert into Customer(customerid, username, firstname, lastname)
                        Values(@customerid, @username, @firstname, @lastname)";

            _dbConnection.Execute(sql, newCustomer);
        }
    }
}