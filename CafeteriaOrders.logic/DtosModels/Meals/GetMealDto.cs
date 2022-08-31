using CafeteriaOrders.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.Models
{
    public class GetMealDto
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
        //public virtual Recipe? recipe { get; set; } as devied added.. 
        public virtual ICollection<Review>? Reviews { get; set; } // we need to view lst of rews in Meal Details endpoint..

        
    }
}
