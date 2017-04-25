using OrientationApi.Models;

namespace OrientationApi.Controllers.Interfaces
{
    public interface ICustomerRepository
    {
        void Update(Customer updatedCustomer);
    }
}