using DataLayer.DAL;
using Microsoft.AspNetCore.Mvc;

namespace FlashParking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HotDogController : ControllerBase
    {
        private readonly ILogger<HotDogController> _logger;
        private readonly ParkingGarageContext _parkingGarageContext;
        public HotDogController(ILogger<HotDogController> logger, ParkingGarageContext db)
        {
            _logger = logger;
            _parkingGarageContext = db;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return new List<WeatherForecast>()
            { 
                new WeatherForecast() { Date = DateTime.Now, Summary = $"Raining hot dogs {_parkingGarageContext.locationsection.First().location.name}", TemperatureC = 22 },
            }.ToArray();
        }
    }
}
