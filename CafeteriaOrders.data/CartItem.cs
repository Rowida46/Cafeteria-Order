using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CafeteriaOrders.data
{
    public class CartItem
    {
        [Key]
        public int id { get; set; }

        /*
        // to handel fk 
        public int cartId { get; set; }
        [ForeignKey(nameof(cartId))]
        public Cart cart { get; set; }
        */


        // to handel fk that ref to meal of this cart item.... 
        public int mealId { get; set; }
        [ForeignKey(nameof(mealId))]
        public Meals meal { get; set; }


        public int quantity { get; set; }

    }
}
