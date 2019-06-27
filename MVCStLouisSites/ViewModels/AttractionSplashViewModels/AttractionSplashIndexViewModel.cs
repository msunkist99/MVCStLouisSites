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
            AttractionSplashIndexViewModel viewModel = new AttractionSplashIndexViewModel();
            /*
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
                        // the next line is to just build the rating models list in GetLocationRepository
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
                        // the next line is to just build the activity models list in GetLocationRepository
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
                        // the next line is to just build the contact models list in GetLocationRepository
                        RepositoryFactory.GetContactRepository().GetModels();
                        Contact contact = (Contact)RepositoryFactory.GetContactRepository().GetById(contactId);

                        if (viewModel.Contacts == null)
                        {
                            viewModel.Contacts = new List<Contact>();
                        }
                        viewModel.Contacts.Add(contact);
                    }

                    viewModels.Add(viewModel);
                }
            }
            */

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

        public List<Location> Locations { get; set; }  // should these be ViewModels instead of the class Models?
        public List<Rating> Ratings { get; set; }
        public List<Activity> Activities { get; set; }
        public List<UserPrivilege> UserPrivileges { get; set; }
        public List<AttractionFeature> AttractionTypes { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<GeneralInformation> GeneralInfos { get; set; }
        public List<HoursOfOperation> HoursOfOperations { get; set; }  // maybe keep this in the Attraction class
        public List<CalenderOfEvent> CalendarOfEvents { get; set; }
        public List<ParkingSite> Parkings { get; set; }
    }
}
