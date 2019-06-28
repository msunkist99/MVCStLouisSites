using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionFeatureViewModels;
using MVCStLouisSites.ViewModels.LocationViewModels;
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

            //foreach (AttractionFeature attractionFeature in attraction.AttractionAttractionFeatureJoins)
            //{

            //}
            viewModel.RatingCount = viewModel.RatingViewModels.Count();
            var average = viewModel.RatingViewModels
                                   .Where(p => p.AttractionId == id)
                                   .GroupBy(p => p.AttractionId)
                                   .Select(p => p.Average(q => q.Number))
                                   .SingleOrDefault();
            viewModel.RatingAverage = Convert.ToDecimal(average);

            List<AttractionFeatureDetailViewModel> attractionFeatureViewModelsForThisAttraction = AttractionFeatureDetailViewModel.GetAttractionFeatureModelsByAttractionId(context, id);
                                                                                          
            foreach(AttractionFeatureDetailViewModel attractionFeatureDetailViewModel in attractionFeatureViewModelsForThisAttraction)
            {
                if (true)
                {

                }
            }

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

            IModel model = (IModel)attraction;
            RepositoryFactory.GetAttractionRepository(context)
                             .Update(model);

            return attraction.Id;
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

        public List<AttractionFeature> AttractionFeatures { get; set; }
        public List<ParkingSite> ParkingSites { get; set; }
    }
}
