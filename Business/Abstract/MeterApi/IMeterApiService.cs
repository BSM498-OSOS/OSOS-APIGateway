using Core.Utilities.Results;
using Entities.DTOs.MeterApiDTOs;
using Entities.Models.MeterApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.MeterApi
{
    public interface IMeterApiService
    {
        Task<HttpResponseMessage> Add(Meter meter);
        Task<HttpResponseMessage> Delete(Meter meter);
        Task<HttpResponseMessage> Update(Meter meter);
        Task<IDataResult<Meter>> GetById(Guid meterId);
        Task<IDataResult<Meter>> GetBySerialNo(int serialNo);
        Task<IDataResult<List<Meter>>> GetAll();

        Task<IDataResult<MeterWithCompleteInfoDto>> GetWithCompleteInfoById(Guid meterId);
        Task<IDataResult<MeterWithCompleteInfoDto>> GetWithCompleteInfoBySerialNo(int serialNo);
        Task<IDataResult<List<MeterWithCompleteInfoDto>>> GetAllWithCompleteInfo();
    }
}
