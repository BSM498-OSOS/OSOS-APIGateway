using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AuthApi
{
    public interface IAuthUserOperationClaimsApiService
    {
        Task<HttpResponseMessage> Add(UserOperationClaim claim);
        Task<HttpResponseMessage> Delete(UserOperationClaim claim);
    }
}
