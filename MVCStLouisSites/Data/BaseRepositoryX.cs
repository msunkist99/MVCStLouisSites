using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class BaseRepositoryX : IModelRepository
    {
        // protected lets children of the BaseRepository access the models list
        protected List<IModel> models = new List<IModel>();
        //protected static int nextId = 1;

        public void Delete(int id)
        {
            models.RemoveAll(d => d.Id == id);
        }

        // virtual - allows child to override
        public virtual IModel GetById(int id)
        {
            return models.SingleOrDefault(d => d.Id == id);
        }

        // virtual - allows child to override
        public virtual List<IModel> GetModels()
        {
            return models;
        }

        public int Save(IModel model)
        {
            //model.Id = nextId++;
            models.Add(model);
            return model.Id;
        }

        public void Update(IModel model)
        {
            this.Delete(model.Id);
            models.Add(model);
        }
    }
}
