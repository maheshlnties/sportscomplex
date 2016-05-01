using System;
using System.ComponentModel.DataAnnotations;
using SportsComplex.Models;

namespace SportsComplex.Application.ViewModels
{
    public class EmployeeViewModel
    {
        [Display(Name = "P.S. Number*")]
        [Required]
        public string PsNumber { get; set; }

        [Display(Name = "Employee Name*")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Gender*")]
        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "Date of Birth*")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Email*")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Buisness Unit*")]
        [Required]
        public BuisnessUnit BuisnessUnit { get; set; }

        [Display(Name = "Address*")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Desk Phone Number*")]
        [Required]
        public string DeskPhoneNumber { get; set; }

        [Display(Name = "Mobile*")]
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Mobile number")]
        public string Mobile { get; set; }

        [Display(Name = "Password*")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Confirm Password*")]
        [Required]
        public string ConfirmPassword { get; set; }

        [Required]
        public UserRoles UserRole { get; set; }
    }
}