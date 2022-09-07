using CafeteriaOrders.Service.Registeration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using CafeteriaOrders.logic.DtosModels.Users;

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
        public string Register(RegisterDto userModel)
        {
            return _userService.Register(userModel);
        }
        [HttpPost]
        [AllowAnonymous]
        public Task<string> Login(RegisterDto userModel)
        {
            return _userService.Login(userModel);
        }

    }
}
