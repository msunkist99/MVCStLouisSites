using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public interface IModelRepository
    {
        void Delete(int id);

        IModel GetById(int id);

        List<IModel> GetModels();

        int Save(IModel model);

        void Update(IModel model);
    }
}
