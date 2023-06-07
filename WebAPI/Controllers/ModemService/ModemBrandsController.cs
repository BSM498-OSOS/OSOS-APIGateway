using Business.Abstract.ModemApi;
using Entities.Concrete.Models.ModemApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ModemService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModemBrandsController : ControllerBase
    {
        IModemBrandApiService _modemBrandApiService;
        public ModemBrandsController(IModemBrandApiService modemBrandApiService)
        {
            _modemBrandApiService = modemBrandApiService;
        }
        [HttpDelete("modemBrandDelete")]
        public async Task<IActionResult> modemBrandDelete(ModemBrand modemBrand)
        {
            var result = await _modemBrandApiService.Delete(modemBrand);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPatch("modemBrandUpdate")]
        public async Task<IActionResult> modemBrandUpdate(ModemBrand modemBrand)
        {
            var result = await _modemBrandApiService.Update(modemBrand);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPost("modemBrandAdd")]
        public async Task<IActionResult> modemBrandAdd(ModemBrand modemBrand)
        {
            var result = await _modemBrandApiService.Add(modemBrand);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }


        [HttpGet("modemBrandGetById")]
        public async Task<IActionResult> modemBrandGetById(Guid id)
        {
            var result = await _modemBrandApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("modemBrandGetAll")]
        public async Task<IActionResult> modemBrandGetAll()
        {
            var result = await _modemBrandApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
