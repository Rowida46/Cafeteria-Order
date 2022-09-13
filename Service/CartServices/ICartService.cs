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
        Task<ServiceResponse<List<Cart>>> Get(); // done 
        Task<ServiceResponse<List<Cart>>> GetCartItems(); // not so far
        Task<decimal> GetTotalPrice(); // not 
        Task<ServiceResponse<List<Cart>>> Details(int id); // of a spesific
        Task<ServiceResponse<Cart>> Add(Cart model);
        Task<bool> Delete(int id);

        Task<ServiceResponse<Cart>> Edit(Cart model);

        decimal checkValidItem(CartItem model);

        // Task<ServiceResponse<GetCartDtos>> checkout(List<CartItem> model);
        Task<ServiceResponse<GetCartDtos>> checkout(AddCartDtos model);


    }
}
