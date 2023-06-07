using Business.Abstract.MeterApi;
using Entities.Models.MeterApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.MeterService
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetersController : ControllerBase
    {
        IMeterApiService _meterApiService;
        public MetersController(IMeterApiService meterApiService)
        {
            _meterApiService = meterApiService;
        }
        [HttpDelete("meterDelete")]
        public async Task<IActionResult> meterDelete(Meter meter)
        {
            var result = await _meterApiService.Delete(meter);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPatch("meterUpdate")]
        public async Task<IActionResult> meterUpdate(Meter meter)
        {
            var result = await _meterApiService.Update(meter);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPost("meterAdd")]
        public async Task<IActionResult> meterAdd(Meter meter)
        {
            var result = await _meterApiService.Add(meter);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }


        [HttpGet("meterGetById")]
        public async Task<IActionResult> meterGetById(Guid id)
        {
            var result = await _meterApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterGetBySerialNo")]
        public async Task<IActionResult> meterGetBySerialNo(int serialNo)
        {
            var result = await _meterApiService.GetBySerialNo(serialNo);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterGetAll")]
        public async Task<IActionResult> meterGetAll()
        {
            var result = await _meterApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterGetWithCompleteInfoById")]
        public async Task<IActionResult> meterGetWithCompleteInfoById(Guid meterId)
        {
            var result = await _meterApiService.GetWithCompleteInfoById(meterId);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterGetWithCompleteInfoBySerialNo")]
        public async Task<IActionResult> meterGetWithCompleteInfoBySerialNo(int serialNo)
        {
            var result = await _meterApiService.GetWithCompleteInfoBySerialNo(serialNo);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterGetAllWithCompleteInfo")]
        public async Task<IActionResult> meterGetAllWithCompleteInfo()
        {
            var result = await _meterApiService.GetAllWithCompleteInfo();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

    }
}
