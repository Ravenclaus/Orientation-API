using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientationApi.Controllers.Interfaces
{
    public interface ICartOrderRepository
    {
        void Save(CartOrder newCartOrder);
        IEnumerable<CartOrder> GetAll();
        void Update(CartOrder cartorder);
        void Delete(CartOrder cartorder);
    }
}
