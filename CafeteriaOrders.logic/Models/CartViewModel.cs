﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.Models
{
    public class CartViewModel
    {
        public int id { get; set; }
        public ICollection<CartItemViewModel> cartItems { get; set; }
        public decimal totalPrice { get; set; }
    }
}