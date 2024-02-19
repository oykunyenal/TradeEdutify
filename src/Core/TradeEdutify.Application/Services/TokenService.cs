using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TradeEdutify.Application.Interfaces.Services;

namespace TradeEdutify.Application.Services
{
    public class TokenService : ITokenService
    {
        private const string SecretKey = "5db61e4cd8776c7969cfd62456da639a4c87683a:8763434884872";
        private static readonly byte[] SecretBytes = Encoding.UTF8.GetBytes(SecretKey);

        public string GenerateToken(string Username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.NameIdentifier, Username),
        });

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretBytes), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}