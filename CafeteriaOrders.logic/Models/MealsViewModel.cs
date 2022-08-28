using CafeteriaOrders.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.Models
{
    public class MealsViewModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public decimal OverAllRate { get; set; }
        public Categories category { get; set; }
        public decimal price { get; set; }
        public int numberofUnits { get; set; }

        /* Working on the model inside -> 
         *Views Only for visualization...
         **/
        public Recipe? recipe { get; set; } 
        public ICollection<Review>? Reviews { get; set; }

        
    }
}
