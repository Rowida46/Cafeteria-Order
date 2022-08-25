using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.Models
{
    public class ReviewViewModel
    {
        public int id { get; set; }
        public int MealId { get; set; }
        public string comment { get; set; }
        public int rate { get; set; }
    }
}
