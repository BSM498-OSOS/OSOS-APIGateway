using Business.Abstract.AuthApi;
using Business.BusinessAspects.Autofac;
using Business.Consts;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs.AuthApiDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete.AuthApi
{
    public class AuthApiManager : IAuthApiService
    {
        private HttpClient _httpClient;
        private ITokenHelper _tokenHelper;

        public AuthApiManager(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient();
            _httpClient.BaseAddress = UrlService.AuthApiUrl;
        }

        public async Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(userForLoginDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("login", data);
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var token = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessToken>(jsonBody);
                return new SuccessDataResult<AccessToken>(token);
            }
            return new ErrorDataResult<AccessToken>("Some Problem");
        }

        public async Task<IDataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto)
        {
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(userForRegisterDto);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("register", data);
            if (response.IsSuccessStatusCode)
            {
                string jsonBody = await response.Content.ReadAsStringAsync();
                var token = Newtonsoft.Json.JsonConvert.DeserializeObject<AccessToken>(jsonBody);
                return new SuccessDataResult<AccessToken>(token);
            }

            return new ErrorDataResult<AccessToken>("Some Problem");
        }
    }
}
