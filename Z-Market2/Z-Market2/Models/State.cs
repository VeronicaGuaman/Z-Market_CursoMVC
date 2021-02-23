using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Z_Market2.Models
{
    public class State
    {
        [Key]
        public int StateID { get; set; }
        public string NameState { get; set; }
        public int CountryID { get; set; }

        public virtual Country Country { get; set; }
    }
}