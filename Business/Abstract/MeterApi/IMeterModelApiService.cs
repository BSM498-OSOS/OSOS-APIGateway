using Core.Utilities.Results;
using Entities.Models.MeterApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.MeterApi
{
    public interface IMeterModelApiService
    {
        Task<HttpResponseMessage> Add(MeterModel meterModel);
        Task<HttpResponseMessage> Delete(MeterModel meterModel);
        Task<HttpResponseMessage> Update(MeterModel meterModel);
        Task<IDataResult<MeterModel>> GetById(Guid meterBrandId);
        Task<IDataResult<List<MeterModel>>> GetAll();
    }
}
