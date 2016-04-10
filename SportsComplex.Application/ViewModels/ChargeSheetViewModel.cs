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

        public List<ChargeViewModel> Charges { get; set; }
    }
}