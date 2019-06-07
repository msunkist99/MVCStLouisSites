using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.AttractionViewModels
{
    public class AttractionIndexViewModel
    {
        public static List<AttractionIndexViewModel> GetAttractions(ApplicationDbContext context)
        {
            List<Attraction> attractions = RepositoryFactory.GetAttractionRepository(context)
                                                            .GetModels()
                                                            .Cast<Attraction>()
                                                            .ToList();

            List<AttractionIndexViewModel> viewModels = new List<AttractionIndexViewModel>();

            AttractionIndexViewModel viewModel;
            foreach (Attraction attraction in attractions)
            {
                viewModel = new AttractionIndexViewModel();

                viewModel.Id = attraction.Id;
                viewModel.Name = attraction.Name;
                viewModel.Description = attraction.Description;
                viewModels.Add(viewModel);
            }

            return viewModels;
        }

        public int Id { set; get; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
