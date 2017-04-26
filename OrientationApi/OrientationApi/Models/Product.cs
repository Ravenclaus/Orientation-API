using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        //Price is an int just because of the way the database was set up
        //We can change this to a double later...
        //...we will make sure the methods work, first.
    }
}