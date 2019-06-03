using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    interface IAttractionRepository
    {
        int Save (Attraction attraction);

        List<Attraction> GetAttractions();

        Attraction GetById(int id);

        void Update(Attraction attraction);

        void Delete(int id);
    }
}
