using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AuthApi
{
    public interface IAuthOperationClaimApiService
    {
        Task<IDataResult<List<OperationClaim>>> GetAll();
    }
}
