using System;

namespace SportsComplex.Models
{
    public class BookingItem
    {
        private const char Delimiter = '_';
        
        public BookingItem() { }

        public BookingItem(string bookingItem)
        {
            if (string.IsNullOrEmpty(bookingItem))
                throw new ArgumentException("Argument can not be empty");

            var split = bookingItem.Split(Delimiter);
            if (split.Length == 3)
            {
                Item = split[0];
                BookedBy = split[1];
                EmployeeName = split[2];
            }
        }
        
        public string Item { get; set; }

        public string BookedBy { get; set; }

        public string EmployeeName { get; set; }

        public string GetBookingItem()
        {
            return string.Format("{0}{1}{2}{3}{4}", Item, Delimiter, BookedBy,Delimiter,EmployeeName);
        }
    }
}
