using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.DtosModels.Carts;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.CartServices
{
    public interface ICartService
    {
        Task<IEnumerable<GetCartDtos>> Get(); // done 
        Task<IEnumerable<CartItemDtos>> GetCartItems(); // not so far
        Task<decimal> GetTotalPrice(); // not 
        Task<GetCartDtos> Details(int id); // of a spesific

        Task<Cart> Add(AddCartDtos model);

        Task<Cart> Delete(int id);

        Task<Cart> Edit(GetCartDtos model);

        decimal checkValidItem(CartItem model);

        // Task<ServiceResponse<GetCartDtos>> checkout(List<CartItem> model);
        Task<ServiceResponse<GetCartDtos>> checkout(AddCartDtos model);


    }
}
