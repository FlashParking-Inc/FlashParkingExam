using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Location
    {
        public Guid ID { get; set; }
        public string? Name { get; set; } //A human readable label for this location such as "Stadium Parking" or "Office Parking Garage"

        public virtual List<LocationSection>? ParkingSpaces { get; set; }
    }
}
