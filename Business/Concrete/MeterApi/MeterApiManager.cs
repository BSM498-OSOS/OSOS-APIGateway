using Business.Abstract;
using Business.Abstract.MeterApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.AuthApiDTOs;
using Entities.DTOs.MeterApiDTOs;
using Entities.Models.MeterApi;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meter = Entities.Models.MeterApi.Meter;

namespace Business.Concrete.MeterApi
{
    public class MeterApiManager : IMeterApiService
    {
        HttpClient _httpClient;
        public MeterApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.MeterApiUrl;
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(Meter meter)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addMeter", data);
        }


        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(Meter meter)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteMeter"), Content = data, Method = HttpMethod.Delete });
        }


        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<Meter>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllMeters");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Meter>>(jsonBody);
                return new SuccessDataResult<List<Meter>>(data);
            }
            return new ErrorDataResult<List<Meter>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<MeterWithCompleteInfoDto>>> GetAllWithCompleteInfo()
        {
            var response = await _httpClient.GetAsync("getAllMetersWithCompleteInfo");

            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MeterWithCompleteInfoDto>>(jsonBody);
                return new SuccessDataResult<List<MeterWithCompleteInfoDto>>(data);
            }
            return new ErrorDataResult<List<MeterWithCompleteInfoDto>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<Meter>> GetById(Guid meterId)
        {
            var response = await _httpClient.GetAsync($"getMeterById?id={meterId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Meter>(jsonBody);
                return new SuccessDataResult<Meter>(data);
            }
            return new ErrorDataResult<Meter>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<Meter>> GetBySerialNo(int serialNo)
        {
            var response = await _httpClient.GetAsync($"getMeterBySerialNo?serialNo={serialNo}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Meter>(jsonBody);
                return new SuccessDataResult<Meter>(data);
            }
            return new ErrorDataResult<Meter>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<MeterWithCompleteInfoDto>> GetWithCompleteInfoById(Guid meterId)
        {
            var response = await _httpClient.GetAsync($"getMeterWithCompleteInfoById?id={meterId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MeterWithCompleteInfoDto>(jsonBody);
                return new SuccessDataResult<MeterWithCompleteInfoDto>(data);
            }
            return new ErrorDataResult<MeterWithCompleteInfoDto>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<MeterWithCompleteInfoDto>> GetWithCompleteInfoBySerialNo(int serialNo)
        {
            var response = await _httpClient.GetAsync($"getMeterWithCompleteInfoBySerialNo?serialNo={serialNo}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MeterWithCompleteInfoDto>(jsonBody);
                return new SuccessDataResult<MeterWithCompleteInfoDto>(data);
            }
            return new ErrorDataResult<MeterWithCompleteInfoDto>();
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Update(Meter meter)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meter);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PatchAsync("updateMeter", data);
        }


    }
}
