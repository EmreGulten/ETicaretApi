using ETicaret.Core.DataAccess;
using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Repositories.UserRepository
{
    public interface IUserDal : IEntityRepository<User>
    {
        Task<List<OperationClaim>> GetUserOperationClaims(int userId);
    }
}
