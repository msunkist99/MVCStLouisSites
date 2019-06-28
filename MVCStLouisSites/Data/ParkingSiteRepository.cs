using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class ParkingSiteRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        // using the constructor we pass in the ApplicationDBContect
        public ParkingSiteRepository(ApplicationDbContext context)
        {
            base.context = context;
        }

        public override List<IModel> GetModels()
        {
            List<IModel> models = context.ParkingSite
                                         .Cast<IModel>()
                                         .ToList();

            return models;
        }
    }
}
