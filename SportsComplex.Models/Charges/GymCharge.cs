using System;

namespace SportsComplex.Models.Charges
{
    public class GymCharge : ChargeBase
    {
        public bool Joined { get; set; }

        public DateTime? LeftOn { get; set; }

        public DateTime? JoinedOn { get; set; }
    }
}
