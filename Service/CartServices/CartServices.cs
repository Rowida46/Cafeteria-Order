using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.DtosModels.Carts;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.CartServices
{
    public class CartServices : ICartService
    {
        Context context;
        UnitOfWork uof;
        public CartServices(Context context)
        {
            uof = new UnitOfWork(context);
        }
        
        public async Task<Cart> Add(AddCartDtos model)
        {
            var cart = uof.carts.add(model);
            uof.Commit();
            return cart;
        }

        public  async Task<Cart> Delete(int id)
        {
            var meal = uof.carts.remove(id);
            uof.Commit();
            return meal;
        }

        public async Task<GetCartDtos> Details(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Cart> Edit(GetCartDtos model)
        {
            return uof.carts.edit(model);
        }

        public async Task<IEnumerable<GetCartDtos>> Get()
        {
            return uof.carts.get();
        }

        public async Task<IEnumerable<CartItemViewModel>> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalPrice()
        {
            throw new NotImplementedException();
        }
    }
}
