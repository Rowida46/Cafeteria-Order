using CafeteriaOrders.logic.DtosModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.Registeration
{
    public interface IUserServicescs
    {
        Task<LoginResponsetDto> Login(LoginRequestDto userModel);

        Task<string> Register(RegisterDto userModel);
    }
}
