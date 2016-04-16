using System;

namespace SportsComplex.Application.ViewModels
{
    public class ChargeViewModel
    {
        public string PsNumber { get; set; }

        public string Name { get; set; }

        public double Charges { get; set; }

        public DateTime TransactionDate { get; set; }

        public string TournmentName { get; set; }

        public string ResourceName { get; set; }

        public string Slot { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }        
    }
}