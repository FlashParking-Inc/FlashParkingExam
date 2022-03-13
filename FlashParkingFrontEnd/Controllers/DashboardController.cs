using DataLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashParking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ParkingGarageContext _parkingGarageContext;
        public DashboardController(ILogger<DashboardController> logger, ParkingGarageContext db)
        {
            _logger = logger;
            _parkingGarageContext = db;
        }

        [HttpGet]
        public IEnumerable<LocationOverviewModel> Get()
        { 
            return _parkingGarageContext.location.Include(x => x.section).ThenInclude(x => x.parking_space).ThenInclude(x => x.vehicle)
                .Select(x => new LocationOverviewModel()
                {
                    LocationId = x.id,
                    Name = x.name,
                    FilledSpots = x.section.SelectMany(x => x.parking_space).Count(x => x.vehicle != null),
                    OpenSpots = x.section.SelectMany(x => x.parking_space).Count(y => y.vehicle == null),
                    TotalSpots = x.section.SelectMany(x => x.parking_space).Count(),
                });
        }
    }
}
