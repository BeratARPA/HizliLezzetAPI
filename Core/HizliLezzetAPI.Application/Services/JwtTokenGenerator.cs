using HizliLezzetAPI.Application.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HizliLezzetAPI.Application.Services
{
    public class JwtTokenGenerator
    {
        private readonly IConfiguration config;
        private readonly ISecretsRepositoryAsync secretsRepositoryAsync;

        public JwtTokenGenerator(IConfiguration config,ISecretsRepositoryAsync secretsRepositoryAsync)
        {
            this.config = config;
            this.secretsRepositoryAsync = secretsRepositoryAsync;
        }

        public string GenerateJwtToken(string userId, string username, string userEmail)
        {
            var claims = new List<Claim>()
        {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.NameIdentifier, userId),
                new Claim(ClaimTypes.Email, userEmail),
            };

            var secretKey = secretsRepositoryAsync.GetSecretAsync("JWT").Result;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}