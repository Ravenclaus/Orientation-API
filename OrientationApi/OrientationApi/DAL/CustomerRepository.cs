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
        IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public IEnumerable<Customer> GetAll()
        {
            var sql = @"Select customerid, username, firstname, lastname from Customer";

            _dbConnection.Execute(sql, newCustomer);
        }

        public void Save(Customer newCustomer)
        {
            var sql = @"Insert into Customer(customerid, username, firstname, lastname)
                        Values(@customerid, @username, @firstname, @lastname)";
            _dbConnection.Execute(sql, newCustomer);
        }
    }
}