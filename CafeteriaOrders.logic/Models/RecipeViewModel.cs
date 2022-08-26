using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.Models
{
    public class RecipeViewModel
    {
        public int id { get; set; }
        public int mealId { get; set; }
        public string ingredients { get; set; }
        public string type { get; set; }
    }
}
