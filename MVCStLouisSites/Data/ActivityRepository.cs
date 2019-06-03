using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCStLouisSites.Models;

namespace MVCStLouisSites.Data
{
    public class ActivityRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        //  override BaseRepository
        //  we override here until we get the database implemented in the BaseRepository.cs
        public override List<IModel> GetModels()
        {
            List<Activity> activities = new List<Activity>();
            Activity activity = new Activity();

            activity.Id = 1;
            activity.Name = "Rivers Edge";
            activity.Description = "Take a journey along a mythical waterway through four continents to discover how wildlife, plants and people interact. River's Edge is the Saint Louis Zoo's first immersion exhibit—a lushly planted naturalistic environment showcasing multiple species from around the world. ";
            activities.Add(activity);

            activity = new Activity();
            activity.Id = 2;
            activity.Name = "The Wild";
            activity.Description = "From the sub-Antarctic to tropical rainforests, animals have made some pretty amazing adaptations. Our naturalistic habitats are designed to help showcase the natural abilities of these hardy species. Careful, prolonged exposure to this area could bring out your wild side...";
            activities.Add(activity);

            activity = new Activity();
            activity.Id = 3;
            activity.Name = "Discovery Corner";
            activity.Description = "Whether you are looking for an animal to meet up-close, or prefer those safely housed behind glass, you'll find it at Discovery Corner. Slide through a pool surrounded by otters. Follow a butterfly's wandering flight. Pet a rabbit, brush a goat and plot a way to help our environment. You can do it all at the Zoo's most hands-on, interactive exhibits, where one rule holds true: learning is fun!";
            activities.Add(activity);

            base.models = activities.Cast<IModel>().ToList();

            return base.models;
        }
    }
}
