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
        // navigation property
        public BackgroundImage BackgroundImage { get; set; }
        public string BackgroundImageFileName { get; set; }

        public int IconImageId { get; set; }
        // navigation property
        public IconImage IconImage { get; set; }
        public string IconImageFileName { get; set; }

        // navigation property - one attraction-to-many
        public IList<Location> Locations { get; set; }

        // navigation property - one attraction-to-many
        public IList<Rating> Ratings { get; set; }

        // navigation property - many attraction features to-many attractions
        public IList<AttractionAttractionFeatureJoin> AttractionAttractionFeatureJoins { get; set; }

        // navigation property - many parking sites to-many attractions
        public IList<AttractionParkingSiteJoin> AttractionParkingSiteJoins { get; set; }

        // navigation property - attraction features
        //public IList<AttractionFeature> AttractionFeatures { get; set; }

        // navigation property - parking sites
        //public IList<ParkingSite> ParkingSites { get; set; }

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
