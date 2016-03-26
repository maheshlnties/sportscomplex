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
            _resourceSettings = _databaseAccessor.GetResourceSettings();
        }

        private List<string> GetBadmintonHeaders()
        {
            var headers= _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.BadmintonHeaders);
            return headers!=null ? headers.Value.Split(';').ToList() : new List<string>();
        }

        private List<string> GetBilliardHeaders()
        {
            var headers = _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.BilliardHeaders);
            return headers != null ? headers.Value.Split(';').ToList() : new List<string>();
        }

        private int GetNoOfBadmintonCourts()
        {
            var headers = _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.NoOfBadmintonCourt);
            var value = 0;
            if (headers != null)
                int.TryParse(headers.Value, out value);
            return value;
        }

        private int GetNoOfBilliardCourts()
        {
            var headers = _resourceSettings.FirstOrDefault(x => x.Name == ResourceSettingKeys.NoOfBilliarCourt);
            var value = 0;
            if (headers != null)
                int.TryParse(headers.Value, out value);
            return value;
        }

        public List<BookingItem> GetBookedBadmintonList(DateTime date)
        {
            var bookedList = _databaseAccessor.GetBookedBadmintonList(date);
            return bookedList == null
                ? new List<BookingItem>()
                : bookedList.Items.Split(';').Select(eachItem => new BookingItem(eachItem)).ToList();
        }

        public List<BookingItem> GetBookedBilliardList(DateTime date)
        {
            var bookedList = _databaseAccessor.GetBookedBilliardList(date);
            return bookedList == null
                ? new List<BookingItem>()
                : bookedList.Items.Split(';').Select(eachItem => new BookingItem(eachItem)).ToList();
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
