using Core.Utilities.Results;
using Entities.Models.MeterApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.MeterApi
{
    public interface IMeterBrandApiService
    {
        Task<HttpResponseMessage> Add(MeterBrand meterBrand);
        Task<HttpResponseMessage> Delete(MeterBrand meterBrand);
        Task<HttpResponseMessage> Update(MeterBrand meterBrand);
        Task<IDataResult<MeterBrand>> GetById(Guid meterBrandId);
        Task<IDataResult<List<MeterBrand>>> GetAll();
    }
}
