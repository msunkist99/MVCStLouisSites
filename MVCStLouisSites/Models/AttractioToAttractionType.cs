﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class AttractionToAttractionType
    {
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }

        public int AttractionTypeId { get; set; }
        public AttractionType AttractionType { get; set; }
    }
}
