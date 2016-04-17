using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

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

        public double GymTotalCharges { get { return GymCharges == null ? 0 : GymCharges.Sum(x => x.Charges); } }

        public double ResourceTotalCharges { get { return ResourceCharges == null ? 0 : ResourceCharges.Sum(x => x.Charges); } }

        public double TournmentTotalCharges
        {
            get { return TournmentCharges == null ? 0 : TournmentCharges.Sum(x => x.Charges); }
        }

        public double AllTotalCharges
        {
            get { return ResourceTotalCharges + GymTotalCharges + TournmentTotalCharges; }
        }
    }
}