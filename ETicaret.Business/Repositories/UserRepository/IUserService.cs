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
    public interface IUserService
    {
        Task Add(RegisterAuthDto authDto);
        Task<IResult> Update(User user);
        Task<IResult> Delete(User user);
        Task<IResult> UpdateUserByAdminPanel(UserDto user);
        Task<IResult> ChangePassword(UserChangePasswordDto userChangePasswordDto);
        Task<IDataResult<List<User>>> GetList();
        Task<User> GetByEmail(string email);
        Task<List<OperationClaim>> GetUserOperationClaims(int userId);
        Task<IDataResult<User>> GetById(int id);
        Task<User> GetByIdForAuth(int id);
    }
}
