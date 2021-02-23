using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Z_Market2.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public int SubcategoryID { get; set; }


        [Display(Name = "Product Description")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must betwen {1} and {2} characters", MinimumLength = 3)]
        public string Descripcion { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "You must enter {0}")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Last Buy")]
        public DateTime LastBuy { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public float Stock { get; set; }

        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        [NotMapped]
        public int CategoryID { get; set; }
        [NotMapped]
        public Category Categories { get; set; }
        public virtual Subcategory Subcategories { get; set; }
        //
        public virtual ICollection<Supplier> Suppliers{ get; set; }
        public virtual ICollection<SupplierProduct> SupplierProducts { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}