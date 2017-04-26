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
    public class CustomerRepository : ICustomerRepository
    {
        readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public IEnumerable<Customer> GetAll()
        {
            var sql = @"Select customerid, username, firstname, lastname from Customer";

            var guid = Guid.NewGuid();
            var customer = _dbConnection.Query<Customer>("Select Username = @Username, FirstName = @FirstName, LastName = @LastName, CustomerId = @CustomerId", new { Customer = (int?)null, CustomerId = guid });

            customer.First().FirstName.

            return _dbConnection.Query<Customer>(sql);
        }

        public void Save(Customer newCustomer)
        {
            var sql = @"Insert into Customer(username, firstname, lastname)
                        Values( 'kate', 'blaze', 'kblaze')";

            _dbConnection.Execute(sql, newCustomer);
        }
    }
}