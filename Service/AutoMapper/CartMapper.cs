using AutoMapper;
using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels.Carts;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.Service.AutoMapper
{
    public class CartMapper : Profile
    {
        public CartMapper()
        {
            CreateMap<Cart, AddCartDtos>()
                .ReverseMap();
            CreateMap<Cart, GetCartDtos>()
               .ReverseMap();
           /* CreateMap<Cart, CartItemDtos>()
               .ReverseMap();*/
        }
    }
}
