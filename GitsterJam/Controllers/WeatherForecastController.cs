using GitsterJam.Services;
using Microsoft.AspNetCore.Mvc;

namespace GitsterJam.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
        {
            return Ok(await _weatherService.GetForecast());
        }
    }
}