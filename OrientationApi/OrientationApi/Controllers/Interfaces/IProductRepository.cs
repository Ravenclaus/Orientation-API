using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientationApi.Controllers.Interfaces
{
    public interface IProductRepository
    {
        Product GetSingleProduct(int productId);

        List<Product> GetAllProducts();

        void Update(Product updatedProduct);

        void Delete(Product deleteProduct);
        void GetAll();
    }
}
