using Microsoft.AspNetCore.Mvc;
using System;

namespace homework.Controllers
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

        [HttpGet(Name = "GetWeatherForecast/{number}")]
        public IEnumerable<WeatherForecast> Get(int number)
        {
            return _weatherService.Get(number);
        }
    }


}
