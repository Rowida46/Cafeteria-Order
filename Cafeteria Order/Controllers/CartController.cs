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
        public async Task<IEnumerable<GetCartDtos>> Get()
        {
            return await _cartService.Get();
        }


        [HttpGet]
        public async Task<GetCartDtos> Details(int id)
        {
            return await _cartService.Details(id);
        }


        [HttpPost]
        public async Task<Cart> Add(AddCartDtos model)
        {
            return await _cartService.Add(model);
        }

        [HttpGet]
        public async Task<Cart> Delete(int id)
        {
            return await _cartService.Delete(id);

        }

        [HttpPost]
        public async Task<Cart> Edit(GetCartDtos model)
        {
            return await _cartService.Edit(model);

        }

        [HttpPost]
        // public async Task<ServiceResponse<GetCartDtos>> checkout(List<CartItem> model)
        public async Task<ServiceResponse<GetCartDtos>> checkout(AddCartDtos model)
        {
            return await _cartService.checkout(model);
        }

    }
}
