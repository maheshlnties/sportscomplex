using System;

namespace SportsComplex.Models
{
    public class Gym
    {
        public string Id { get; set; }

        public string PsNumber { get; set; }

        public DateTime TransactionDate { get; set; }

        public bool Joined { get; set; }

        public DateTime? JoinedOn { get; set; }

        public DateTime? LeftOn { get; set; }
    }
}
