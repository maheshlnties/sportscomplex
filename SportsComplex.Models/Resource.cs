using System;
using System.Collections.Generic;

namespace SportsComplex.Models
{
    public class Resource
    {
        public List<string> Headers { get; set; }

        public int Rows { get; set; }

        public DateTime Date { get; set; }

        public List<BookingItem> BookedList { get; set; }

        public List<BookingItem> OthersBookedList { get; set; }
    }
}
