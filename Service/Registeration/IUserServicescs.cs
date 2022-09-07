using CafeteriaOrders.logic.DtosModels.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.Registeration
{
    public interface IUserServicescs
    {
        Task<string> Login(RegisterDto userModel);

        string Register(RegisterDto userModel);
    }
}
