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
    public interface IAuthService
    {
        Task<IResult> Register(RegisterAuthDto registerDto);
        Task<IDataResult<AdminToken>> UserLogin(LoginAuthDto loginDto);
        Task<IDataResult<CustomerToken>> CustomerLogin(CustomerLoginDto customerLoginDto);
    }
}
