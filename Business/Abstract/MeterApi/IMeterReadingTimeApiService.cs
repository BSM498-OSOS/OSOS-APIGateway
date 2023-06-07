using Core.Utilities.Results;
using Entities.Models.MeterApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.MeterApi
{
    public interface IMeterReadingTimeApiService
    {
        Task<IDataResult<List<ReadingTime>>> GetAll();
        Task<IDataResult<ReadingTime>> GetById(Guid id);
    }
}
