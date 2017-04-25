using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationApi.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}