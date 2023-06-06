using Demo_API_JWT_SignalR.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Demo_API_JWT_SignalR.Services
{
    public class TokenManager
    {
        private IConfiguration _config;

        public TokenManager(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User u)
        {
            string key = _config.GetSection("tokenInfo").GetSection("key").Value;
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            Claim[] claims = new[]
            {
                new Claim("Username", u.Username),
                new Claim(ClaimTypes.Role, u.IsAdmin ? "admin" : "user"),
                new Claim(ClaimTypes.Sid, u.Id.ToString())
            };

            JwtSecurityToken jwt = new JwtSecurityToken(
                claims : claims,
                signingCredentials : credentials,
                expires : DateTime.Now.AddHours(1),
                issuer : "truc", //Emetteur du token
                audience : "bidule" //Consommateur
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(jwt);
        }
    }
}
