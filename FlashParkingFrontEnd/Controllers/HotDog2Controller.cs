using Microsoft.AspNetCore.Mvc;

namespace FlashParking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotDog2Controller : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<HotDog2Controller> _logger;

        public HotDog2Controller(ILogger<HotDog2Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = "Hot dogs"
            })
            .ToArray();
        }


    }
}