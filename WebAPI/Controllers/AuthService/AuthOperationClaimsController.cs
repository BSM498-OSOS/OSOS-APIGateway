using Business.Abstract.AuthApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.AuthService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthOperationClaimsController : ControllerBase
    {
        IAuthOperationClaimApiService _authOperationClaimApiService;
        public AuthOperationClaimsController(IAuthOperationClaimApiService authOperationClaimApiService)
        {
            _authOperationClaimApiService = authOperationClaimApiService;
        }

        [HttpGet("authOpearationClaimGetAll")]
        public async Task<IActionResult> authOpearationClaimGetAll()
        {
            var result = await _authOperationClaimApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
