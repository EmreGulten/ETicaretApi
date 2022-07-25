using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.Extensions
{
    public static class ClaimsExtensions
    {
        public static void AddName(this ICollection<Claim> claims,string name)
        {
            claims.Add(new Claim(ClaimTypes.Name,name));
        }
        public static void AddId(this ICollection<Claim> claims,string id)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, id));
        }
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(roles => claims.Add(new Claim(ClaimTypes.Role, roles)));
        }
    }
}
