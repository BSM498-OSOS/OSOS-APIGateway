using Core.Utilities.Results;
using Entities.Concrete.Models.ModemApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.ModemApi
{
    public interface IModemBrandApiService
    {
        Task<HttpResponseMessage> Add(ModemBrand modemBrand);
        Task<HttpResponseMessage> Delete(ModemBrand modemBrand);
        Task<HttpResponseMessage> Update(ModemBrand modemBrand);
        Task<IDataResult<ModemBrand>> GetById(Guid modemBrandId);
        Task<IDataResult<List<ModemBrand>>> GetAll();
    }
}
