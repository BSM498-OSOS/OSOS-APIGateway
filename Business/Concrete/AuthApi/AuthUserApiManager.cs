using Business.Abstract.AuthApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.AuthApi
{
    public class AuthUserApiManager:IAuthUserApiService
    {
        HttpClient _httpClient;
        public AuthUserApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.AuthUserApiUrl;
        }

        [SecuredOperation("Admin")]
        public async Task<IDataResult<List<UserWithCompleteInfoDto>>> GetAll()
        {
            var response = await _httpClient.GetAsync("getAllUser");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserWithCompleteInfoDto>>(jsonBody);
                return new SuccessDataResult<List<UserWithCompleteInfoDto>>(data);
            }
            return new ErrorDataResult<List<UserWithCompleteInfoDto>>();
        }
        [SecuredOperation("Admin")]
        public async Task<IDataResult<UserWithCompleteInfoDto>> GetById(Guid id)
        {
            var response = await _httpClient.GetAsync($"getUserByID?id={id}");
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var data = Newtonsoft.Json.JsonConvert.DeserializeObject<UserWithCompleteInfoDto>(jsonBody);
                return new SuccessDataResult<UserWithCompleteInfoDto>(data);
            }
            return new ErrorDataResult<UserWithCompleteInfoDto>();
        }
    }
}
