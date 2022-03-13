using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LocationSection
    {
        public Guid ID { get; set; }
        public string? Name { get; set; } //A human readable label for this section, such as floor 2 or east lot

        public virtual Location? Location { get; set; }
        
        //public virtual List<ParkingSpace>? ParkingSpaces { get; set; }
    }
}
