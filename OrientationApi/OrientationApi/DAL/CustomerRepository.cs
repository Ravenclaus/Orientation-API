﻿using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;

namespace OrientationApi.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;
        Customer _customer = new Customer();

        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }

        public void Update(Customer updatedCustomer)
        {
            var sql = @"UPDATE Customer SET FirstName = 'Mr', LastName = 'Ostrander' WHERE CustomerId = 5";

            
            _dbConnection.Execute(sql, updatedCustomer);
        }

        public void Delete(Customer deleteCustomer)
        {
            var sql = @"DELETE FROM Customer WHERE CustomerId = 2";

            _dbConnection.Execute(sql, deleteCustomer);
        }
    }
}