using ETicaret.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.Utilities.Security.JWT
{
    public interface ITokenHandler
    {
        AdminToken CreateUserToken(User user, List<OperationClaim> operationClaims);
        CustomerToken CreateCustomerToken(Customer customer);
    }
}
