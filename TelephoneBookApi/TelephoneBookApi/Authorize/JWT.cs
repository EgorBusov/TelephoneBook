using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using TelephoneBookApi.Interfaces;
using TelephoneBookApi.Models;

namespace TelephoneBookApi.Authorize
{
    /// <summary>
    /// Класс для взаимодействия с JWT авторизацией
    /// </summary>
    public class JWT : IJWT
    {
        private readonly IConfiguration configuration;
        private readonly IPersoneData _persones;
        /// <summary>
        /// секретный ключ
        /// </summary>        
        /// <summary>       
        private byte[] key;
        public JWT(IConfiguration configuration, IPersoneData persones)
        {
            this.configuration = configuration;
            var secretKey = configuration.GetValue<string>("JwtSettings:SecretKey");
            key = Encoding.UTF8.GetBytes(secretKey);
            _persones = persones;
        }

        public string HashPassword(string password)
        {
            using(var sha256 = SHA256.Create())
            {
                var argHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(argHash);
            }
        }

        public string GenerateJWT(UserModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(key);
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, userInfo.Role)
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
