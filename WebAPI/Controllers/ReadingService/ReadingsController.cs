using Business.Abstract.ReadingApi;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.ReadingService
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingsController : ControllerBase
    {
        IReadingApiService  _readingApiService;
        public ReadingsController(IReadingApiService readingApiService)
        {
             _readingApiService = readingApiService;
        }

        [HttpGet("readingGetBySerialNo")]
        public async Task<IActionResult> readingGetBySerialNo(int serialNo)
        {
            var result = await _readingApiService.GetBySerialNo(serialNo);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpGet("readingGetAll")]
        public async Task<IActionResult> getAllReadings()
        {
            var result = await _readingApiService.GetAll();
            if (result.Success)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpGet("readingGetAllbyDates")]
        public async Task<IActionResult> readingGetAllbyDates(DateTime minDate, DateTime maxDate)
        {
            var result = await _readingApiService.GetByDates(minDate, maxDate);
            if (result.Success)
                return Ok(result);
            else
                return BadRequest();
        }


        [HttpGet("readingGetAllTotalConsumptions")]
        public async Task<IActionResult> readingGetAllTotalConsumptions()
        {
            var result = await _readingApiService.GetAllConsumptions();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpGet("readingGetAllTotalConsumptionDaily")]
        public async Task<IActionResult> readingGetAllTotalConsumptionDaily()
        {
            var result = await _readingApiService.GetAllConsumptionsDaily();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpGet("readingGetAllTotalConsumptionMonthly")]
        public async Task<IActionResult> readingGetAllTotalConsumptionMonthly()
        {
            var result = await _readingApiService.GetAllConsumptionsMontly();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpGet("readingGetAllTotalConsumptionYearly")]
        public async Task<IActionResult> readingGetAllTotalConsumptionYearly()
        {
            var result = await _readingApiService.GetAllConsumptionsYearly();
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }


        [HttpGet("readingGetTotalConsumptionDailyBySerialNo")]
        public async Task<IActionResult> readingGetTotalConsumptionDailyBySerialNo(int serialNo)
        {
            var result = await _readingApiService.GetConsumptionsDailyBySerialNo(serialNo);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("readingGetTotalConsumptionMonthlyBySerialNo")]
        public async Task<IActionResult> readingGetTotalConsumptionMonthlyBySerialNo(int serialNo)
        {
            var result = await _readingApiService.GetConsumptionsMontlyBySerialNo(serialNo);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }

        [HttpGet("readingGetTotalConsumptionYearlyBySerialNo")]
        public async Task<IActionResult> readingGetTotalConsumptionYearlyBySerialNo(int serialNo)
        {
            var result = await _readingApiService.GetConsumptionsYearlyBySerialNo(serialNo);
            if (result.Success)
                return Ok(result);
            return BadRequest();
        }
    }
}
