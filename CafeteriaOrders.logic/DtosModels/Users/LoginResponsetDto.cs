using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.DtosModels
{
    public class LoginResponsetDto
    {
        public string userId { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string token { get; set; }

    }
}
