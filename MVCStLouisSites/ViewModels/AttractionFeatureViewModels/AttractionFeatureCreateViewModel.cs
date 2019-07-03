using Microsoft.AspNetCore.Mvc;
using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.AttractionFeatureViewModels
{
    public class AttractionFeatureCreateViewModel
    {
        public static int CreateAttractionFeature(ApplicationDbContext context, AttractionFeatureCreateViewModel attractionFeatureViewModel)
        {
            AttractionFeature attractionFeature = new AttractionFeature();

            attractionFeature.Name = attractionFeatureViewModel.Name;
            attractionFeature.Description = attractionFeatureViewModel.Description;

            IModel model = (IModel)attractionFeature;
            RepositoryFactory.GetAttractionFeatureRepository(context)
                             .Save(model);

            return model.Id;
        }

        public int Id { set; get; }

        [Required(ErrorMessage = "Attraction Feature Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Attraction Feature Description is required")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Description { get; set; }
    }
}
