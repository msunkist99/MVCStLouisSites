using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class BaseRepository : IModelRepository
    {
        // protected lets children of the BaseRepository access the models list
        protected List<IModel> models = new List<IModel>();
        //protected static int nextId = 1;

        protected ApplicationDbContext context;

        // yeah this ain't going to work - hard coding attraction
        public void Delete(int id)
        {
            IModel model = GetById(id);

            Attraction attraction = (Attraction)model;

            context.Attraction.Remove(attraction);
            context.SaveChanges();
        }

        // virtual - allows child to override
        // yeah this ain't going to work - hard coding attraction
        public virtual IModel GetById(int id)
        {
            IModel model = context.Attraction.Single(attraction => attraction.Id == id);
            return model;
        }

        // virtual - allows child to override
        // yeah this ain't going to work - hard coding attraction
        public virtual List<IModel> GetModels()
        {
            List<IModel> models = context.Attraction.Cast<IModel>().ToList();
            return models;
        }

        public int Save(IModel model)
        {
            context.Add(model);
            context.SaveChanges();
            return model.Id;
        }

        public void Update(IModel model)
        {
            context.Update(model);
            context.SaveChanges();
        }
    }
}
