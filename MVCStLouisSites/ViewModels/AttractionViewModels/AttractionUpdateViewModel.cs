using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionFeatureViewModels;
using MVCStLouisSites.ViewModels.LocationViewModels;
using MVCStLouisSites.ViewModels.ParkingSiteViewModels;
using MVCStLouisSites.ViewModels.RatingViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.AttractionViewModels
{
    public class AttractionUpdateViewModel
    {
        public static AttractionUpdateViewModel GetAttractionById (ApplicationDbContext context, int id)
        {
            IModel model = RepositoryFactory.GetAttractionRepository(context)
                                            .GetById(id);

            Attraction attraction = (Attraction)model;

            AttractionUpdateViewModel viewModel = new AttractionUpdateViewModel();

            viewModel.Id = attraction.Id;
            viewModel.Name = attraction.Name;
            viewModel.Description = attraction.Description;
            viewModel.BackgroundImageId = attraction.BackgroundImageId;
            viewModel.BackgroundImageFileName = attraction.BackgroundImage.BackgroundImageFileName;
            viewModel.IconImageId = attraction.IconImageId;
            viewModel.IconImageFileName = attraction.IconImage.IconImageFileName;

            foreach (Location location in attraction.Locations)
            {
                LocationDetailViewModel loctionViewModel = LocationDetailViewModel.SetLocationDetailViewModel(location);
                viewModel.LocationViewModels.Add(loctionViewModel);
            }

            foreach (Rating rating in attraction.Ratings)
            {
                RatingDetailViewModel ratingViewModel = RatingDetailViewModel.SetRatingDetailViewModel(rating);
                viewModel.RatingViewModels.Add(ratingViewModel);
            }

            foreach (AttractionFeatureAttraction attractionFeatureAttraction in attraction.AttractionFeatureAttractions)
            {
                AttractionFeatureUpdateViewModel attractionFeatureDetailViewModel = new AttractionFeatureUpdateViewModel();
                attractionFeatureDetailViewModel.Id = attractionFeatureAttraction.AttractionFeature.Id;
                attractionFeatureDetailViewModel.Name = attractionFeatureAttraction.AttractionFeature.Name;
                attractionFeatureDetailViewModel.Description = attractionFeatureAttraction.AttractionFeature.Description;
                viewModel.AttractionFeatureViewModels.Add(attractionFeatureDetailViewModel);
            }

            foreach (ParkingSiteAttraction parkingSiteAttraction in attraction.ParkingSiteAttractions)
            {
                ParkingSiteDetailViewModel parkingSiteDetailViewModel = new ParkingSiteDetailViewModel();
                parkingSiteDetailViewModel.Id = parkingSiteAttraction.ParkingSite.Id;
                parkingSiteDetailViewModel.ParkingType = parkingSiteAttraction.ParkingSite.ParkingType;
                viewModel.ParkingSiteViewModels.Add(parkingSiteDetailViewModel);
            }

            viewModel.RatingCount = viewModel.RatingViewModels.Count();
            var average = viewModel.RatingViewModels
                                   .Where(p => p.AttractionId == id)
                                   .GroupBy(p => p.AttractionId)
                                   .Select(p => p.Average(q => q.Number))
                                   .SingleOrDefault();
            
            viewModel.RatingAverage = Convert.ToDecimal(average);
            Math.Round(viewModel.RatingAverage, 2);

            // complete list of AttractionFeatures
            viewModel.AttractionFeatureIds = viewModel.AttractionFeatureViewModels
                                                      .Select(afvm => afvm.Id)
                                                      .ToList();

            // complete list of ParkingSites
            viewModel.ParkingSiteIds = viewModel.ParkingSiteViewModels
                                                .Select(psvm => psvm.Id)
                                                .ToList();

            viewModel.AttractionFeatures = RepositoryFactory.GetAttractionFeatureRepository(context)
                                                            .GetModels()
                                                            .Cast<AttractionFeature>()
                                                            .ToList();

            viewModel.ParkingSites = RepositoryFactory.GetParkingSiteRepository(context)
                                                      .GetModels()
                                                      .Cast<ParkingSite>()
                                                      .ToList();
            return viewModel;
        }

        public static void DeleteAttractionById (ApplicationDbContext context, int id)
        {
            RepositoryFactory.GetAttractionRepository(context).Delete(id);
        }

        public static int UpdateAttraction(ApplicationDbContext context, AttractionUpdateViewModel attractionViewModel)
        {
            Attraction attraction = new Attraction();

            attraction.Id = attractionViewModel.Id;
            attraction.Name = attractionViewModel.Name;
            attraction.Description = attractionViewModel.Description;

            if (attractionViewModel.BackgroundImageId == 0)
            {
                attractionViewModel.BackgroundImageId = 5; // smiley face
            }
            attraction.BackgroundImageId = attractionViewModel.BackgroundImageId;

            if (attractionViewModel.IconImageId == 0 )
            {
                attractionViewModel.IconImageId = 5; // smiley face
            }

            attraction.IconImageId = attractionViewModel.IconImageId;

            if (attractionViewModel.AttractionFeatureIsChecked != null)
            {
                List<AttractionFeatureAttraction> attractionFeatureAttractions = CreateManyToManyRelationshipsAttractionFeatureAttraction(attraction.Id, attractionViewModel.AttractionFeatureIsChecked);
                attraction.AttractionFeatureAttractions = attractionFeatureAttractions;
            }

            if (attractionViewModel.ParkingSiteIsChecked != null)
            {
                List<ParkingSiteAttraction> parkingSiteAttractions = CreateManyToManyRelationshipsParkingSiteAttraction(attraction.Id, attractionViewModel.ParkingSiteIsChecked);
                attraction.ParkingSiteAttractions = parkingSiteAttractions;
            }

            // Delete the existing AttractionFeatureAttractions for the attraction
            List<AttractionFeatureAttraction> attractionFeatureAttractionsDelete = context.AttractionFeatureAttractions
                                                                                          .Where(afa => afa.AttractionId == attraction.Id)
                                                                                          .ToList();

            foreach (AttractionFeatureAttraction attractionFeatureAttraction in attractionFeatureAttractionsDelete)
            {
                context.AttractionFeatureAttractions
                       .Remove(attractionFeatureAttraction);
            }
            context.SaveChanges();

            // Delete the existing ParkingSiteAttractions for the attraction
            List<ParkingSiteAttraction> parkingSiteAttractionsDelete = context.ParkingSiteAttractions
                                                                              .Where(psa => psa.AttractionId == attraction.Id)
                                                                              .ToList();

            foreach (ParkingSiteAttraction parkingSiteAttraction in parkingSiteAttractionsDelete)
            {
                context.ParkingSiteAttractions
                       .Remove(parkingSiteAttraction);
            }
            context.SaveChanges();

            IModel model = (IModel)attraction;
            RepositoryFactory.GetAttractionRepository(context)
                             .Update(model);

            return attraction.Id;
        }

        private static List<AttractionFeatureAttraction> CreateManyToManyRelationshipsAttractionFeatureAttraction(int id, List<int> attractionFeatureIsChecked)
        {
            return attractionFeatureIsChecked.Select(af => new AttractionFeatureAttraction { AttractionId = id, AttractionFeatureId = af }).ToList();
        }

        private static List<ParkingSiteAttraction> CreateManyToManyRelationshipsParkingSiteAttraction(int id, List<int> parkingSiteIsChecked)
        {
            return parkingSiteIsChecked.Select(ps => new ParkingSiteAttraction { AttractionId = id, ParkingSiteId = ps }).ToList();
        }

        public int Id { set; get; }

        [Required]
        public string Name { get; set; }

        [Required (ErrorMessage = "Attraction Description is required")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Description { get; set; }
        public int BackgroundImageId { get; set; }
        public int IconImageId { get; set; }
        public string BackgroundImageFileName { get; set; }
        public string IconImageFileName { get; set; }
        public List<LocationDetailViewModel> LocationViewModels = new List<LocationDetailViewModel>();
        public List<RatingDetailViewModel> RatingViewModels = new List<RatingDetailViewModel>();

        public int RatingCount { get; set; }
        public decimal RatingAverage { get; set; }

        public List<AttractionFeatureUpdateViewModel> AttractionFeatureViewModels = new List<AttractionFeatureUpdateViewModel>();
        public List<ParkingSiteDetailViewModel> ParkingSiteViewModels = new List<ParkingSiteDetailViewModel>();

        public List<int> AttractionFeatureIds = new List<int>();
        public List<int> ParkingSiteIds = new List<int>();

        public List<int> AttractionFeatureIsChecked { get; set; }
        public List<int> ParkingSiteIsChecked { get; set; }

        public List<AttractionFeature> AttractionFeatures = new List<AttractionFeature>();
        public List<ParkingSite> ParkingSites = new List<ParkingSite>();
    }
}
