using Business.Abstract.AuthApi;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.AuthService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUserOperationClaimsController : ControllerBase
    {
        IAuthUserOperationClaimsApiService _authUserOperationClaimsApiService;
        public AuthUserOperationClaimsController(IAuthUserOperationClaimsApiService authUserOperationClaimsApiService)
        {
            _authUserOperationClaimsApiService = authUserOperationClaimsApiService;
        }

        [HttpPost("authUserOperationClaimAdd")]
        public async Task<IActionResult> authUserOperationClaimAdd(UserOperationClaim claim)
        {
            var result=await _authUserOperationClaimsApiService.Add(claim);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("authUserOperationClaimDelete")]
        public async Task<IActionResult> authUserOperationClaimDelete(UserOperationClaim claim)
        {
            var result = await _authUserOperationClaimsApiService.Delete(claim);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
    }
}
