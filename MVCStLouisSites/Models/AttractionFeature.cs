using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class AttractionFeature : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string Name { get; set; }
        public string Description { get; set; }

        // navigation property - many attraction features to-many attractions
        public IList<AttractionAttractionFeatureJoin> AttractionAttractionFeatureJoins { get; set; }
    }
}
