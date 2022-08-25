using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CafeteriaOrders.data
{
    public class Cart
    {
        [Key]
        public int id { get; set; }

        public ICollection<CartItem> cartItems { get; set; }

        public decimal totalPrice { get; set; }

    }
}
