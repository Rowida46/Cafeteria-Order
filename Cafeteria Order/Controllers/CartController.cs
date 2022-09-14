using CafeteriaOrders.data;
using CafeteriaOrders.logic.DtosModels;
using CafeteriaOrders.logic.DtosModels.Carts;
using CafeteriaOrders.logic.Models;
using CafeteriaOrders.Service.CartServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cafeteria_Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        
        [HttpGet]
        public async Task<ServiceResponse<List<Cart>>> Get()
        {
            return await _cartService.Get();
        }

        [HttpGet]
        public async Task<ServiceResponse<List<Cart>>>  Details(int id)
        {
            return await _cartService.Details(id);
        }

        [HttpPost]
        public async Task<ServiceResponse<Cart>> Add(Cart model)
        {
            return await _cartService.Add(model);
        }

        [HttpGet]
        public async Task<bool> Delete(int id)
        {
            return await _cartService.Delete(id);

        }

        [HttpPost]
        public async Task<ServiceResponse<Cart>> Edit(Cart model)
        {
            return await _cartService.Edit(model);

        }

        [HttpPost]
        public async Task<ServiceResponse<GetCartDtos>> checkout(AddCartDtos model)
        {
            return await _cartService.checkout(model);
        }

    }
}
