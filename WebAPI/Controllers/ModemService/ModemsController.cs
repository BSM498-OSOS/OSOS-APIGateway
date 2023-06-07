using Business.Abstract.ModemApi;
using Entities.Concrete.Models.ModemApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ModemService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModemsController : ControllerBase
    {
        IModemApiService _modemApiService;
        public ModemsController(IModemApiService modemApiService)
        {
            _modemApiService = modemApiService;
        }
        [HttpDelete("modemDelete")]
        public async Task<IActionResult> modemDelete(Modem modem)
        {
            var result = await _modemApiService.Delete(modem);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPatch("modemUpdate")]
        public async Task<IActionResult> modemUpdate(Modem modem)
        {
            var result = await _modemApiService.Update(modem);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPost("modemAdd")]
        public async Task<IActionResult> modemAdd(Modem modem)
        {
            var result = await _modemApiService.Add(modem);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }


        [HttpGet("modemGetById")]
        public async Task<IActionResult> modemGetById(Guid id)
        {
            var result = await _modemApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("modemGetAll")]
        public async Task<IActionResult> modemGetAll()
        {
            var result = await _modemApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("modemGetWithCompleteInfoById")]
        public async Task<IActionResult> modemGetWithCompleteInfoById(Guid modemId)
        {
            var result = await _modemApiService.GetWithCompleteInfoById(modemId);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("modemGetAllWithCompleteInfo")]
        public async Task<IActionResult> modemGetAllWithCompleteInfo()
        {
            var result = await _modemApiService.GetAllWithCompleteInfo();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

    }
}
