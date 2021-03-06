﻿using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class LocationRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        //  override BaseRepository
        //  we override here until we get the database implemented in the BaseRepository.cs
        public override List<IModel> GetModels()
        {
            List<Location> locations = new List<Location>();
            Location location = new Location();

            location.Id = 1;
            location.StreetAddress = "One Government Drive";
            location.City = "St. Louis";
            location.State = "Missouri";
            location.Zip = "63110";
            location.County = " St. Louis City";
            location.GPS = "unknown";
            locations.Add(location);

            base.models = locations.Cast<IModel>().ToList();

            return base.models;
        }
    }
}
