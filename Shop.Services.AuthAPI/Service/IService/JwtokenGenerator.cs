using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Shop.Services.AppUser.Model;
using Shop.Services.AuthAPI.Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop.Services.AuthAPI.Service.IService
{
    public class JwtokenGenerator : IJwtokenGenerator
    {
        private readonly JwtOptions _jwtOptions;

        public JwtokenGenerator(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public string GenerateToken(AppUserModel appUserModel)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
            var listClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, appUserModel.Email),
                new Claim(JwtRegisteredClaimNames.Sub, appUserModel.Id),
                new Claim(JwtRegisteredClaimNames.Name, appUserModel.UserName),
            };
            //Security token descriptions
            var tokenDesciptor = new SecurityTokenDescriptor
            {
                Audience = _jwtOptions.Audience,
                Issuer = _jwtOptions.Issuer,
                Subject = new ClaimsIdentity(listClaims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };
            // Generate the token
            var generateToken = tokenHandler.CreateToken(tokenDesciptor);
            return tokenHandler.WriteToken(generateToken);
        }
    }
}
