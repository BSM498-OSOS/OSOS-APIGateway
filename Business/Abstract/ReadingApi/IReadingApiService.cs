using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.ReadingApi
{
    public interface IReadingApiService
    {
        Task<IDataResult<List<Reading>>> GetBySerialNo(int serialNo);

        Task<IDataResult<List<Reading>>> GetByDates(DateTime minDate, DateTime maxDate);
        Task<IDataResult<List<Reading>>> GetAll();

        Task<IDataResult<List<ReadingConsumptionDto>>> GetAllConsumptions();

        Task<IDataResult<List<ReadingConsumption>>> GetAllConsumptionsMontly();
        Task<IDataResult<List<ReadingConsumption>>> GetAllConsumptionsDaily();
        Task<IDataResult<List<ReadingConsumption>>> GetAllConsumptionsYearly();

        Task<IDataResult<List<ReadingConsumption>>> GetConsumptionsMontlyBySerialNo(int serialNo);
        Task<IDataResult<List<ReadingConsumption>>> GetConsumptionsDailyBySerialNo(int serialNo);
        Task<IDataResult<List<ReadingConsumption>>> GetConsumptionsYearlyBySerialNo(int serialNo);
    }
}
