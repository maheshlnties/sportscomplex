using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Models
{
    public enum BuisnessUnit
    {
        [Display(Name = "Common Service")]
        CS,
        [Display(Name = "Meteric Protrction Service")]
        MPS,
        [Display(Name = "Technology Service")]
        TS
    }
}