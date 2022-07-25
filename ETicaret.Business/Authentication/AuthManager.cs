using ETicaret.Core.Utilities.Abstract;
using ETicaret.Core.Utilities.Security.JWT;
using ETicaret.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Authentication
{
    public class AuthManager : IAuthService
    {
        public Task<IDataResult<CustomerToken>> CustomerLogin(CustomerLoginDto customerLoginDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Register(RegisterAuthDto registerDto)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<AdminToken>> UserLogin(LoginAuthDto loginDto)
        {
            throw new NotImplementedException();
        }
    }
}
