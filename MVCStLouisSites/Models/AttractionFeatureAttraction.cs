using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class AttractionFeatureAttraction
    {
        public int Id { get; set; }

        public int AttractionFeatureId { get; set; }
        public int AttractionId { get; set; }

        public virtual AttractionFeature AttractionFeature { get; set; }
        public virtual Attraction Attraction { get; set; }
    }
}
