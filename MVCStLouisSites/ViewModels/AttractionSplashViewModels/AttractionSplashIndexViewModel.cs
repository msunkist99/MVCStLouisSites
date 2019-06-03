using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.AttractionSplashViewModels
{
    public class AttractionSplashIndexViewModel
    {
        public static List<AttractionSplashIndexViewModel> viewModels = new List<AttractionSplashIndexViewModel>();

        public static List<AttractionSplashIndexViewModel> GetAttractionSplashIndexViewModel()
        {
            // need logic here to retrieve the List<AttractionSplash> attractionSplashes from the database.
            //              return model.SingleOrDefault(d => d.Id == id);
            // this will be in the Data\BaseRepository accessed via RepositoryFactory.GetAttractionSplashRepository().GetById(id)
            // the AttractionSplashIndexViewModel would then be built from the data retrieved from the database.
            AttractionSplashIndexViewModel viewModel = new AttractionSplashIndexViewModel();

            if (viewModels.Count == 0)
            {
                List<Attraction> attractions = RepositoryFactory.GetAttractionRepository()
                                                                .GetModels()
                                                                .Cast<Attraction>()
                                                                .ToList();

                foreach (Attraction attraction in attractions)
                {
                    viewModel = new AttractionSplashIndexViewModel();

                    viewModel.Id = attraction.Id;
                    viewModel.Name = attraction.Name;
                    viewModel.Description = attraction.Description;
                    //model.BackgroundImage = attraction.BackgroundImageId;
                    //model.IconImage = attraction.IconImageId;

                    foreach (int locationId in attraction.LocationIds)
                    {
                        // the next line is to just build the location models list in GetLocationRepository
                        RepositoryFactory.GetLocationRepository().GetModels();
                        Location location = (Location)RepositoryFactory.GetLocationRepository().GetById(locationId);

                        if (viewModel.Locations == null)
                        {
                            viewModel.Locations = new List<Location>();
                        }
                        viewModel.Locations.Add(location);
                    }

                    foreach (int ratingId in attraction.RatingIds)
                    {
                        // the next line is to just build the location models list in GetLocationRepository
                        RepositoryFactory.GetRatingRepository().GetModels();
                        Rating rating = (Rating)RepositoryFactory.GetRatingRepository().GetById(ratingId);

                        if (viewModel.Ratings == null)
                        {
                            viewModel.Ratings = new List<Rating>();
                        }
                        viewModel.Ratings.Add(rating);
                    }

                    foreach (int activityId in attraction.ActivityIds)
                    {
                        // the next line is to just build the location models list in GetLocationRepository
                        RepositoryFactory.GetActivityRepository().GetModels();
                        Activity activity = (Activity)RepositoryFactory.GetActivityRepository().GetById(activityId);

                        if (viewModel.Activities == null)
                        {
                            viewModel.Activities = new List<Activity>();
                        }
                        viewModel.Activities.Add(activity);
                    }

                    foreach (int contactId in attraction.ContactIds)
                    {
                        // the next line is to just build the location models list in GetLocationRepository
                        RepositoryFactory.GetContactRepository().GetModels();
                        Contact contact = (Contact)RepositoryFactory.GetContactRepository().GetById(contactId);

                        if (viewModel.Contacts == null)
                        {
                            viewModel.Contacts = new List<Contact>();
                        }
                        viewModel.Contacts.Add(contact);
                    }

                    /*
                    model.Id = 1;
                    model.Name = "Saint Louis Zoo";
                    model.Description = "Recently voted Best Zoo and America’s Top Free Attraction, the Saint Louis Zoo is dedicated to connecting people to animals. Annually, approximately 3 million visitors get the opportunity to experience 17,000+ animals in the Zoo’s care; many of them are rare and endangered. The Zoo is renowned for its innovative approaches to animal management, wildlife conservation, research and education. And as a free zoo, visitors are encouraged to come back again…and again!";
                    model.BackgroundImage = null;
                    model.IconImage = null;

                    List<Location> locations = new List<Location>();    // this should be a LocationViewModel and not Location class
                    Location location = new Location();
                    location.StreetAddress = "One Government Drive";
                    location.City = "St. Louis";
                    location.State = "Missouri";
                    location.Zip = "63110";
                    location.County = " St. Louis City";
                    locations.Add(location);
                    model.Locations = locations;

                    List<Rating> ratings = new List<Rating>();
                    Rating rating = new Rating();
                    rating.Number = 5;        // consider making this STARS in the view model
                    rating.Comments = "The zoo is absolutely amazing and it's free!!!! It is very well laid out, the walking paths have some shade which is also nice and plenty of benches for a little rest between exhibits. It was quite warm the day we went and they had lots of places to buy refreshments. What a gem this gorgeous zoo is.";
                    ratings.Add(rating);

                    rating = new Rating();
                    rating.Number = 2;        // consider making this STARS in the view model
                    rating.Comments = "Zoo opened at 8:00, but animals weren’t out till after 9:00, even then not many were seen, dolphin show was wonderful, but after spending 6 hours there, I don’t feel we saw over 3-4 animals😩, very disappointed !";
                    ratings.Add(rating);

                    rating = new Rating();
                    rating.Number = 3;        // consider making this STARS in the view model
                    rating.Comments = "We went on a holiday weekend so it was probably more crowded that normal. It took me 30 minutes to find public parking on the street and walk back to the entrance. In late afternoon most of the animals we saw were waiting at their gates/doors to go inside for the night and I assume be fed. Starting around an hour before closing the animals begin to transition and it's disappointing to not see them.";
                    ratings.Add(rating);
                    model.Ratings = ratings;

                    List<AttractionActivity> attractionActivities = new List<AttractionActivity>();
                    AttractionActivity attractionActivity = new AttractionActivity();
                    attractionActivity.Name = "Rivers Edge";
                    attractionActivity.Description = "Take a journey along a mythical waterway through four continents to discover how wildlife, plants and people interact. River's Edge is the Saint Louis Zoo's first immersion exhibit—a lushly planted naturalistic environment showcasing multiple species from around the world. ";
                    attractionActivities.Add(attractionActivity);

                    attractionActivity = new AttractionActivity();
                    attractionActivity.Name = "The Wild";
                    attractionActivity.Description = "From the sub-Antarctic to tropical rainforests, animals have made some pretty amazing adaptations. Our naturalistic habitats are designed to help showcase the natural abilities of these hardy species. Careful, prolonged exposure to this area could bring out your wild side...";
                    attractionActivities.Add(attractionActivity);

                    attractionActivity = new AttractionActivity();
                    attractionActivity.Name = "Discovery Corner";
                    attractionActivity.Description = "Whether you are looking for an animal to meet up-close, or prefer those safely housed behind glass, you'll find it at Discovery Corner. Slide through a pool surrounded by otters. Follow a butterfly's wandering flight. Pet a rabbit, brush a goat and plot a way to help our environment. You can do it all at the Zoo's most hands-on, interactive exhibits, where one rule holds true: learning is fun!";
                    attractionActivities.Add(attractionActivity);
                    model.AttractionActivitys = attractionActivities;

                    List<Contact> contacts = new List<Contact>();
                    Contact contact = new Contact();
                    contact.PhonePublic = "(314) 781-0900";
                    contacts.Add(contact);

                    contact = new Contact();
                    contact.PhonePublic = "(800) 966-8877 Toll free";
                    contacts.Add(contact);
                    model.Contacts = contacts;
                    */

                    viewModels.Add(viewModel);
                }

            }

            return viewModels;
        }

        public static AttractionSplashIndexViewModel GetAttractionSplashViewModelById (int id)
        {
            if (viewModels.Count == 0)
            {
                viewModels = GetAttractionSplashIndexViewModel();
            }

            return viewModels.SingleOrDefault(d => d.Id == id);
        }

        public int Id { set; get; }

        public string Name { get; set; }
        public string Description { get; set; }

        public string BackgroundImage { get; set; }
        public string IconImage { get; set; }

        public List<Location> Locations { get; set; }  // should these be ViewModels instead of the Models?
        public List<Rating> Ratings { get; set; }
        public List<Activity> Activities { get; set; }
        public List<UserPrivilege> UserPrivileges { get; set; }
        public List<AttractionType> AttractionTypes { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<GeneralInformation> GeneralInfos { get; set; }
        public List<HoursOfOperation> HoursOfOperations { get; set; }  // maybe keep this in the Attraction class
        public List<CalenderOfEvent> CalendarOfEvents { get; set; }
        public List<Parking> Parkings { get; set; }
    }
}
