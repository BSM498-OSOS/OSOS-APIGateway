using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.AuthApiDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AuthApi
{
    public interface IAuthApiService
    {
        Task<IDataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto);
        Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
    }
}
