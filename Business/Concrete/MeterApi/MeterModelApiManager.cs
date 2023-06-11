using Business.Abstract.MeterApi;
using Business.BusinessAspects.Autofac;
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
    public class MeterModelApiManager : IMeterModelApiService
    {
        HttpClient _httpClient;
        public MeterModelApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.MeterModelApiUrl;
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(MeterModel meterModel)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meterModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addModel", data);
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(MeterModel meterModel)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meterModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteModel"), Content = data, Method = HttpMethod.Delete });
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<MeterModel>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllModels");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MeterModel>>(jsonBody);
                return new SuccessDataResult<List<MeterModel>>(data);
            }
            return new ErrorDataResult<List<MeterModel>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<MeterModel>> GetById(Guid meterModelId)
        {
            var response = await _httpClient.GetAsync($"getModelById?id={meterModelId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MeterModel>(jsonBody);
                return new SuccessDataResult<MeterModel>(data);
            }
            return new ErrorDataResult<MeterModel>();
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Update(MeterModel meterModel)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meterModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PatchAsync("updateModel", data);
        }
    }
}

