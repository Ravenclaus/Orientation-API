using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationApi.Models
{
    public class LineItem
    {
        public int LineItemId { get; set; }
        public int ProductId { get; set; }
        public int CartOrderId { get; set; }
    }
}