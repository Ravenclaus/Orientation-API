using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using OrientationApi.Controllers.Interfaces;
using OrientationApi.Models;

namespace OrientationApi.DAL
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection _dbConnection;

        public CustomerRepository(IDbConnection connection)
        {
            _dbConnection = connection;
        }


        public void Update(Customer customer)
        {
            var sql = @"UPDATE Crookshanks.dbo.Customer SET FirstName = @firstName, LastName = @lastName WHERE CustomerId = @customerid";

            _dbConnection.Execute(sql, customer);
            //return count;
        }

        public void Delete(int customerId)
        {
            var sql = @"DELETE FROM Customer WHERE CustomerId = @customerId";

            _dbConnection.Execute(sql, new { customerId = customerId});

        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql = @"SELECT customerid, username, firstname, lastname FROM Crookshanks.dbo.Customer";

            return _dbConnection.Query<Customer>(sql).ToList();
        }

        public Customer GetSingleCustomer(int customerId)
        {
            var sql = $@"SELECT customerid, username, firstname, lastname FROM Crookshanks.dbo.Customer WHERE customerid = @customerId;";

          
            return _dbConnection.QuerySingle<Customer>(sql, new { customerId = customerId });
        }

        public void Save(Customer newCustomer)
        {
            var sql = $@"INSERT INTO Crookshanks.dbo.Customer(UserName, FirstName, LastName)
                        VALUES( @UserName, @FirstName, @LastName)";

            _dbConnection.Execute(sql,newCustomer);
        }
    }
}