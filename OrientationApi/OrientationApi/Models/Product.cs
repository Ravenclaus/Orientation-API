﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrientationApi.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
    }
}