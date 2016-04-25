using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsComplex.Models.Charges
{
    public class TournmentCharge : ChargeBase
    {
        public string TournmentId { get; set; }
        public string TournmentName { get; set; }
    }
}
