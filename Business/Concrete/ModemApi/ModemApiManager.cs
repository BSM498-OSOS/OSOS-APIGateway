using Business.Abstract;
using Business.Abstract.ModemApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.Concrete.DTOs.ModemApiDTOs;
using Entities.Concrete.Models.ModemApi;
using Entities.DTOs.AuthApiDTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ModemApi
{
    public class ModemApiManager : IModemApiService
    {
        HttpClient _httpClient;
        public ModemApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.ModemApiUrl;
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(Modem modem)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modem);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addModem", data);
        }


        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(Modem modem)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modem);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteModem"), Content = data, Method = HttpMethod.Delete });
        }


        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<Modem>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllModems");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Modem>>(jsonBody);
                return new SuccessDataResult<List<Modem>>(data);
            }
            return new ErrorDataResult<List<Modem>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ModemWithCompleteInfoDto>>> GetAllWithCompleteInfo()
        {
            var response = await _httpClient.GetAsync("getAllModemsWithCompleteInfo");

            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ModemWithCompleteInfoDto>>(jsonBody);
                return new SuccessDataResult<List<ModemWithCompleteInfoDto>>(data);
            }
            return new ErrorDataResult<List<ModemWithCompleteInfoDto>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<Modem>> GetById(Guid modemId)
        {
            var response = await _httpClient.GetAsync($"getModemById?id={modemId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Modem>(jsonBody);
                return new SuccessDataResult<Modem>(data);
            }
            return new ErrorDataResult<Modem>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<ModemWithCompleteInfoDto>> GetWithCompleteInfoById(Guid modemId)
        {
            var response = await _httpClient.GetAsync($"getModemWithCompleteInfoById?id={modemId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ModemWithCompleteInfoDto>(jsonBody);
                return new SuccessDataResult<ModemWithCompleteInfoDto>(data);
            }
            return new ErrorDataResult<ModemWithCompleteInfoDto>();
        }


        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Update(Modem modem)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modem);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PatchAsync("updateModem", data);
        }


    }
}
