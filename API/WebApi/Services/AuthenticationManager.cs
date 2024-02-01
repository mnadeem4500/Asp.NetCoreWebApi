using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Functions;
using ExtremeClassified.WebApi.Dtos.Identity;

namespace ExtremeClassified.WebApi.Services
{
    public class AuthenticationManager
    {
        private readonly string tokenKey;
        private readonly double _expiry;
        private readonly string _issuer;
        private readonly string _audience;
        private readonly UserFunctions userFunctions;

        public AuthenticationManager(IConfiguration configuration, UserFunctions userFunctions)
        {
            var configuration1 = configuration;
            _expiry = double.Parse(configuration1["JWT:ValidHours"]);
            _audience = configuration1["JWT:ValidAudience"];
            _issuer = configuration1["JWT:ValidIssuer"];
            tokenKey = configuration1["JWT:Secret"];
            this.userFunctions = userFunctions;
        }

        public string? Authenticate(LoginDto login)
        {
            var portalUser = userFunctions.ValidateUserLogin(login);
            if (portalUser is null)
                return null;
            var token = GenerateToken(portalUser);

            return token;
        }

        private string GenerateToken(UserDto user)
        {

            var key = Encoding.UTF8.GetBytes(tokenKey);

            var authClaims = new List<Claim>(new[]
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserId),
                new Claim("FullName",$"{user.FirstName} {user.LastName}")
            });
            var authSigningKey = new SymmetricSecurityKey(key);

            var jwtToken = new JwtSecurityToken(
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddHours(_expiry),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256Signature)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return token;
        }
    }
}