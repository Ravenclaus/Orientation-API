using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientationApi.Controllers.Interfaces
{
    public interface ICustomerRepository
    {
        void Update(Customer updatedCustomer);

        void Delete(Customer deleteCustomer);

        void Save(Customer newCustomer);

        IEnumerable<Customer> GetAll();

        //void GetOne(int CustomerId);
    }
}