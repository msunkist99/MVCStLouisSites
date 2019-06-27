using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class ParkingSiteAttraction
    {
        public int Id { get; set; }

        public int ParkingSiteId { get; set; }
        public int AttractionId { get; set; }

        public virtual ParkingSite ParkingSite { get; set; }
        public virtual Attraction Attraction { get; set; }
    }
}
