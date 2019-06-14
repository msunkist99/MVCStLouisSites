using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.RatingViewModels
{
    public class RatingDetailViewModel
    {
        public static RatingDetailViewModel GetRatingByRatingId(ApplicationDbContext context, int ratingId)
        {
            IModel model = RepositoryFactory.GetRatingRepository(context)
                                            .GetById(ratingId);

            Rating rating = (Rating)model;

            RatingDetailViewModel viewModel = SetRatingDetailViewModel(context, rating);
            viewModel.AttractionName = SetRatingAttractionName(context, viewModel.AttractionId);
            return viewModel;
        }

        public static List<RatingDetailViewModel> GetLocationModels(ApplicationDbContext context)
        {
            List<Rating> ratingModels = RepositoryFactory.GetRatingRepository(context)
                                                         .GetModels()
                                                         .Cast<Rating>()
                                                         .ToList();

            List<RatingDetailViewModel> ratingViewModels = new List<RatingDetailViewModel>();

            foreach (Rating rating in ratingModels)
            {
                RatingDetailViewModel viewModel = SetRatingDetailViewModel(context, rating);
                viewModel.AttractionName = SetRatingAttractionName(context, viewModel.AttractionId);

                ratingViewModels.Add(viewModel);
            }
            return ratingViewModels;
        }

        public static List<RatingDetailViewModel> GetRatingModelsByAttractionId(ApplicationDbContext context, int attractionId)
        {
            // pull from the database here in RatingDetailViewModel instead of from LocationRepository because
            // GetLocationModelsByAttractionId is not in IModelRepository interface.
            List<Rating> ratings = context.Rating
                                          .Where(rating => rating.AttractionId == attractionId)
                                          .ToList();

            List<RatingDetailViewModel> ratingViewModels = new List<RatingDetailViewModel>();

            foreach (Rating rating in ratings)
            {
                RatingDetailViewModel viewModel = SetRatingDetailViewModel(context, rating);
                ratingViewModels.Add(viewModel);
            }
            return ratingViewModels;
        }

        private static RatingDetailViewModel SetRatingDetailViewModel(ApplicationDbContext context, Rating rating)
        {
            RatingDetailViewModel viewModel = new RatingDetailViewModel();

            viewModel.Id = rating.Id;
            viewModel.Number = rating.Number;
            viewModel.Comments = rating.Comments;
            viewModel.DateTimeStamp = rating.DateTimeStamp;

            viewModel.AttractionId = rating.AttractionId;

            return viewModel;
        }

        //  break this out from SetRatingDetailViewModel because you can end up in a loop
        //  from GetLocationModelsByAttractionId
        private static string SetRatingAttractionName(ApplicationDbContext context, int attractionId)
        {
            AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, attractionId);
            return attraction.Name;
        }

        public int Id { set; get; }

        public int Number { get; set; }
        public string Comments { get; set; }
        public DateTime DateTimeStamp { get; set; }

        // foreign key
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
    }
}

