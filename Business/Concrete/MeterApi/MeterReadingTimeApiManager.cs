using Business.Abstract.MeterApi;
using Business.Consts;
using Core.Utilities.Results;
using Entities.Models.MeterApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.MeterApi
{
    public class MeterReadingTimeApiManager : IMeterReadingTimeApiService
    {
        HttpClient _httpClient;
        public MeterReadingTimeApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.MeterReadingTimeApiUrl;
        }

        public async Task<IDataResult<List<ReadingTime>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllReadingTimes");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ReadingTime>>(jsonBody);
                return new SuccessDataResult<List<ReadingTime>>(data);
            }
            return new ErrorDataResult<List<ReadingTime>>();
        }

        public async Task<IDataResult<ReadingTime>> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"getReadingTimeById?id={id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ReadingTime>(jsonBody);
                return new SuccessDataResult<ReadingTime>(data);
            }
            return new ErrorDataResult<ReadingTime>();
        }
    }
}
