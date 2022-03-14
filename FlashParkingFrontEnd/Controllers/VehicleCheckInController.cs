using DataLayer;
using DataLayer.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlashParking.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleCheckInController : ControllerBase
    {
        private readonly ILogger<VehicleCheckInController> _logger;
        private readonly ParkingGarageContext _parkingGarageContext;
        public VehicleCheckInController(ILogger<VehicleCheckInController> logger, ParkingGarageContext db)
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
                        });
                    }
                }
            }

            return checkInRows;
        }

        [HttpPost]
        public void Post(CheckInVehicleModel row)
        {
            var space = _parkingGarageContext.parking_space.Include(x => x.vehicle).FirstOrDefault(x=>x.id == row.SpaceId);

            if (space == null)
            {
                throw new Exception("Not Found"); // find a more appropiate exception later, probably a predefined 404 of some type
            }

            _parkingGarageContext.Update(space);

            if (row.VehicleId == null)
            {
                //fabricate a car and check it in.
                space.vehicle = new Vehicle()
                {
                    color = "Hot Pink",
                    id = Guid.NewGuid(),
                    vin = "Uncle Vinny"
                };
                _parkingGarageContext.vehicle.Add(space.vehicle);
            }
            else
            {
                //check out
                space.vehicle = null;
                //Delete orphaned vehicle row, or possibly leave it for tracking/history purposes.
            }

            _parkingGarageContext.SaveChanges();
        }
    }
}
