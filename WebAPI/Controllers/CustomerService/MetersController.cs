using Business.Abstract.CustomerApi;
using Entities.Models.CustomerApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.CustomerService
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        ICustomerApiService _customerApiService;
        public CustomersController(ICustomerApiService customerApiService)
        {
            _customerApiService = customerApiService;
        }
        [HttpDelete("customerDelete")]
        public async Task<IActionResult> customerDelete(Customer customer)
        {
            var result = await _customerApiService.Delete(customer);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPatch("customerUpdate")]
        public async Task<IActionResult> customerUpdate(Customer customer)
        {
            var result = await _customerApiService.Update(customer);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }
        [HttpPost("customerAdd")]
        public async Task<IActionResult> customerAdd(Customer customer)
        {
            var result = await _customerApiService.Add(customer);
            if (result.IsSuccessStatusCode)
                return Ok();
            return BadRequest();
        }


        [HttpGet("customerGetById")]
        public async Task<IActionResult> customerGetById(Guid id)
        {
            var result = await _customerApiService.GetById(id);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("customerGetByMeterSerialNo")]
        public async Task<IActionResult> customerGetByMeterSerialNo(int serialNo)
        {
            var result = await _customerApiService.GetByMeterSerialNo(serialNo);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("customerGetAll")]
        public async Task<IActionResult> customerGetAll()
        {
            var result = await _customerApiService.GetAll();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }


    }
}
