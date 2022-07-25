using ETicaret.Core.Utilities.Abstract;
using ETicaret.Entities.Concrete;
using ETicaret.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Business.Repositories.UserRepository
{
    public class UserManager : IUserService
    {
        public Task Add(RegisterAuthDto authDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> ChangePassword(UserChangePasswordDto userChangePasswordDto)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Delete(User user)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<User>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdForAuth(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<List<User>>> GetList()
        {
            throw new NotImplementedException();
        }

        public Task<List<OperationClaim>> GetUserOperationClaims(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Update(User user)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> UpdateUserByAdminPanel(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
