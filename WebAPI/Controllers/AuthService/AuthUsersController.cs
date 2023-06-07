using Business.Abstract.AuthApi;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.AuthService
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthUsersController : ControllerBase
    {
        IAuthUserApiService _authUserService;
        public AuthUsersController(IAuthUserApiService authUserService)
        {
            _authUserService = authUserService;
        }

        [HttpGet("authUserGetAll")]
        public async Task<IActionResult> authUserGetAll()
        {
            var result = await _authUserService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("authUserGetById")]
        public async Task<IActionResult> authUserGetById(Guid id)
        {
            var result = await _authUserService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
