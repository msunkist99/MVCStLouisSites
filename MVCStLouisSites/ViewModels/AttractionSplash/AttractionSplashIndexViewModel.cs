using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.DisplayAttractions
{
    public class AttractionSplashIndexViewModel
    {
        public int Id { set; get; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string BackgroundImage { get; set; }
        public string IconImage { get; set; }

        public List<Location> Locations { get; set; }  // should these be ViewModels instead of the Models?
        public List<Rating> Ratings { get; set; }
        public List<AttractionActivity> AttractionActivitys { get; set; }
        public List<UserPrivilege> UserPrivileges { get; set; }
        public List<AttractionType> AttractionTypes { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<GeneralInformation> GeneralInfos { get; set; }
        public List<HoursOfOperation> HoursOfOperations { get; set; }  // maybe keep this in the Attraction class
        public List<CalenderOfEvent> CalendarOfEvents { get; set; }
        public List<Parking> Parkings { get; set; }
    }
}
