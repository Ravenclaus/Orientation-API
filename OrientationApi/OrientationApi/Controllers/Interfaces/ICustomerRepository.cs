using System.Collections.Generic;
using OrientationApi.Models;

namespace OrientationApi.Controllers.Interfaces
{
    public interface ICustomerRepository
    {
        void Update(Customer editingCustomer);

        void Delete(int deleteCustomer);
        void Save(Customer newCustomer);

        IEnumerable<Customer> GetAllCustomers();

        Customer GetSingleCustomer(int customerId);
    }
}