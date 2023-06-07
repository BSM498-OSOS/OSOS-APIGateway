using Business.Abstract.AuthApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.AuthApi
{
    public class AuthUserOperationClaimsApiManager : IAuthUserOperationClaimsApiService
    {
        HttpClient _httpClient;
        public AuthUserOperationClaimsApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.AuthUserOperationClaimsApiUrl;
        }

        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Add(UserOperationClaim claim)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(claim);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.PostAsync("addUserOperationClaim", data);
        }
        [SecuredOperation("Admin")]
        public Task<HttpResponseMessage> Delete(UserOperationClaim claim)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(claim);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return _httpClient.SendAsync(new HttpRequestMessage { RequestUri = new Uri(_httpClient.BaseAddress.ToString() + "deleteUserOperationClaim"), Content = data, Method = HttpMethod.Delete });
        }
    }
}
