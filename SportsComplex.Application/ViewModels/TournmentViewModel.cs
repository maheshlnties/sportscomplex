using System;
using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Application.ViewModels
{
    public class TournmentViewModel
    {
        [Display(Name = "Tournment Name*")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Tournment Fees*")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter valid Fees")]
        [Required]
        public int Fees { get; set; }
        
        [Display(Name = "Last Date of Registration*")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime LastDate { get; set; }

        [Display(Name = "Enrolled")]
        [Required]
        public bool IsEnrolled { get; set; }

        public bool IsSelected { get; set; }
    }
}