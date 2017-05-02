using OrientationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrientationApi.Controllers.Interfaces
{
    public interface ILineItemRepository
    {
        IEnumerable<LineItem> GetAllLineItems();

        LineItem RetrieveLineItem(int itemId);

        void AddLineItem(LineItem newLineItem);

        void RemoveLineItem(int itemId);

        void EditLineItem(LineItem updatedLineItem);
    }
}
