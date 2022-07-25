using ETicaret.Core.DataAccess.EntityFramework;
using ETicaret.Data.Concrete.EntityFramework;
using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Data.Repositories.UserRepository
{
    public class EfUserDal : EfEntityRepositoryBase<User, ContextDb>, IUserDal
    {
        public async Task<List<OperationClaim>> GetUserOperationClaims(int userId)
        {
            using (var context = new ContextDb())
            {
                var result = from userOperationClaim in context.UserOperationClaims.Where(x => x.UserId == userId)
                             join operationClaim in context.OperationClaims on userOperationClaim.OperationClaimId equals operationClaim.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };
                return await result.OrderBy(x => x.Name).ToListAsync();
            }
        }
    }
}
