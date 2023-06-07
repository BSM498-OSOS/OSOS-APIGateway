using Core.Utilities.Results;
using Entities.Concrete.Models.ModemApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.ModemApi
{
    public interface IModemModelApiService
    {
        Task<HttpResponseMessage> Add(ModemModel modemModel);
        Task<HttpResponseMessage> Delete(ModemModel modemModel);
        Task<HttpResponseMessage> Update(ModemModel modemModel);
        Task<IDataResult<ModemModel>> GetById(Guid modemBrandId);
        Task<IDataResult<List<ModemModel>>> GetAll();
    }
}
