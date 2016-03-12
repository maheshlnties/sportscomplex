using System;

namespace SportsComplex.Models
{
    public class Employee
    {
        public string PsNumber { get; set; }

        public string Name { get; set; }

        public Gender Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public BuisnessUnit BuisnessUnit { get; set; }

        public string Address { get; set; }

        public string DeskPhoneNumber { get; set; }

        public string Mobile { get; set; }

        public string Password { get; set; }

        public UserRoles UserRole { get; set; }
    }
}