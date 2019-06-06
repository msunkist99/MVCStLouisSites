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
        //public static List<AttractionIndexViewModel> viewModels = new List<AttractionIndexViewModel>();


        public static List<AttractionIndexViewModel> GetAttractionIndexViewModels(ApplicationDbContext context)
        {
            // need logic here to retrieve the List<Attraction> attractions from the database.
            //              return viewModel.SingleOrDefault(d => d.Id == id);
            // this will be in the Data\BaseRepository accessed via RepositoryFactory.GetAttractionhRepository().GetById(id)
            // the List<AttractionIndexViewModel> would then be built from the data retrieved from the database.

            /*
            if (viewModels.Count == 0)
            {
                List<Attraction> attractions = RepositoryFactory.GetAttractionRepository()
                                                .GetModels()
                                                .Cast<Attraction>()
                                                .ToList();

                AttractionIndexViewModel viewModel;
                foreach (Attraction attraction in attractions)
                {
                    viewModel = new AttractionIndexViewModel();

                    viewModel.Id = attraction.Id;
                    viewModel.Name = attraction.Name;
                    viewModel.Description = attraction.Description;
                    viewModels.Add(viewModel);

                    viewModel = new AttractionIndexViewModel();
                    viewModel.Id = attraction.Id;
                    viewModel.Name = attraction.Name;
                    viewModel.Description = attraction.Description;
                    viewModels.Add(viewModel);

                    viewModel = new AttractionIndexViewModel();
                    viewModel.Id = attraction.Id;
                    viewModel.Name = attraction.Name;
                    viewModel.Description = attraction.Description;
                    viewModels.Add(viewModel);

                    viewModel = new AttractionIndexViewModel();
                    viewModel.Id = attraction.Id;
                    viewModel.Name = attraction.Name;
                    viewModel.Description = attraction.Description;
                    viewModels.Add(viewModel);
                    
                }
            }
            */

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
