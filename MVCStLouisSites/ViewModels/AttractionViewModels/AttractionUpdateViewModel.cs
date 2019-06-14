using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
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
            viewModel.IconImageId = attraction.IconImageId;
            viewModel.LocationViewModels = LocationDetailViewModel.GetLocationModelsByAttractionId(context, attraction.Id);
            viewModel.RatingViewModels = RatingDetailViewModel.GetRatingModelsByAttractionId(context, attraction.Id);
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
            attraction.BackgroundImageId = attractionViewModel.BackgroundImageId;
            attraction.IconImageId = attractionViewModel.IconImageId;

            IModel model = (IModel)attraction;
            RepositoryFactory.GetAttractionRepository(context)
                             .Update(model);

            return attraction.Id;
        }

        public int Id { set; get; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
        public int BackgroundImageId { get; set; }
        public int IconImageId { get; set; }

        public List<LocationDetailViewModel> LocationViewModels = new List<LocationDetailViewModel>();
        public List<RatingDetailViewModel> RatingViewModels = new List<RatingDetailViewModel>();
    }
}
