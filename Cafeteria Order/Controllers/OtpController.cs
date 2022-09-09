using CafeteriaOrders.logic.DtosModels.OTP;
using CafeteriaOrders.Service.VerificationServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twilio.Rest.Api.V2010.Account;

namespace Cafeteria_Order.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        private readonly IVerification _otpService;
        private readonly UserManager<ApplicationUser> _userManager;

        /*This control not a part of proj -> it's only a singleTone testify of twilli setting along with its fuctionality*/
        public OtpController(IVerification otpService)
        {
            _otpService = otpService;
        }

        [HttpPost]
        public async Task<MessageResource> SendSMS(regDTO model)
        {
            return await _otpService.SendSmsAsync(model.phone, "Testfing fuctionality of twilio");
        }

        [HttpPost]
        public async Task<VerificationResult> SendOtpCode(regDTO model)
        {

            try
            {
                return await _otpService.StartVerificationAsync(model.phone, model.channel);
            }
            catch
            {
                return new VerificationResult(new List<string> { "Your phone number is already verified" });
            }
        }

        [HttpPost]
        public async Task<VerificationResult> checkOtp(regDTO model)
        {
            try {
                return await _otpService.CheckVerificationAsync(model.phone, model.code);
            }
            catch
            {
                return new VerificationResult(new List<string> { "Your phone number is already verified" });
            }

        }
    }
}
