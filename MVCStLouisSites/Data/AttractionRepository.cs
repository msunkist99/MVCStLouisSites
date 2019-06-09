using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class AttractionRepository: BaseRepository  // BaseRepository is an IModelRepository
    {
        // using the constructor we pass in the ApplicationDBContect
        public AttractionRepository (ApplicationDbContext context)
        {
            base.context = context;
        }

        public override void Delete(int id)
        {
            IModel model = GetById(id);

            Attraction attraction = (Attraction)model;

            context.Attraction.Remove(attraction);
            context.SaveChanges();
        }

        public override IModel GetById(int id)
        {
            IModel model = context.Attraction.Single(attraction => attraction.Id == id);
            return model;
        }

        public override List<IModel> GetModels()
        {
            List<IModel> models = context.Attraction.Cast<IModel>().ToList();
            return models;
        }

        /*
        public override List<IModel> GetModels()
        {
            List<Attraction> attractions = new List<Attraction>();

            Attraction attraction = new Attraction();
            attraction.Id = 1;
            attraction.Name = "Saint Louis Zoo";
            attraction.Description = "Recently voted Best Zoo and America’s Top Free Attraction, the Saint Louis Zoo is dedicated to connecting people to animals. Annually, approximately 3 million visitors get the opportunity to experience 17,000+ animals in the Zoo’s care; many of them are rare and endangered. The Zoo is renowned for its innovative approaches to animal management, wildlife conservation, research and education. And as a free zoo, visitors are encouraged to come back again…and again!";
            attraction.LocationIds = new List<int>();
            attraction.LocationIds.Add(1);
            attraction.RatingIds = new List<int>();
            attraction.RatingIds.Add(1);
            attraction.RatingIds.Add(2);
            attraction.RatingIds.Add(3);
            attraction.ActivityIds = new List<int>();
            attraction.ActivityIds.Add(1);
            attraction.ActivityIds.Add(2);
            attraction.ActivityIds.Add(3);
            attraction.ContactIds = new List<int>();
            attraction.ContactIds.Add(1);
            attraction.ContactIds.Add(2);
            attractions.Add(attraction);

            attraction = new Attraction();
            attraction.Id = 2;
            attraction.Name = "Laumeier Sculpture Park";
            attraction.Description = "Engaging the community through art and nature.";
            attraction.LocationIds = new List<int>();
            attraction.RatingIds = new List<int>();
            attraction.ActivityIds = new List<int>();
            attraction.ContactIds = new List<int>();
            attractions.Add(attraction);

            attraction = new Attraction();
            attraction.Id = 3;
            attraction.Name = "Soulard Farmers Market";
            attraction.Description = "We feature locally grown and shipped in goods, including: produce, meats, cheeses, spices, gourmet kettle corn, flowers, baked goods, and general merchandise. There are also several different eateries that have many food options, which allows customers the convenience to grab a quick bite to eat and a drink while shopping.";
            attraction.LocationIds = new List<int>();
            attraction.RatingIds = new List<int>();
            attraction.ActivityIds = new List<int>();
            attraction.ContactIds = new List<int>();
            attractions.Add(attraction);

            attraction = new Attraction();
            attraction.Id = 4;
            attraction.Name = "Das Bevo";
            attraction.Description = "Hallo friends, welcome to Das Bevo! We have been entertaining beer barons, friends, and family alike for over 100 years. Today, rehabilitated to it’s former glory, Das Bevo is once again bustling–this time as a combined biergarten and event space. We’re glad you’re here! Gute Fahrt!";
            attraction.LocationIds = new List<int>();
            attraction.RatingIds = new List<int>();
            attraction.ActivityIds = new List<int>();
            attraction.ContactIds = new List<int>();
            attractions.Add(attraction);
            base.models = attractions.Cast<IModel>().ToList();

            return base.models;
        }
        */
    }
}
