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
    public class RatingCreateViewModel
    {
        // constructor
        public RatingCreateViewModel() { }

        // constructor
        public RatingCreateViewModel(ApplicationDbContext context, int attractionId = 0)
        {
            if (attractionId > 0)
            {
                AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, attractionId);
                this.AttractionId = attraction.Id;
                this.AttractionName = attraction.Name;
            }

            RatingItems = new List<RatingItem>();
            for (int i = 1; i < 6; i++)
            {
                RatingItem ratingItem = new RatingItem();
                ratingItem.Number = i;
                ratingItem.Stars = "";
                ratingItem.Stars = ratingItem.Stars.PadLeft(i, '*');

                RatingItems.Add(ratingItem);
            }
        }

        public static int CreateRating(ApplicationDbContext context, RatingCreateViewModel ratingViewModel)
        {
            Rating rating = new Rating();

            rating.Number = ratingViewModel.Number;
            rating.Comments = ratingViewModel.Comments;
            rating.DateTimeStamp = DateTime.Today;

            rating.AttractionId = ratingViewModel.AttractionId;

            IModel model = (IModel)rating;
            RepositoryFactory.GetRatingRepository(context)
                             .Save(model);

            return model.Id;
        }

        public int Id { set; get; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string Comments { get; set; }

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
