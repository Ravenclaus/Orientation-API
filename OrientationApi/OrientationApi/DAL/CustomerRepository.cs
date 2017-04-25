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

    
    }
}