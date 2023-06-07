using Core.Utilities.Results;
using Entities.Concrete.DTOs.ModemApiDTOs;
using Entities.Concrete.Models.ModemApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.ModemApi
{
    public interface IModemApiService
    {
        Task<HttpResponseMessage> Add(Modem modem); 
        Task<HttpResponseMessage> Delete(Modem modem);
        Task<HttpResponseMessage> Update(Modem modem);
        Task<IDataResult<Modem>> GetById(Guid modemId);
        Task<IDataResult<List<Modem>>> GetAll();

        Task<IDataResult<ModemWithCompleteInfoDto>> GetWithCompleteInfoById(Guid modemId);
        Task<IDataResult<List<ModemWithCompleteInfoDto>>> GetAllWithCompleteInfo();
    }
}
