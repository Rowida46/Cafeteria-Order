using CafeteriaOrders.Service.Registeration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CafeteriaOrders.logic.DtosModels;

namespace Cafeteria_Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserServicescs _userService;

        public AccountController(IUserServicescs userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<string> Register(RegisterDto userModel)
        {
            return await _userService.Register(userModel);
        }
        
        [HttpPost]
        [AllowAnonymous]
        public Task<LoginResponsetDto> Login(LoginRequestDto userModel)
        {
            return _userService.Login(userModel);
        }

    }
}
