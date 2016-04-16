using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsComplex.Models.Charges
{
    public class GymCharge : ChargeBase
    {
        public DateTime LeftOn { get; set; }

        public DateTime JoinedOn { get; set; }
    }
}
