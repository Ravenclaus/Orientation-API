using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientationApi.Controllers.Interfaces
{
    interface IProductRepository
    {
        Product GetSingleProduct(int productId);

        List<Product> GetAllProducts();
    }
}
