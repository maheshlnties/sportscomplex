using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Application.ViewModels
{
    public class ChargeSheetViewModel
    {
        [Display(Name = "Select Month")]
        public int SelectedMonth { get; set; }

        [Display(Name = "Select Year")]
        public int SelectedYear { get; set; }
        
        public List<ChargeViewModel> ResourceCharges { get; set; }

        public List<ChargeViewModel> GymCharges { get; set; }

        public List<ChargeViewModel> TournmentCharges { get; set; }
    }
}