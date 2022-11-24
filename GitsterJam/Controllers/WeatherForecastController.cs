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
            return Ok(await _weatherService.GetForecast(5));
        }

        [HttpGet]
        [Route("magic")]
        public async Task<ActionResult<string>> GetMagic()
        {
            return Ok(await _weatherService.GetMagic());
        }

        [HttpGet]
        [Route("demo")]
        public async Task<ActionResult<string>> GetDemo()
        {
            return Ok("Live coding is so easy");
        }
    }
}