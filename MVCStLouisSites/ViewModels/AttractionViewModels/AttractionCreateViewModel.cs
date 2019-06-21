using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.AttractionViewModels
{
    public class AttractionCreateViewModel
    {
        public static int CreateAttraction(ApplicationDbContext context, AttractionCreateViewModel attractionViewModel)
        {
            Attraction attraction = new Attraction();

            attraction.Name = attractionViewModel.Name;
            attraction.Description = attractionViewModel.Description;
            attraction.BackgroundImageId = attractionViewModel.BackgroundImageId;
            attraction.IconImageId = attractionViewModel.IconImageId;

            IModel model = (IModel)attraction;
            RepositoryFactory.GetAttractionRepository(context)
                             .Save(model);

            return model.Id;
        }

        public int Id { set; get; }

        [Required]
        public string Name { get; set; }

        [Required(ErrorMessage = "Attraction Description is required")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Description { get; set; }

        public int BackgroundImageId { get; set; }
        public int IconImageId { get; set; }
    }
}
