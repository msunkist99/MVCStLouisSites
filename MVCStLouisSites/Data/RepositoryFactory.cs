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

        //private static IModelRepository movieRepository;
        //private static IModelRepository directorRepository;

        public static IModelRepository GetAttractionRepository()
        {
            if (attractionRepository == null)
                attractionRepository = new AttractionRepository();
            return attractionRepository;
        }

        public static IModelRepository GetLocationRepository()
        {
            if (locationRepository == null)
                locationRepository = new LocationRepository();
            return locationRepository;
        }
        /*
        public static IModelRepository GetMovieRepository()
        {
            if (movieRepository == null)
                movieRepository = new MovieRepository();
            return movieRepository;
        }

        public static IModelRepository GetDirectorRepository()
        {
            if (directorRepository == null)
                directorRepository = new DirectorRepository();
            return directorRepository;
        }
        */
    }
}
