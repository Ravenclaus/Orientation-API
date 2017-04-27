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


        public int Update(Customer updatedCustomer)
        {
            var sql = @"UPDATE Crookshanks.dbo.Customer SET FirstName = @firstName, LastName = @lastName WHERE CustomerId = @customerid";

            var count = _dbConnection.Execute(sql, updatedCustomer);
            return count;
        }

        public void Delete(Customer deleteCustomer)
        {
            var sql = @"DELETE FROM Customer WHERE CustomerId = @customerId";

            _dbConnection.Execute(sql, deleteCustomer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            var sql = @"SELECT customerid, username, firstname, lastname FROM Crookshanks.dbo.Customer";

            return _dbConnection.Query<Customer>(sql).ToList();
        }

        public Customer GetSingleCustomer(int customerId)
        {
            var sql = @"SELECT customerid, username, firstname, lastname FROM Crookshanks.dbo.Customer WHERE customerid = {customerid};";

            var result = _dbConnection.Query<Customer>(sql).ToList();
            return result.FirstOrDefault();

            //return _dbConnection.QuerySingle<Customer>(sql,new {CustomerId = customerId});
        }

        public void Save(Customer newCustomer)
        {
            var sql = @"INSERT INTO Crookshanks.dbo.Customer(username, firstname, lastname)
                        VALUES( @username, @firstname, @lastname)";

            _dbConnection.Execute(sql, newCustomer);
        }
    }
}