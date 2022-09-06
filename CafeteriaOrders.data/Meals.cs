using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CafeteriaOrders.data
{
    public class Meals
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string name { get; set; }

        public string image { get; set; }
        public decimal OverAllRate { get; set; }
        public Categories category { get; set; }
        public decimal price { get; set; }
        public int numberofUnits { get; set; }  
        public virtual Recipe? recipe { get; set; } // that include further details
        public virtual ICollection<Reviews>? Reviews { get; set; }

    }
}
