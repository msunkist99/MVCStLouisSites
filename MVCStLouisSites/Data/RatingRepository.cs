using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class RatingRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        // using the constructor we pass in the ApplicationDBContect
        public RatingRepository(ApplicationDbContext context)
        {
            base.context = context;
        }

        public override IModel GetById(int ratingId)
        {
            IModel model = context.Rating.Single(rating => rating.Id == ratingId);
            return model;
        }

        public override List<IModel> GetModels()
        {
            List<IModel> models = context.Rating
                                         .Cast<IModel>()
                                         .ToList();
            return models;
        }

        public override void Delete(int id)
        {
            IModel model = GetById(id);

            Rating rating = (Rating)model;

            context.Rating.Remove(rating);
            context.SaveChanges();
        }

        //  override BaseRepository
        //  we override here until we get the database implemented in the BaseRepository.cs

        /*
        public override List<IModel> GetModels()
        {
            List<Rating> ratings = new List<Rating>();
            Rating rating = new Rating();

            rating.Id = 1;
            rating.Number = 5;        // consider making this STARS in the view model
            rating.Comments = "The zoo is absolutely amazing and it's free!!!! It is very well laid out, the walking paths have some shade which is also nice and plenty of benches for a little rest between exhibits. It was quite warm the day we went and they had lots of places to buy refreshments. What a gem this gorgeous zoo is.";
            ratings.Add(rating);

            rating = new Rating();
            rating.Id = 2;
            rating.Number = 2;        // consider making this STARS in the view model
            rating.Comments = "Zoo opened at 8:00, but animals weren’t out till after 9:00, even then not many were seen, dolphin show was wonderful, but after spending 6 hours there, I don’t feel we saw over 3-4 animals😩, very disappointed !";
            ratings.Add(rating);

            rating = new Rating();
            rating.Id = 3;
            rating.Number = 3;        // consider making this STARS in the view model
            rating.Comments = "We went on a holiday weekend so it was probably more crowded that normal. It took me 30 minutes to find public parking on the street and walk back to the entrance. In late afternoon most of the animals we saw were waiting at their gates/doors to go inside for the night and I assume be fed. Starting around an hour before closing the animals begin to transition and it's disappointing to not see them.";
            ratings.Add(rating);

            base.models = ratings.Cast<IModel>().ToList();

            return base.models;
        }
        */
    }
}
