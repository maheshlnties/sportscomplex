using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Application.ViewModels
{
    public class GymViewModel
    {
        public string Id { get; set; }

        public bool Joined { get; set; }

        [Display(Name = "P.S. Number*")]
        public string PsNumber { get; set; }
    }
}