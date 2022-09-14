using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.DtosModels.Carts;
using CafeteriaOrders.logic.Models;
using CafeteriaOrders.UnitOfWork.GenericUnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.CartServices
{
    public class CartServices : ICartService
    {
        Context context;
        UnitOfWorkRepo uof;
        IUnitOfWork _uof;
        public CartServices(Context context)
        {
            uof = new UnitOfWorkRepo(context);
            _uof = new UnitOfWorkGeneric(context);
        }
        public async Task<ServiceResponse<Cart>> Add(Cart model)
        {
            var service = new ServiceResponse<Cart>();
            try
            {
                var meal = await _uof.CartsRepository.Create(model);
                _uof.Commit();
                service.Data = model;
                service.Message = "Cart Added";
            }
            catch (Exception e)
            {
                service.Message = e.Message;
                service.Success = false;
            }
            return service;
            
            //    var crt = uof.carts.add(model);
            //    uof.Commit();
            //    return crt;
        }
                                                                                                                                                                                                                                                        
        public async Task<bool> Delete(int id)
        {
            try
            {
                await _uof.CartsRepository.Delete(id);
                _uof.Commit();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            /*var meal = uof.carts.remove(id);
            uof.Commit();
            return meal;
            */
        }

        public async Task<ServiceResponse<List<Cart>>> Details(int id)
        {
            var service = new ServiceResponse<List<Cart>>();
            try
            {
                var tmp = _uof.CartsRepository.Get(includeProperties : "cartItems").Where(crt =>crt.id == id).ToList();
                service.Data = tmp;
                service.Success = tmp == null ? false : true;
                service.Message = "Details of a specific Cart";

            }
            catch (Exception e)
            {
                service.Success = false;
                service.Message = e.Message;
            }
            return service;
        }

        public async Task<ServiceResponse<Cart>> Edit(Cart model)
        {
            var service = new ServiceResponse<Cart>();

            try
            {
                await _uof.CartsRepository.Update(model.id, model);
                _uof.Commit();
                service.Success = true;
                service.Data = model;
                service.Message = "Updated";
            }
            catch (Exception e)
            {
                service.Message = e.Message;
                service.Success = false;
            }
            return service;
        }

        public async Task<ServiceResponse<List<Cart>>> Get()
        {
            var service = new ServiceResponse<List<Cart>>();
            try
            {
                var tmp = _uof.CartsRepository.Get(includeProperties: "cartItems").ToList();
                service.Data = tmp;
                service.Success = tmp == null ? false : true;
                service.Message = "View Carts";

            }
            catch (Exception e)
            {
                service.Success = false;
                service.Message = e.Message;
            }
            return service;
        }

        public async Task<ServiceResponse<List<Cart>>> GetCartItems()
        {
            var service = new ServiceResponse<List<Cart>>();
            try
            {
                var tmp = _uof.CartsRepository.Get(includeProperties: "CartItemd").ToList();
                service.Data = tmp;
                service.Success = tmp == null ? false : true;
                service.Message = "View Meals";

            }
            catch (Exception e)
            {
                service.Success = false;
                service.Message = e.Message;
            }
            return service;
        }

        public async Task<decimal> GetTotalPrice()
        {
            throw new NotImplementedException();
        }
        public  decimal checkValidItem(CartItem model) {
            /*
             1-  get meal details by id
             2- check quantity 
             3- calc total price
             */
            // Meals meal = uof.meal.details(model.mealId);
            var meal = uof.meal.details(model.mealId);
            decimal totalPrice =0;
            if(meal.numberofUnits >= model.quantity)
            {
                totalPrice = model.quantity * meal.price;
                return totalPrice;
            }

            return totalPrice;
        }

        public async Task<ServiceResponse<GetCartDtos>> checkout(AddCartDtos model)
        {
            var service = new ServiceResponse<GetCartDtos>();
            //string massage= "";
            List<string> massage = new List<string>();
            var cart = new GetCartDtos { cartItems = new Collection<CartItem>(), totalPrice = 0 };
            decimal totalprice = 0;
            var items = model.cartItems;
            foreach (var item in items)
            { 
                decimal price = checkValidItem(item);
                if (!price.Equals(0))
                {
                    cart.cartItems.Add(item);
                   // listValid.Add(item);
                    totalprice += price;
                }
                else
                {
                    var meal = uof.meal.details(item.mealId);
                    massage.Add(meal.name) ;
                }
            }
            cart.totalPrice = totalprice;
            service.Data = cart;
            service.Message = "Your Cart Receipt";
            service.Message += massage == null ? "" : " This Items are out of Stock " + string.Join(" and ", massage.ToArray());
            return service;
        }
    }
}
