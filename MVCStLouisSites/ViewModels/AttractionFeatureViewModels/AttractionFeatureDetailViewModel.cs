using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.AttractionFeatureViewModels
{
    public class AttractionFeatureDetailViewModel
    {
        public static AttractionFeatureDetailViewModel GetAttractionFeatureByAttractionFeatureId(ApplicationDbContext context, int attractionFeatureId)
        {
            IModel model = RepositoryFactory.GetAttractionFeatureRepository(context)
                                            .GetById(attractionFeatureId);

            AttractionFeature attractionFeature = (AttractionFeature)model;

            AttractionFeatureDetailViewModel viewModel = SetAttractionFeatureDetailViewModel(attractionFeature);
            viewModel.AttractionName = SetAttractionFeatureAttractionName(context, viewModel.AttractionId);
            return viewModel;
        }

        public static List<AttractionFeatureDetailViewModel> GetAttractionFeatureModels(ApplicationDbContext context)
        {
            List<AttractionFeature> attractionFeatureModels = RepositoryFactory.GetAttractionFeatureRepository(context)
                                                                               .GetModels()
                                                                               .Cast<AttractionFeature>()
                                                                               .ToList();

            List<AttractionFeatureDetailViewModel> attractionFeatureViewModels = new List<AttractionFeatureDetailViewModel>();

            foreach (AttractionFeature attractionFeature in attractionFeatureModels)
            {
                AttractionFeatureDetailViewModel viewModel = SetAttractionFeatureDetailViewModel(attractionFeature);
                //viewModel.AttractionName = SetAttractionFeatureAttractionName(context, viewModel.AttractionId);

                attractionFeatureViewModels.Add(viewModel);
            }
            return attractionFeatureViewModels;
        }

        public static List<AttractionFeatureDetailViewModel> GetAttractionFeatureModelsByAttractionId(ApplicationDbContext context, int attractionId)
        {
            // pull from the database here in AttractionFeatureDetailViewModel instead of from AttractionFeatureRepository because
            // GetAttractionFeatureModelsByAttractionId is not in IModelRepository interface.
            List<AttractionFeatureAttraction> attractionFeatureAttractions = context.AttractionFeatureAttractions
                                                                                    .Where(afa => afa.AttractionFeature.Id == attractionId)
                                                                                    .ToList();

            List<AttractionFeatureDetailViewModel> attractionFeatureViewModels = new List<AttractionFeatureDetailViewModel>();

            foreach (AttractionFeatureAttraction attractionFeatureAttraction in attractionFeatureAttractions)
            {
                AttractionFeatureDetailViewModel viewModel = SetAttractionFeatureDetailViewModel(attractionFeatureAttraction);
                attractionFeatureViewModels.Add(viewModel);
            }

            return attractionFeatureViewModels;
        }

        public static AttractionFeatureDetailViewModel SetAttractionFeatureDetailViewModel(AttractionFeature attractionFeature)
        {
            AttractionFeatureDetailViewModel viewModel = new AttractionFeatureDetailViewModel();

            viewModel.Id = attractionFeature.Id;
            viewModel.Name = attractionFeature.Name;
            viewModel.Description = attractionFeature.Description;

            return viewModel;
        }

        public static AttractionFeatureDetailViewModel SetAttractionFeatureDetailViewModel(AttractionFeatureAttraction attractionFeatureAttraction)
        {
            AttractionFeatureDetailViewModel viewModel = new AttractionFeatureDetailViewModel();

            viewModel.Id = attractionFeatureAttraction.AttractionFeature.Id;
            viewModel.Name = attractionFeatureAttraction.AttractionFeature.Name;
            viewModel.Description = attractionFeatureAttraction.AttractionFeature.Description;

            return viewModel;
        }

        //  break this out from SetRatingDetailViewModel because you can end up in a loop
        //  from GetLocationModelsByAttractionId
        public static string SetAttractionFeatureAttractionName(ApplicationDbContext context, int attractionId)
        {
            AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, attractionId);
            return attraction.Name;
        }

        public int Id { set; get; }

        public string Name { get; set; }
        public string Description { get; set; }
        public bool Selected { get; set; }

        // foreign key
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
    }
}
