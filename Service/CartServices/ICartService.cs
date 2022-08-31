using CafeteriaOrders.data;
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
        Task<IEnumerable<GetCartDtos>> Get();
        Task<IEnumerable<CartItemViewModel>> GetCartItems();
        Task<decimal> GetTotalPrice();
        Task<GetCartDtos> Details(int id); // of a spesific ..

        Task<Cart> Add(AddCartDtos model);

        Task<Cart> Delete(int id);

        Task<Cart> Edit(GetCartDtos model);

    }
}
