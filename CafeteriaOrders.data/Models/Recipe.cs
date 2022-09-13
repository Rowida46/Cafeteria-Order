using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CafeteriaOrders.data
{
    public class Recipe
    {
        [Key]
        public int id { get; set; }
        // to handle fk
        public int mealId { get; set; }
        [ForeignKey(nameof(mealId))]
        public Meals meal { get; set; } 
        // generall info about meals -> (types AKA Syamy, diet, loww cal)
        public string ingredients { get; set; }
        public string type { get; set; }
       // public Categories category{ get; set; }    
    }
}
