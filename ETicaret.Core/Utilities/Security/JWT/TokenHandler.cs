
using ETicaret.Core.Extensions;
using ETicaret.Entities.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ETicaret.Core.Utilities.Security.JWT
{
    public class TokenHandler : ITokenHandler
    {
        IConfiguration Configuration;
        public TokenHandler(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public AdminToken CreateUserToken(User user, List<OperationClaim> operationClaims)
        {
            AdminToken token = new AdminToken();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            token.Expiration = DateTime.Now.AddMinutes(60);
            JwtSecurityToken securityToken = new JwtSecurityToken(
              issuer: Configuration["Token:Issuer"],
              audience: Configuration["Token:Audience"],
              expires: token.Expiration,
              claims: SetClaim(user, operationClaims),
              notBefore: DateTime.Now,
              signingCredentials: signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            token.AdminAccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);
            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        private IEnumerable<Claim> SetClaim(User user,List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddId(user.Id.ToString());
            claims.AddName(user.Name);
            claims.AddRoles(operationClaims.Select(x => x.Name).ToArray());
            return claims;
        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }

        public CustomerToken CreateCustomerToken(Customer customer)
        {
            CustomerToken token = new CustomerToken();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            token.Expiration = DateTime.Now.AddMinutes(60);
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: Configuration["Token:Issuer"],
                audience: Configuration["Token:Audience"],
                expires:token.Expiration,
                claims:SetCustomerClaims(customer),
                notBefore:DateTime.Now,
                signingCredentials:signingCredentials
                );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            token.CustomerAccessToken = jwtSecurityTokenHandler.WriteToken(securityToken);

            token.RefreshToken = CreateRefreshToken();
            return token;
        }

        private IEnumerable<Claim> SetCustomerClaims(Customer customer)
        {
            var claims = new List<Claim>();
            claims.AddId(customer.Id.ToString());
            claims.AddName(customer.Name);
            return claims;
        }
    }
}
