using Business.Abstract.MeterApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.MeterService
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterReadingTimesController : ControllerBase
    {
        IMeterReadingTimeApiService _meterReadingTimeApiService;
        public MeterReadingTimesController(IMeterReadingTimeApiService meterReadingTimeApiService)
        {
            _meterReadingTimeApiService = meterReadingTimeApiService;
        }
        [HttpGet("meterReadingTimeGetAll")]
        public async Task<IActionResult> meterReadingTimeGetAll() 
        { 
            var result = await _meterReadingTimeApiService.GetAll();
            if(result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterReadingTimeGetById")]
        public async Task<IActionResult> meterReadingTimeGetAll(Guid id)
        {
            var result = await _meterReadingTimeApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
