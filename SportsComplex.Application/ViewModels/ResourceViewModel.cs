using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using SportsComplex.Models;

namespace SportsComplex.Application.ViewModels
{
    public class ResourceViewModel
    {
        private const string Delimiter = ","; 

        public List<string> Headers { get; set; }

        public int Rows { get; set; }

        public DateTime Date { get; set; }

        public List<BookingItem> BookedList { get; set; }

        [Display(Name = "P.S. Number*")]
        public string PsNumber { get; set; }


        public bool IsBooked(string id)
        {
            return BookedList!=null && BookedList.Any(x => x.Item == id);
        }

        public string GetElementId(string resourceType, string header)
        {
            return string.Format("{0}{1}{2}", resourceType, Delimiter, header);
        }
    }
}