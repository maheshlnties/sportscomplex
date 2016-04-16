using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsComplex.Models.Charges
{
    public abstract class ChargeBase
    {
        public double Charges { get; set; }

        public DateTime TransactionDate { get; set; }

        public string Name{ get; set; }

        public string PsNumber{ get; set; }
    }
}
