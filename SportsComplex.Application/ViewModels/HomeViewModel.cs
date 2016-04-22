using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Application.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            SearchViewModel=new SearchViewModel();
        }


        [Required]
        public LoginViewModel LoginViewModel { get; set; }

        public List<NewsViewModel> News { get; set; }

        public List<ImageViewModel> Images { get; set; }

        public SearchViewModel SearchViewModel { get; set; }
    }
}