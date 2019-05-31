using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.StLouisSites
{
    public class StLouisSitesIndexViewModel
    {
        public static List<StLouisSitesIndexViewModel> GetStLouisSitesIndexViewModel()
        {
            List<StLouisSitesIndexViewModel> models = new List<StLouisSitesIndexViewModel>();

            StLouisSitesIndexViewModel model = new StLouisSitesIndexViewModel();

            model.Id = 1;
            model.Name = "Saint Louis Zoo";
            model.Description = "Recently voted Best Zoo and America’s Top Free Attraction, the Saint Louis Zoo is dedicated to connecting people to animals. Annually, approximately 3 million visitors get the opportunity to experience 17,000+ animals in the Zoo’s care; many of them are rare and endangered. The Zoo is renowned for its innovative approaches to animal management, wildlife conservation, research and education. And as a free zoo, visitors are encouraged to come back again…and again!";
            models.Add(model);

            model = new StLouisSitesIndexViewModel();
            model.Id = 2;
            model.Name = "Laumeier Sculpture Park";
            model.Description = "Engaging the community through art and nature.";
            models.Add(model);

            model = new StLouisSitesIndexViewModel();
            model.Id = 3;
            model.Name = "Soulard Farmers Market";
            model.Description = "We feature locally grown and shipped in goods, including: produce, meats, cheeses, spices, gourmet kettle corn, flowers, baked goods, and general merchandise. There are also several different eateries that have many food options, which allows customers the convenience to grab a quick bite to eat and a drink while shopping.";
            models.Add(model);

            model = new StLouisSitesIndexViewModel();
            model.Id = 4;
            model.Name = "Das Bevo";
            model.Description = "Hallo friends, welcome to Das Bevo! We have been entertaining beer barons, friends, and family alike for over 100 years. Today, rehabilitated to it’s former glory, Das Bevo is once again bustling–this time as a combined biergarten and event space. We’re glad you’re here! Gute Fahrt!";
            models.Add(model);

            return models;
        }

        public int Id { set; get; }

        public string Name { get; set; }
        public string Description { get; set; }
    }
}
