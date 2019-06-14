using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.RatingViewModels
{
    public class RatingUpdateViewModel
    {
        public static RatingUpdateViewModel GetRatingById(ApplicationDbContext context, int id)
        {
            IModel model = RepositoryFactory.GetRatingRepository(context)
                                            .GetById(id);

            Rating rating = (Rating)model;

            RatingUpdateViewModel ratingViewModel = new RatingUpdateViewModel();

            ratingViewModel.Id = rating.Id;
            ratingViewModel.Number = rating.Number;
            ratingViewModel.Comments = rating.Comments;
            ratingViewModel.DateTimeStamp = rating.DateTimeStamp;
            ratingViewModel.AttractionId = rating.AttractionId;

            AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, rating.AttractionId);
            ratingViewModel.AttractionName = attraction.Name;

            ratingViewModel.RatingItems = new List<RatingItem>();
            for (int i = 1; i < 6; i++)
            {
                RatingItem ratingItem = new RatingItem();
                ratingItem.Number = i;
                ratingItem.Stars = "";
                ratingItem.Stars = ratingItem.Stars.PadLeft(i, '*');

                ratingViewModel.RatingItems.Add(ratingItem);
            }

            return ratingViewModel;
        }

        public static int UpdateRating(ApplicationDbContext context, RatingUpdateViewModel ratingViewModel)
        {
            Rating rating = new Rating();

            rating.Id = ratingViewModel.Id;
            rating.Number = ratingViewModel.Number;
            rating.Comments = ratingViewModel.Comments;
            rating.DateTimeStamp = ratingViewModel.DateTimeStamp;
            rating.AttractionId = ratingViewModel.AttractionId;
            IModel model = (IModel)rating;
            RepositoryFactory.GetRatingRepository(context)
                             .Update(model);

            return rating.Id;
        }

        public static void DeleteRatingById(ApplicationDbContext context, int id)
        {
            RepositoryFactory.GetRatingRepository(context).Delete(id);
        }

            public int Id { set; get; }

            [Required]
            public int Number { get; set; }

            [Required]
            public string Comments { get; set; }

            [Required]
            public DateTime DateTimeStamp { get; set; }

            // foreign key
            public int AttractionId { get; set; }
            public string AttractionName { get; set; }

        public List<RatingItem> RatingItems { get; set; }
        public class RatingItem
        {
            public int Number;
            public string Stars;
        }
    }
}
