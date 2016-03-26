using System;
using System.Collections.Generic;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService
{
    public class ModuleService : IModuleService
    {
        private List<string> GetBadmintonHeaders()
        {
            return new List<string>
            {
                "5PM - 6PM",
                "6PM - 7PM",
                "7PM - 8PM",
                "8PM - 9PM"
            };
        }

        private List<string> GetBilliardHeaders()
        {
            return new List<string>
            {
                "5PM - 6PM",
                "6PM - 7PM",
                "7PM - 8PM",
                "8PM - 9PM"
            };
        }

        private int GetNoOfBadmintonCourts()
        {
            return 3;
        }

        private int GetNoOfBilliardCourts()
        {
            return 6;
        }

        public List<BookingItem> GetBookedBadmintonList(DateTime date)
        {
            return new List<BookingItem> { new BookingItem { Item = "Badminton 1,7PM - 8PM", BookedBy = "Mahesh" } };
        }

        public List<BookingItem> GetBookedBilliardList(DateTime date)
        {
            return new List<BookingItem> { new BookingItem { Item = "Billiard 1,7PM - 8PM", BookedBy = "Mahesh" } };
        }

        public bool BookBadmintonResource(Resource resource)
        {
            return true;
        }

        public bool BookBilliardResource(Resource resource)
        {
            return true;
        }

        public Resource GetBadmintonResource()
        {
            return new Resource
            {
                Headers = GetBadmintonHeaders(),
                Rows = GetNoOfBadmintonCourts(),
                BookedList = GetBookedBadmintonList(DateTime.Today)
            };
        }

        public Resource GetBilliardResource()
        {
            return new Resource
            {
                Headers = GetBilliardHeaders(),
                Rows = GetNoOfBilliardCourts(),
                BookedList = GetBookedBilliardList(DateTime.Today)
            };
        }
    }
}
