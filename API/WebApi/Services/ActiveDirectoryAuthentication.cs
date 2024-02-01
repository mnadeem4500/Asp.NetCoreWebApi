using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ExtremeClassified.WebApi.Dtos.Account;
using ExtremeClassified.WebApi.Dtos.Identity;

namespace ExtremeClassified.WebApi.Services
{
    public class ActiveDirectoryAuthentication
    {
        private readonly string tokenKey;
        private readonly double _expiry;
        private readonly string _issuer;
        private readonly string _audience;

        private readonly string _serverName;
        private readonly ILogger logger;


        public ActiveDirectoryAuthentication(IConfiguration configuration, ILoggerFactory loggerFactory)
        {
            _expiry = double.Parse(configuration["JWT:ValidHours"]);
            _audience = configuration["JWT:ValidAudience"];
            _issuer = configuration["JWT:ValidIssuer"];
            tokenKey = configuration["JWT:Secret"];
            _serverName = configuration["ADSI_PARAMETER:ServerName"];

            logger = loggerFactory.CreateLogger<ActiveDirectoryAuthentication>();
        }

        public string Authenticate(LoginDto login)
        {
            return string.Empty;

            var portalUser = new UserDto();

            try
            {
                //var entry = new DirectoryEntry(_serverName, login.UserName, login.Password);
                //var nativeObj = entry.NativeObject;

                //portalUser.UserName = login.UserName;
                //portalUser.Email = entry.Username;
            
            }
            catch (Exception ex)
            {
                logger.LogError($"Error while authenticate user from (Active Directory), {ex.Message}");
                return null;
            }



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
                new Claim(ClaimTypes.NameIdentifier,user.UserId)
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
