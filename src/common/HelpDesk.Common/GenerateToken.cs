using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HelpDesk.Common
{
    public class GenerateToken
    {
        public static string Generate(IConfiguration configuraiton, Claim[] claim)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuraiton["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var expiry = DateTime.Now.AddDays(1);

            var token = new JwtSecurityToken(
                issuer: configuraiton["Jwt:Issuer"],
                audience: configuraiton["Jwt:Audience"],
                claims: claim,
                expires: expiry,
                signingCredentials: credentials,
                notBefore: DateTime.Now
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
