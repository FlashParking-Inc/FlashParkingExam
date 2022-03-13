using DataLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashParking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleCheckInController : ControllerBase
    {
        private readonly ILogger<DashboardController> _logger;
        private readonly ParkingGarageContext _parkingGarageContext;
        public VehicleCheckInController(ILogger<DashboardController> logger, ParkingGarageContext db)
        {
            _logger = logger;
            _parkingGarageContext = db;
        }

        [HttpGet]
        public IEnumerable<CheckInVehicleModel> Get()
        {
            var checkInRows = new List<CheckInVehicleModel>();
            var locations = _parkingGarageContext.location.Include(x => x.section).ThenInclude(x => x.parking_space).ThenInclude(x => x.vehicle);
            
            foreach(var location in locations)
            {
                foreach(var section in location.section)
                {
                    foreach( var space in section.parking_space)
                    {
                        checkInRows.Add(new CheckInVehicleModel()
                        {
                            GarageName = location.name,
                            SectionName = section.name,
                            SpaceId = space.id,
                            SpaceName = space.logicalid,
                            VehicleId = space.vehicle?.id,
                            VehicleVin = space.vehicle?.vin
                        });
                    }
                }
            }

            return checkInRows;
        }
    }
}
