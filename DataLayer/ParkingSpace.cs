using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class ParkingSpace
    {
        public Guid id { get; set; }
        public string? logicalid { get; set; } //A human readable label for this spot, such as A-2 or B53

        public virtual LocationSection? section { get; set; }
        public virtual Vehicle? vehicle { get; set; }

    }
}
