using Business.Abstract.ModemApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Utilities.Results;
using Entities.Concrete.Models.ModemApi;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.ModemApi
{
    public class ModemBrandApiManager : IModemBrandApiService
    {
        HttpClient _httpClient;
        public ModemBrandApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.ModemBrandApiUrl;
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(ModemBrand modemBrand)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modemBrand);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addBrand", data);
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(ModemBrand modemBrand)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modemBrand);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteBrand"), Content = data, Method = HttpMethod.Delete });
        }

        public async Task<IDataResult<List<ModemBrand>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllBrands");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ModemBrand>>(jsonBody);
                return new SuccessDataResult<List<ModemBrand>>(data);
            }
            return new ErrorDataResult<List<ModemBrand>>();
        }

        public async Task<IDataResult<ModemBrand>> GetById(Guid modemBrandId)
        {
            var response = await _httpClient.GetAsync($"getBrandById?id={modemBrandId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<ModemBrand>(jsonBody);
                return new SuccessDataResult<ModemBrand>(data);
            }
            return new ErrorDataResult<ModemBrand>();
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Update(ModemBrand modemBrand)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(modemBrand);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PatchAsync("updateBrand", data);
        }
    }
}
