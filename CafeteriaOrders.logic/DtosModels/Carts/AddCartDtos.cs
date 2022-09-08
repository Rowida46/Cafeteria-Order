using CafeteriaOrders.data;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.DtosModels.Carts
{
    public class AddCartDtos
    {
        public virtual ICollection<CartItem> cartItems { get; set; }
       // public decimal totalPrice { get; set; }
    }
}
