using System;

namespace SportsComplex.Models
{
    public class TournmentBooking
    {
        public string Id { get; set; }

        public string TournmentId { get; set; }

        public string PsNumber { get; set; }

        public DateTime TransactionDate { get; set; }
    }
}
