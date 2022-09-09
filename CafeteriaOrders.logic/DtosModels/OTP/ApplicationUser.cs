using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.logic.DtosModels.OTP
{
    public class ApplicationUser : IdentityUser
    {

        public bool Verified { get; set; }

    }
}
