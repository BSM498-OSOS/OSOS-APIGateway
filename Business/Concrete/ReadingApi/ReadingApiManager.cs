using Business.Abstract;
using Business.Abstract.ReadingApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Utilities.Results;
using Entity.Concrete;
using Entity.Concrete.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ReadingApi
{
    public class ReadingApiManager : IReadingApiService
    {
        HttpClient _httpClient;
        public ReadingApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.ReadingApiUrl;
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<Reading>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllReadings");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Reading>>(jsonBody);
                return new SuccessDataResult<List<Reading>>(data);
            }
            return new ErrorDataResult<List<Reading>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ReadingConsumptionDto>>> GetAllConsumptions()
        {
            var response = await _httpClient.GetAsync("getAllTotalConsumptions");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingConsumptionDto>>(jsonBody);
                return new SuccessDataResult<List<ReadingConsumptionDto>>(data);
            }
            return new ErrorDataResult<List<ReadingConsumptionDto>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ReadingConsumption>>> GetAllConsumptionsDaily()
        {
            var response = await _httpClient.GetAsync("getAllTotalConsumptionDaily");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingConsumption>>(jsonBody);
                return new SuccessDataResult<List<ReadingConsumption>>(data);
            }
            return new ErrorDataResult<List<ReadingConsumption>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ReadingConsumption>>> GetAllConsumptionsMontly()
        {
            var response = await _httpClient.GetAsync("getAllTotalConsumptionMonthly");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingConsumption>>(jsonBody);
                return new SuccessDataResult<List<ReadingConsumption>>(data);
            }
            return new ErrorDataResult<List<ReadingConsumption>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ReadingConsumption>>> GetAllConsumptionsYearly()
        {
            var response = await _httpClient.GetAsync("getAllTotalConsumptionYearly");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingConsumption>>(jsonBody);
                return new SuccessDataResult<List<ReadingConsumption>>(data);
            }
            return new ErrorDataResult<List<ReadingConsumption>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<Reading>>> GetByDates(DateTime minDate, DateTime maxDate)
        {
            var response = await _httpClient.GetAsync($"getAllReadingsbyDates?minDate={minDate.Year}-{minDate.Month}-{minDate.Day}&maxDate={maxDate.Year}-{maxDate.Month}-{maxDate.Day}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Reading>>(jsonBody);
                return new SuccessDataResult<List<Reading>>(data);
            }
            return new ErrorDataResult<List<Reading>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<Reading>>> GetBySerialNo(int serialNo)
        {
            var response = await _httpClient.GetAsync($"getReadingsBySerialNo?serialNo={serialNo}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Reading>>(jsonBody);
                return new SuccessDataResult<List<Reading>>(data);
            }
            return new ErrorDataResult<List<Reading>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ReadingConsumption>>> GetConsumptionsDailyBySerialNo(int serialNo)
        {
            var response = await _httpClient.GetAsync($"getTotalConsumptionDailyBySerialNo?serialNo={serialNo}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingConsumption>>(jsonBody);
                return new SuccessDataResult<List<ReadingConsumption>>(data);
            }
            return new ErrorDataResult<List<ReadingConsumption>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ReadingConsumption>>> GetConsumptionsMontlyBySerialNo(int serialNo)
        {
            var response = await _httpClient.GetAsync($"getTotalConsumptionMonthlyBySerialNo?serialNo={serialNo}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingConsumption>>(jsonBody);
                return new SuccessDataResult<List<ReadingConsumption>>(data);
            }
            return new ErrorDataResult<List<ReadingConsumption>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ReadingConsumption>>> GetConsumptionsYearlyBySerialNo(int serialNo)
        {
            var response = await _httpClient.GetAsync($"getTotalConsumptionYearlyBySerialNo?serialNo={serialNo}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingConsumption>>(jsonBody);
                return new SuccessDataResult<List<ReadingConsumption>>(data);
            }
            return new ErrorDataResult<List<ReadingConsumption>>();
        }
    }
}
