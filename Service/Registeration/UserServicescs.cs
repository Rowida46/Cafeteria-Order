using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using CafeteriaOrders.logic.DtosModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Twilio.Rest.Verify.V2.Service;

//using Microsoft.AspNetCore.Authorization;

namespace CafeteriaOrders.Service.Registeration
{
    public class UserServicescs : IUserServicescs
    {
        /*
        UnitOfWorkRepo uof;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> SignInManager;
        private readonly IConfigurationSection _jwtSettings;
        UserManager<IdentityUser> userManeger;
        */
       
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> signInManager;
        private readonly IConfigurationSection _jwtSettings;
        public UserServicescs(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _jwtSettings = configuration.GetSection("JwtSettings");
        }


        public async Task<string> Register(RegisterDto user)
        {

            var tmp = new IdentityUser
            {
                UserName = user.name,
                Email = user.email,
                PhoneNumber = user.phone
            
            };
            Task res = userManager.CreateAsync(tmp);
            res.Wait();
            if (res.IsCompleted) // sending otps
            {
                // sending otps
                /*
                * add role..
                * add enum for roles in db
                * add user dto + spesify role in field... 
                *  [Authorize(Roles = "")] ->spesify role name in qoutes.
                */
                await userManager.AddToRoleAsync(tmp, "Admin");
                var result = userManager.AddPasswordAsync(tmp, user.passwordHash).Result;
                if (result.Succeeded)
                    return "Registred";
            
            // var res_role = userManager.AddToRoleAsync(tmp, user.role).Result; // change name in qoute by model.rolename

            // sending otps
            /*if (res_role.Succeeded)
            {
                res = userManager.AddPasswordAsync(tmp, user.passwordHash).Result; // change pass to ->user.pass
                return "valid";
            }*/
        }
            return "Not Valid";
        }

        public async Task SendOTP(string phoneNumber, string channel)
        {
           /*
            var user = await signInManager.GetTwoFactorAuthenticationUserAsync();
            if (user == null)
            {
                throw new InvalidOperationException("Unable to load two-factor authentication user.");
            }
           */
          

        }

        public async Task<LoginResponsetDto> Login(LoginRequestDto userModel)
        {
            var user = userManager.FindByNameAsync(userModel.name).Result;

            if (user != null && await userManager.CheckPasswordAsync(user, userModel.passwordHash))
            {
                var signingCredentials = GetSigningCredentials();
                var claims = GetClaims(user);
                var tokenOptions = GenerateTokenOptions(signingCredentials, await claims);
                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return new LoginResponsetDto { name = user.UserName,token = token,email = user.Email,userId = user.Id};
            }
            return null;
        }

      
        // adding defualt claims & tokens config  ..  -> more rev nedded..
        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        //[AllowAnonymous]
        private async Task<List<Claim>> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                //new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        //[AllowAnonymous]
        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken(
                issuer: _jwtSettings.GetSection("validIssuer").Value,
                audience: _jwtSettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtSettings.GetSection("expiryInMinutes").Value)),
                signingCredentials: signingCredentials);
            return tokenOptions;
        }
    }
}
