using FinancialManager.Domain.Authentication;
using FinancialManager.Domain.Models;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinancialManager.InfraStructure.Authentication
{
    public class TokenGenerator : ITokenGenerator
    {
        public dynamic Generator(User user)
        {
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim("Id", user.Id.ToString())
            };

            var expires = DateTime.UtcNow.AddDays(1);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ProjetoFinancer"));
            var tokenData = new JwtSecurityToken(
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                expires: expires,
                claims: claims
                );

            var token = new JwtSecurityTokenHandler().WriteToken(tokenData);
           
            return new
            {
                acess_token = token,
                expirations = expires
            };
        }
    }
}
