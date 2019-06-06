using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class Neighborhood : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string Name { get; set; }

        // foreign key
        //public int AttractionId { get; set; }
        // navigation property
        //public Attraction Attaction { get; set; }
    }
}
