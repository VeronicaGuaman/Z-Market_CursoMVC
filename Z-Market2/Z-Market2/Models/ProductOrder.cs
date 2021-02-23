using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Market2.Models
{
    public class ProductOrder:Product
    {
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter {0}")]
        public float Quantity { get; set; }


        [DataType(DataType.Currency)]
        public decimal Value { get { return Price * (decimal)Quantity; } }
    }
}