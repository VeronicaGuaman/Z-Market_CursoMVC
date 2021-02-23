using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Market2.Models
{
    public class Country
    {
        [Key]
        public int CountryID { get; set; }
        public string NameCountry { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}