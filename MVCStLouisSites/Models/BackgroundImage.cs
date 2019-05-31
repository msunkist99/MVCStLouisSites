﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class BackgroundImage : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string BackgroundImageFileLocation { get; set; }
    }
}
