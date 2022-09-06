using AutoMapper;
using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.DtosModels.Carts;
using CafeteriaOrders.logic.Models;
using CafeteriaOrders.UnitOfWork.GenericUnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.CartServices
{
    public class CartServices : ICartService
    {
        private readonly IMapper _mapper;
        Context context;
        UnitOfWorkRepo uof;
        IUnitOfWork unitOfWork;
        public CartServices(Context context)
        {
            // unitOfWork = new UnitOfWork(context);

            uof = new UnitOfWorkRepo(context);
        }
        
        public async Task<Cart> Add(AddCartDtos model)
        {
            var crt = uof.carts.add(_mapper.Map<Cart>(model));
            //var crt = uof.carts.add(model);
            uof.Commit();
            return  crt;
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

        public async Task<IEnumerable<CartItemDtos>> GetCartItems()
        {
            throw new NotImplementedException();
        }

        public async Task<decimal> GetTotalPrice()
        {
            throw new NotImplementedException();
        }
        public  decimal checkValidItem(CartItem model) {
            /*
             1-  get meal details by id
             2- check quantity 
             */
            // Meals meal = uof.meal.details(model.mealId);
            var meal = uof.meal.details(model.mealId);
            decimal totalPrice =0;
            if(meal.numberofUnits == model.quantity)
            {
                totalPrice = model.quantity * meal.price;
                return totalPrice;
            }

            return totalPrice;
        }

        public async Task<ServiceResponse<GetCartDtos>> checkout(AddCartDtos model)
        {
            var service = new ServiceResponse<GetCartDtos>();
            string massage= "";
             var cart = new GetCartDtos();
            decimal totalprice = 0;
            var items = model.cartItems;
            foreach (var item in items)
            {
                decimal price = checkValidItem(item);
                if (price.Equals(0.0))
                {
                    cart.cartItems.Add(item);
                   // listValid.Add(item);
                    totalprice += price;
                }
                else
                {
                    var meal = uof.meal.details(item.mealId);
                    massage += meal.name + " and ";
                }
            }
            cart.totalPrice = totalprice;
            service.Data = cart;
            service.Message = massage+"this items is not vaild";

            return service;
        }
    }
}
