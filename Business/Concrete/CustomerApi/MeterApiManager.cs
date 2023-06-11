using Business.Abstract;
using Business.Abstract.CustomerApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs.AuthApiDTOs;
using Entities.Models.CustomerApi;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Customer = Entities.Models.CustomerApi.Customer;

namespace Business.Concrete.CustomerApi
{
    public class CustomerApiManager : ICustomerApiService
    {
        HttpClient _httpClient;
        public CustomerApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.CustomerApiUrl;
        }
        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(Customer customer)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addCustomer", data);
        }


        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(Customer customer)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteCustomer"), Content = data, Method = HttpMethod.Delete });
        }

        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<Customer>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllCustomers");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Customer>>(jsonBody);
                return new SuccessDataResult<List<Customer>>(data);
            }
            return new ErrorDataResult<List<Customer>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<Customer>> GetById(Guid customerId)
        {
            var response = await _httpClient.GetAsync($"getCustomerById?id={customerId}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(jsonBody);
                return new SuccessDataResult<Customer>(data);
            }
            return new ErrorDataResult<Customer>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<Customer>> GetByMeterSerialNo(int serialNo)
        {
            var response = await _httpClient.GetAsync($"getCustomerByMeterId?meterId={serialNo}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<Customer>(jsonBody);
                return new SuccessDataResult<Customer>(data);
            }
            return new ErrorDataResult<Customer>();
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Update(Customer customer)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(customer);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PatchAsync("updateCustomer", data);
        }


    }
}
