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

        IEnumerable<Product> GetAllProducts();

        void AddProduct(Product newProduct);

        void UpdateProductInfo(Product updatedProduct);

        void DeleteProduct(int productIdToDelete);
    }
}
