using Business.Abstract.ModemApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Utilities.Results;
using Entities.Concrete.Models.ModemApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ModemApi
{
    public class ModemModelApiManager : IModemModelApiService
    {
        HttpClient _httpClient;
        public ModemModelApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.ModemModelApiUrl;
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(ModemModel modemModel)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modemModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addModel", data);
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(ModemModel modemModel)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modemModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteModel"), Content = data, Method = HttpMethod.Delete });
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<ModemModel>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllModels");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ModemModel>>(jsonBody);
                return new SuccessDataResult<List<ModemModel>>(data);
            }
            return new ErrorDataResult<List<ModemModel>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<ModemModel>> GetById(Guid modemModelId)
        {
            var response = await _httpClient.GetAsync($"getModelById?id={modemModelId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ModemModel>(jsonBody);
                return new SuccessDataResult<ModemModel>(data);
            }
            return new ErrorDataResult<ModemModel>();
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Update(ModemModel modemModel)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modemModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PatchAsync("updateModel", data);
        }
    }
}

