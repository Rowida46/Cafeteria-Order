using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CafeteriaOrders.logic.DtosModels.OTP;
using CafeteriaOrders.Service.VerificationServices.OTPConfig;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Exceptions;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Verify.V2.Service;
using Twilio.Types;

namespace CafeteriaOrders.Service.VerificationServices
{
    public class Verification : IVerification
    {
        private readonly TwilioConfig _config;
        // private readonly Configuration.Twilio _config;
        //private readonly System.Configuration.Twilio _config;

        public Verification(IOptions<TwilioConfig> configuration)
        {
            _config = configuration.Value;
            TwilioClient.Init(_config.AccountSid, _config.AuthToken);
        }

        public async Task<VerificationResult> CheckVerificationAsync(string number, string code)
        {
            try
            {
                var verificationCheckResource = await VerificationCheckResource.CreateAsync(
                    to: number,
                    code: code,
                    pathServiceSid: _config.VerificationSid
                );
                return verificationCheckResource.Status.Equals("approved") ?
                    new VerificationResult(verificationCheckResource.Sid) :
                    new VerificationResult(new List<string> { "Wrong code. Try again." });
            }
            catch (TwilioException e)
            {
                return new VerificationResult(new List<string> { e.Message });
            }
        }

        public async Task<VerificationResult> StartVerificationAsync(string phoneNumber, string channel)
        {
            try
            {
                var verificationResource = await VerificationResource.CreateAsync(
                    to: phoneNumber,
                    channel: "sms",
                    pathServiceSid: _config.VerificationSid
                );
                return new VerificationResult(verificationResource.Status);
            }
            catch (TwilioException e)
            {
                return new VerificationResult(new List<string> { e.Message });
            }
        }

        public async Task<MessageResource> SendSmsAsync(string number, string message)
        {
            try
            {

                return await MessageResource.CreateAsync(
                 to: number,
                 from: new PhoneNumber(_config.SMSAccountFrom),
                 body: message);
            }
            catch (TwilioException e) { return null; }
        }

    }
}
