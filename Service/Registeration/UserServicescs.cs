using CafeteriaOrders.data;
using CafeteriaOrders.logic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaOrders.Service.Registeration
{
    public class UserServicescs : IUserServicescs
    {
        UnitOfWork uof;
        UserManager<IdentityUser> userManager;
        SignInManager<IdentityUser> SignInManager;
        private readonly IConfigurationSection _jwtSettings;
        UserManager<IdentityUser> userManeger;

        public UserServicescs(Context context , UserManager<IdentityUser> userManeger,
            IConfiguration configuration)  
        {
            context = context;
            userManager = userManager;
            userManeger = userManeger;
            _jwtSettings = configuration.GetSection("JwtSettings");

        }

        /*
        public string Register(User user)
        {
            var tmp = new IdentityUser
            {
                UserName = user.name,
                Email = user.email,
                PhoneNumber = user.phone
            };

            var res = userManeger.CreateAsync(tmp).Result;
            if (res.Succeeded) // sending otps
            {

            }
            return "Not Valid";
        }
        */
        // adding defualt claims & tokens config  ..  -> more rev nedded..

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_jwtSettings.GetSection("securityKey").Value);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        private async Task<List<Claim>> GetClaims(IdentityUser user)
        {
            var claims = new List<Claim>
            {
                // Specify ur profound claims, can be more than one
                new Claim(ClaimTypes.Name, user.UserName),
                //new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)
            };
            // adding not fixed & dynamic claims
            var roles = await userManeger.GetRolesAsync(user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

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
    
