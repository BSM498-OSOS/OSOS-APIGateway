using Business.Abstract.MeterApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Utilities.Results;
using Entities.Models.MeterApi;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.MeterApi
{
    public class MeterBrandApiManager : IMeterBrandApiService
    {
        HttpClient _httpClient;
        public MeterBrandApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.MeterBrandApiUrl;
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(MeterBrand meterBrand)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meterBrand);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addBrand", data);
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(MeterBrand meterBrand)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meterBrand);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteBrand"), Content = data, Method = HttpMethod.Delete });
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<MeterBrand>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllBrands");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<MeterBrand>>(jsonBody);
                return new SuccessDataResult<List<MeterBrand>>(data);
            }
            return new ErrorDataResult<List<MeterBrand>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<MeterBrand>> GetById(Guid meterBrandId)
        {
            var response = await _httpClient.GetAsync($"getBrandById?id={meterBrandId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MeterBrand>(jsonBody);
                return new SuccessDataResult<MeterBrand>(data);
            }
            return new ErrorDataResult<MeterBrand>();
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Update(MeterBrand meterBrand)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(meterBrand);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PatchAsync("updateBrand", data);
        }
    }
}
