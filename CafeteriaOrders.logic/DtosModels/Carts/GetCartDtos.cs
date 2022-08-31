using CafeteriaOrders.data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.Models
{
    public class GetCartDtos
    {
        public int id { get; set; }
        public virtual ICollection<CartItem> cartItems { get; set; }
        public decimal totalPrice { get; set; }
    }
}
