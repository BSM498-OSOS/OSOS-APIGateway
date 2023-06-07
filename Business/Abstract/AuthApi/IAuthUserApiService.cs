using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AuthApi
{
    public interface IAuthUserApiService
    {
        Task<IDataResult<UserWithCompleteInfoDto>> GetById(Guid id);
        Task<IDataResult<List<UserWithCompleteInfoDto>>> GetAll();
    }
}
