using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.AttractionFeatureViewModels
{
    public class AttractionFeatureUpdateViewModel
    {
        public static AttractionFeatureUpdateViewModel GetAttractionFeatureByAttractionFeatureId(ApplicationDbContext context, int attractionFeatureId)
        {
            IModel model = RepositoryFactory.GetAttractionFeatureRepository(context)
                                            .GetById(attractionFeatureId);

            AttractionFeature attractionFeature = (AttractionFeature)model;

            AttractionFeatureUpdateViewModel viewModel = SetAttractionFeatureDetailViewModel(attractionFeature);
            //viewModel.AttractionName = SetAttractionFeatureAttractionName(context, viewModel.AttractionId);
            return viewModel;
        }

        public static List<AttractionFeatureUpdateViewModel> GetAttractionFeatureModels(ApplicationDbContext context)
        {
            List<AttractionFeature> attractionFeatureModels = RepositoryFactory.GetAttractionFeatureRepository(context)
                                                                               .GetModels()
                                                                               .Cast<AttractionFeature>()
                                                                               .ToList();

            List<AttractionFeatureUpdateViewModel> attractionFeatureViewModels = new List<AttractionFeatureUpdateViewModel>();

            //foreach (AttractionFeature attractionFeature in attractionFeatureModels)
            //{
                //AttractionFeatureDetailViewModel viewModel = SetAttractionFeatureDetailViewModel(attractionFeature);
                //viewModel.AttractionName = SetAttractionFeatureAttractionName(context, viewModel.AttractionId);

                //attractionFeatureViewModels.Add(viewModel);
            //}
            return attractionFeatureViewModels;
        }

        public static List<AttractionFeatureUpdateViewModel> GetAttractionFeatureModelsByAttractionId(ApplicationDbContext context, int attractionId)
        {
            // pull from the database here in AttractionFeatureDetailViewModel instead of from AttractionFeatureRepository because
            // GetAttractionFeatureModelsByAttractionId is not in IModelRepository interface.
            List<AttractionFeatureAttraction> attractionFeatureAttractions = context.AttractionFeatureAttractions
                                                                                    .Where(afa => afa.AttractionFeature.Id == attractionId)
                                                                                    .ToList();

            List<AttractionFeatureUpdateViewModel> attractionFeatureViewModels = new List<AttractionFeatureUpdateViewModel>();

            //foreach (AttractionFeatureAttraction attractionFeatureAttraction in attractionFeatureAttractions)
            //{
            //    AttractionFeatureDetailViewModel viewModel = SetAttractionFeatureDetailViewModel(attractionFeatureAttraction);
            //    attractionFeatureViewModels.Add(viewModel);
            //}

            return attractionFeatureViewModels;
        }

        public static AttractionFeatureUpdateViewModel SetAttractionFeatureDetailViewModel(AttractionFeature attractionFeature)
        {
            AttractionFeatureUpdateViewModel viewModel = new AttractionFeatureUpdateViewModel();

            viewModel.Id = attractionFeature.Id;
            viewModel.Name = attractionFeature.Name;
            viewModel.Description = attractionFeature.Description;

            return viewModel;
        }

        public static AttractionFeatureUpdateViewModel SetAttractionFeatureDetailViewModel(AttractionFeatureAttraction attractionFeatureAttraction)
        {
            AttractionFeatureUpdateViewModel viewModel = new AttractionFeatureUpdateViewModel();

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
    }
}
