using System.Collections.Generic;
using OrientationApi.Models;

namespace OrientationApi.Controllers.Interfaces
{
    public interface ICustomerRepository
    {
        int Update(Customer updatedCustomer);

        void Delete(Customer deleteCustomer);
        void Save(Customer newCustomer);

        IEnumerable<Customer> GetAllCustomers();

        Customer GetSingleCustomer(int customerId);
    }
}