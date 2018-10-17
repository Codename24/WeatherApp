using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Weather_App.Interfaces;

namespace Weather_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet("[action]/{city}")]
        public async Task<ActionResult> Current(string city)
        {
            var result = await _weatherService.LoadCurrentWeatherDataForCity(city);
            return Ok(result);
        }

        [HttpGet("[action]/{city}")]
        public async Task<ActionResult> Forecast(string city)
        {
            var result = await _weatherService.LoadForecastedWeatherDataForCity(city);
            return Ok(result);
        }
    }
}