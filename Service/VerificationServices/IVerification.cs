using CafeteriaOrders.logic.DtosModels.OTP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace CafeteriaOrders.Service.VerificationServices
{
    public interface IVerification
    {
        Task<VerificationResult> StartVerificationAsync(string phoneNumber, string channel);

        Task<VerificationResult> CheckVerificationAsync(string phoneNumber, string code);

        Task<MessageResource> SendSmsAsync(string number, string message);
    }
}
