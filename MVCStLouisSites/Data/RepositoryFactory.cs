using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public static class RepositoryFactory
    {
        private static IModelRepository attractionRepository;
        private static IModelRepository locationRepository;
        private static IModelRepository ratingRepository;
        private static IModelRepository activityRepository;
        private static IModelRepository contactRepository;

        //private static IModelRepository movieRepository;
        //private static IModelRepository directorRepository;

        public static IModelRepository GetAttractionRepository(ApplicationDbContext context)
        {
            //if (attractionRepository == null)
                attractionRepository = new AttractionRepository(context);
            
            return attractionRepository;
        }

        public static IModelRepository GetLocationRepository()
        {
            if (locationRepository == null)
                locationRepository = new LocationRepository();
            return locationRepository;
        }

        public static IModelRepository GetRatingRepository()
        {
            if(ratingRepository == null)
            {
                ratingRepository = new RatingRepository();
            }
            return ratingRepository;
        }

        public static IModelRepository GetActivityRepository()
        {
            if (activityRepository == null)
            {
                activityRepository = new ActivityRepository();
            }
            return activityRepository;
        }

        public static IModelRepository GetContactRepository()
        {
            if (contactRepository == null)
            {
                contactRepository = new ContactRepository();
            }
            return contactRepository;
        }
    }
}
