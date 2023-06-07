using Business.Abstract.MeterApi;
using Entities.Models.MeterApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.MeterService
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterModelsController : ControllerBase
    {
        IMeterModelApiService _meterModelApiService;
        public MeterModelsController(IMeterModelApiService meterModelApiService)
        {
            _meterModelApiService = meterModelApiService;
        }
        [HttpDelete("meterModelDelete")]
        public async Task<IActionResult> meterModelDelete(MeterModel meterModel)
        {
            var result = await _meterModelApiService.Delete(meterModel);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPatch("meterModelUpdate")]
        public async Task<IActionResult> meterModelUpdate(MeterModel meterModel)
        {
            var result = await _meterModelApiService.Update(meterModel);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPost("meterModelAdd")]
        public async Task<IActionResult> meterModelAdd(MeterModel meterModel)
        {
            var result = await _meterModelApiService.Add(meterModel);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }


        [HttpGet("meterModelGetById")]
        public async Task<IActionResult> meterModelGetById(Guid id)
        {
            var result = await _meterModelApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterModelGetAll")]
        public async Task<IActionResult> meterModelGetAll()
        {
            var result = await _meterModelApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
