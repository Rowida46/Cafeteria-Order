using CafeteriaOrders.data;
using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels.Carts;
using CafeteriaOrders.logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CafeteriaOrders.logic.DataAccess
{
    public class CartRepository : Repository<Cart>
    {
        Context context;
        public CartRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public Cart add(AddCartDtos model)
        {
            var tmp = new Cart
            {
                cartItems = model.cartItems,
                //totalPrice = model.totalPrice,
            };
            insert(tmp);
            return tmp;
        }

        public IEnumerable<GetCartDtos> get()
        {
            return AsQueryable().Select(crt => new GetCartDtos
            {
                cartItems = crt.cartItems,
                totalPrice =   crt.totalPrice

            });
        }
        
        public Cart remove(int id) // to delete the cart as a whole...
        {
            var tmp = AsQueryable().Where(cart => cart.id == id).FirstOrDefault();
            delete(tmp);
            return tmp;
        }

        public Cart edit(GetCartDtos model)
        {
            var tmp = new Cart { 
            id = model.id,
            totalPrice = model.totalPrice,
            cartItems = model.cartItems
            };
            Update(tmp);
            return tmp;
        }



    }
}
