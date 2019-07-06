using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class AttractionFeatureRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        // using the constructor we pass in the ApplicationDBContect
        public AttractionFeatureRepository(ApplicationDbContext context)
        {
            base.context = context;
        }

        public override List<IModel> GetModels()
        {
            List<IModel> models = context.AttractionFeature
                                         .Cast<IModel>()
                                         .ToList();

            return models;
        }

    }
}
