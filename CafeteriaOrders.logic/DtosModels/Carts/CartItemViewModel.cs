using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.Models
{
    public class CartItemViewModel
    {
        public int id { get; set; }
        public int cartId { get; set; }
        public int mealId { get; set; }  
        public int quantity { get; set; }

    }
}
