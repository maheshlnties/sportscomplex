using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Application.ViewModels
{
    public class HomeViewModel
    {
        [Required]
        public LoginViewModel LoginViewModel { get; set; }

        //[Required]
        public NewsViewModel NewsViewModel { get; set; }
    }
}