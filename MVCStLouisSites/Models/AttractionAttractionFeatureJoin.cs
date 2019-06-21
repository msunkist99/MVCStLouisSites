using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class AttractionAttractionFeatureJoin
    {
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
        public int AttractionFeatureId { get; set; }
        public AttractionFeature AttractionFeature { get; set; }
    }
}
