using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class Attraction : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string Name { get; set; }
        public string Description { get; set; }
        public int BackgroundImageId { get; set; }
        public int IconImageId { get; set; }

        public List<int> LocationIds { get; set; }
        public List<int> RatingIds { get; set; }
        public List<int> AttractionActivityIds { get; set; }
        public List<int> UserPrivilegeIds { get; set; }
        public List<int> AttractionTypeIds { get; set; }
        public List<int> ContactIds { get; set; }
        public List<int> GeneralInfoIds { get; set; }
        public List<int> HoursOfOperationIds { get; set; }  // maybe keep this in the Attraction class
        public List<int> CalendarOfEventIds { get; set; }
        public List<int> ParkingIds { get; set; }
    }
}
