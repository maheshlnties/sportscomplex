using System;
using System.Collections.Generic;
using System.Linq;
using SportsComplex.Database;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;
using SportsComplex.Models.Database;

namespace SportsComplex.DatabaseService
{
    public class ModuleService : IModuleService
    {
        private readonly SqlDatabaseAccessor _databaseAccessor;
        private readonly List<ResourceSettings> _resourceSettings;

        public ModuleService()
        {
            _databaseAccessor = new SqlDatabaseAccessor();
            //_resourceSettings = _databaseAccessor.GetResourceSettings();
            _resourceSettings = new List<ResourceSettings>()
            {
                new ResourceSettings
                {
                    Name = ResourceSettingKeys.BadmintonHeaders,
                    Value = "5PM - 6PM;6PM - 7PM;7PM - 8PM;8PM - 9PM;"
                },
                new ResourceSettings
                {
                    Name = ResourceSettingKeys.BilliardHeaders,
                    Value = "5PM - 6PM;6PM - 7PM;7PM - 8PM;8PM - 9PM;"
                },
                new ResourceSettings
                {
                    Name = ResourceSettingKeys.NoOfBadmintonCourt,
                    Value = "3"
                },
                new ResourceSettings
                {
                    Name = ResourceSettingKeys.NoOfBilliarCourt,
                    Value = "6"
                }
            };
        }

        private List<string> GetBadmintonHeaders()
        {
            //var headers= _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.BadmintonHeaders);
            //return headers!=null ? headers.Value.Split(';').ToList() : new List<string>();
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
            //var headers = _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.BilliardHeaders);
            //return headers != null ? headers.Value.Split(';').ToList() : new List<string>();
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
            //var headers = _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.NoOfBadmintonCourt);
            //var value = 0;
            //if (headers != null)
            //    int.TryParse(headers.Value, out value);
            //return value;
            return 3;
        }

        private int GetNoOfBilliardCourts()
        {
            //var headers = _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.NoOfBilliarCourt);
            //var value = 0;
            //if (headers != null)
            //    int.TryParse(headers.Value, out value);
            //return value;
            return 6;
        }

        public List<BookingItem> GetBookedBadmintonList(DateTime date)
        {
            //var bookedList = _databaseAccessor.GetBookedBadmintonList(date);
            //return bookedList == null
            //    ? new List<BookingItem>()
            //    : bookedList.Items.Split(';').Select(eachItem => new BookingItem(eachItem)).ToList();

            return new List<BookingItem> { new BookingItem { Item = "Badminton 1,7PM - 8PM", BookedBy = "Mahesh" } };
        }

        public List<BookingItem> GetBookedBilliardList(DateTime date)
        {
            //var bookedList = _databaseAccessor.GetBookedBilliardList(date);
            //return bookedList == null
            //    ? new List<BookingItem>()
            //    : bookedList.Items.Split(';').Select(eachItem => new BookingItem(eachItem)).ToList();

            return new List<BookingItem> { new BookingItem { Item = "Billiard 1,7PM - 8PM", BookedBy = "Mahesh" } };
        }
        
        public bool BookBadmintonResource(Resource resource)
        {
            var resourceBookModel = new ResourceBookModel
            {
                BookDate = resource.Date,
                Items = string.Join(";", resource.BookedList.Select(x=>x.GetBookingItem()))
                
            };
            return _databaseAccessor.BookBadmintonResource(resourceBookModel);
        }

        public bool BookBilliardResource(Resource resource)
        {
            var resourceBookModel = new ResourceBookModel
            {
                BookDate = resource.Date,
                Items = string.Join(";", resource.BookedList.Select(x => x.GetBookingItem()))

            };
            return _databaseAccessor.BookBilliardResource(resourceBookModel);
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
