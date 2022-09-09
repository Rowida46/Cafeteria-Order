using System;
using System.Collections.Generic;
using System.Text;

namespace CafeteriaOrders.Service.VerificationServices.OTPConfig
{
    public class TwilioConfig
    {
        public string AccountSid { get; set; } = "AC203a6b94c2bdd66c5b34ced98410cc4b";
        public string AuthToken { get; set; } = "4394a933cb83507d8b7f369e82c61d07";
        public string VerificationSid { get; set; } = "VAfac3bf9178183b31abe741f6526b267e";
        public string SMSAccountFrom { get; set; } = "+19125756281";
    }
}