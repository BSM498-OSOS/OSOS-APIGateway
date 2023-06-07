using Business.Abstract.AuthApi;
using Business.Consts;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.AuthApi
{
    public class AuthOperationClaimApiManager:IAuthOperationClaimApiService
    {
        HttpClient _httpClient;
        public AuthOperationClaimApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.AuthOperationClaimsApiUrl;
        }

        public async Task<IDataResult<List<OperationClaim>>> GetAll()
        {
            
            var response = await _httpClient.GetAsync("getAllOperationClaims");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OperationClaim>>(jsonBody);
                return new SuccessDataResult<List<OperationClaim>>(data);
            }
            return new ErrorDataResult<List<OperationClaim>>();
        }
    }
}
