using Business.Abstract.ModemApi;
using Entities.Concrete.Models.ModemApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ModemService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModemModelsController : ControllerBase
    {
        IModemModelApiService _modemModelApiService;
        public ModemModelsController(IModemModelApiService modemModelApiService)
        {
            _modemModelApiService = modemModelApiService;
        }
        [HttpDelete("modemModelDelete")]
        public async Task<IActionResult> modemModelDelete(ModemModel modemModel)
        {
            var result = await _modemModelApiService.Delete(modemModel);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPatch("modemModelUpdate")]
        public async Task<IActionResult> modemModelUpdate(ModemModel modemModel)
        {
            var result = await _modemModelApiService.Update(modemModel);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPost("modemModelAdd")]
        public async Task<IActionResult> modemModelAdd(ModemModel modemModel)
        {
            var result = await _modemModelApiService.Add(modemModel);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }


        [HttpGet("modemModelGetById")]
        public async Task<IActionResult> modemModelGetById(Guid id)
        {
            var result = await _modemModelApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("modemModelGetAll")]
        public async Task<IActionResult> modemModelGetAll()
        {
            var result = await _modemModelApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
