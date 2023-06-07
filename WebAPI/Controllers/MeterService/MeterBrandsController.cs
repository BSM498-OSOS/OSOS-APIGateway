using Business.Abstract.MeterApi;
using Entities.Models.MeterApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.MeterService
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeterBrandsController : ControllerBase
    {
        IMeterBrandApiService _meterBrandApiService;
        public MeterBrandsController(IMeterBrandApiService meterBrandApiService)
        {
            _meterBrandApiService = meterBrandApiService;
        }
        [HttpDelete("meterBrandDelete")]
        public async Task<IActionResult> meterBrandDelete(MeterBrand meterBrand)
        {
            var result = await _meterBrandApiService.Delete(meterBrand);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPatch("meterBrandUpdate")]
        public async Task<IActionResult> meterBrandUpdate(MeterBrand meterBrand)
        {
            var result = await _meterBrandApiService.Update(meterBrand);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPost("meterBrandAdd")]
        public async Task<IActionResult> meterBrandAdd(MeterBrand meterBrand)
        {
            var result = await _meterBrandApiService.Add(meterBrand);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }


        [HttpGet("meterBrandGetById")]
        public async Task<IActionResult> meterBrandGetById(Guid id)
        {
            var result = await _meterBrandApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("meterBrandGetAll")]
        public async Task<IActionResult> meterBrandGetAll()
        {
            var result = await _meterBrandApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
