using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Market2.ViewModels
{
    public class SupplierProductVM
    {
        [Key]
        //public int Supplier { get; set; }
        public int ProductID { get; set; }
        public string Descripcion { get; set; }

    }
}