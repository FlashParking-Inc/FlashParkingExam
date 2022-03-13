using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class LocationSection
    {
        public Guid id { get; set; }
        public string? name { get; set; } //A human readable label for this section, such as floor 2 or east lot

        public virtual Location? location { get; set; }
        
        public virtual List<ParkingSpace>? parking_space { get; set; }
    }
}
