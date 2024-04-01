using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TodoApi.Backend.Repositories
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly IConfiguration _configuration;

        public AutenticacaoRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GerarTokenJwtAsync(string login, string senha)
        {
            if (login == "usuario" && senha == "senha123")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, login)
                };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:ChaveSecreta"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Emissor"],
                    audience: _configuration["Jwt:Destinatario"],
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpiracaoMinutos"])),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
            }

            return null;
        }

        public async Task<bool> ValidarTokenJwtAsync(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:ChaveSecreta"]);

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = _configuration["Jwt:Emissor"],
                    ValidateAudience = true,
                    ValidAudience = _configuration["Jwt:Destinatario"],
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
