using System;
using System.ComponentModel.DataAnnotations;

namespace SportsComplex.Application.ViewModels
{
    public class GymViewModel
    {
        public bool Jonined { get; set; }

        [Display(Name = "P.S. Number*")]
        public string PsNumber { get; set; }
    }
}