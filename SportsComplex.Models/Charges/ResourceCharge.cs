using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsComplex.Models.Charges
{
    public class ResourceCharge : ChargeBase
    {
        public string ResourceName { get; set; }

        public string Slot { get; set; }
    }
}
