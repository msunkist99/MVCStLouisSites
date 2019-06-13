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


        // navigation property - one attraction-to-many
        public IList<Location> Locations { get; set; }


        // navigation property - one attraction-to-many
        public IList<Rating> Ratings { get; set; }

        /*
// navigation property - one attraction-to-many
public IList<Activity> Activities { get; set; }

// navigation property - one attraction-to-many
public IList<UserPrivilege> UserPrivileges { get; set; }

// navigation property - many attractions to-many parking types
//public IList<AttractionToParkingType> AttractionsToParkingTypes { get; set; }
public IList<ParkingType> ParkingTypes { get; set; }

// navigation property - many attractsion to-many attraction types
//public IList<AttractionToAttractionType> AttractionToAttractionTypes { get; set; }
public IList<AttractionType> AttractionTypes { get; set; }

// navigation property - one attraction-to-many
public IList<Contact> Contacts { get; set; }

// navigation property - one attraction-to-many
public IList<GeneralInformation> GeneralInformations { get; set; }

// navigation property - one attraction-to-many
public IList<HoursOfOperation> HoursOfOperations { get; set; }  // maybe keep this in the Attraction class

// navigation property - one attraction-to-many
public IList<CalenderOfEvent> CalendarOfEvents { get; set; }

// navigation property - one attraction-to-many
public IList<Neighborhood> Neighborhoods { get; set; }
*/
    }
}
