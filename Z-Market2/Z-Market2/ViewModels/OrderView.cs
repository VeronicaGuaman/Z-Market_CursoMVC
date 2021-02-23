using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Z_Market2.Models;

namespace Z_Market2.ViewModels
{
    public class OrderView
    {
        public Customer Customer { get; set; }
        public ProductOrder Product { get; set; }
        public List<ProductOrder> Products { get; set; }
    }
}