using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Market2.Models
{
    public class Subcategory
    {
        [Key]
        public int SubcategoryID { get; set; }

        public int CategoryID { get; set; }


        [Display(Name = "Name SubCategory")]
        [Required(ErrorMessage = "You must enter {0}")]
        [StringLength(30, ErrorMessage = "The field {0} must betwen {1} and {2} characters", MinimumLength = 3)]
        public string Name { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}