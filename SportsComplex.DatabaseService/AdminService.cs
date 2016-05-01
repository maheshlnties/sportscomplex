using System;
using System.Collections.Generic;
using System.Linq;
using SportsComplex.Database;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;
using SportsComplex.Models.Charges;
using SportsComplex.Utilities;

namespace SportsComplex.DatabaseService
{
    public class AdminService :IAdminService
    {
        private readonly SqlDatabaseAccessor _databaseAccessor;

        public AdminService()
        {
            _databaseAccessor = new SqlDatabaseAccessor();
        }

        public IList<News> GetNews()
        {
            //var listNews = new List<News>();
            //for (var i = 0; i < 5; i++)
            //{
            //    listNews.Add(new News
            //    {
            //        Id = i.ToString(),
            //        Content = "Wish you a very happy ugadi" + i,
            //        PostedOn = DateTime.Today,
            //        ExpiresOn = DateTime.Today.AddDays(2),
            //        Highlight = i%2==0
            //    });
            //}
            //return listNews;
            return _databaseAccessor.GetNews();
        }

        public bool AddNews(News news)
        {
            return _databaseAccessor.AddNews(news);
        }

        public bool DeleteNews(IList<string> news)
        {
            //return true;
            return _databaseAccessor.DeleteNews(news);
        }

        public IList<Tournment> GetTournments()
        {
            //var list = new List<Tournment>();
            //for (var i = 0; i < 5; i++)
            //{
            //    list.Add(new Tournment
            //    {
            //        CreatedDate = DateTime.Now,
            //        LastDate = DateTime.Now.AddDays(3),
            //        Fees = 50,
            //        Id = i.ToString(),
            //        IsEnrolled = i%2 == 0,
            //        Name = "Tournment" + 1
            //    });
            //}
            //return list;
            return _databaseAccessor.GetTournments();
        }

        public bool AddTournment(Tournment tournment)
        {
            tournment.CreatedDate = DateTime.Now;
            return _databaseAccessor.AddTournment(tournment);
        }

        public bool DeleteTournments(IList<string> listTournments)
        {
            return _databaseAccessor.DeleteTournments(listTournments);
            //return true;
        }

        public IList<ResourceCharge> GetResourceCharges(int selectedMonth, int selectedYear)
        {
            var badmintonResources = _databaseAccessor.GetBadmintonCharges(selectedMonth, selectedYear);
            var billiardResources = _databaseAccessor.GetBadmintonCharges(selectedMonth, selectedYear);
            var list = new List<ResourceCharge>();
            foreach (var eachResource in badmintonResources)
            {
                var bookingItems =
                    eachResource.Items.Split(';')
                        .Select(eachItem => new BookingItem(eachItem))
                        .ToList();
                list.AddRange(bookingItems.Select(eachBooking => new ResourceCharge
                {
                    PsNumber = eachBooking.BookedBy,
                    Name = eachBooking.EmployeeName,
                    Charges = Settings.BadmintonFee,
                    ResourceName = "Badminton",
                    Slot = "Slot -" + eachBooking.Item,
                    TransactionDate = eachResource.BookDate
                })); //TODO: read charge from app config
            }

            foreach (var eachResource in billiardResources)
            {
                var bookingItems =
                    eachResource.Items.Split(';')
                        .Select(eachItem => new BookingItem(eachItem))
                        .ToList();
                list.AddRange(bookingItems.Select(eachBooking => new ResourceCharge
                {
                    PsNumber = eachBooking.BookedBy,
                    Name = eachBooking.EmployeeName,
                    Charges = Settings.BilliardFee,
                    ResourceName = "Billiard",
                    Slot = "Slot -" + eachBooking.Item,
                    TransactionDate = eachResource.BookDate
                })); //TODO: read charge from app config
            }
            return list;

            //var list= new List<ResourceCharge>();
            //for (var i = 0; i < 10; i++)
            //{
            //    list.Add(new ResourceCharge
            //    {
            //        PsNumber = "20000"+i,
            //        Charges = 500 +i,
            //        Name = "Employee"+i,
            //        ResourceName = "Resource"+i,
            //        Slot = "Slot"+i,
            //        TransactionDate = DateTime.Today.Subtract(TimeSpan.FromDays(i))
            //    });
            //}
            //return list;
        }

        public IList<GymCharge> GetGymCharges(int selectedMonth, int selectedYear)
        {
            return _databaseAccessor.GetGymCharges(selectedMonth, selectedYear);
        }

        public IList<TournmentCharge> GetTournmentCharges(int selectedMonth, int selectedYear)
        {
            return _databaseAccessor.GetTournmentCharges(selectedMonth, selectedYear);
            //var list = new List<TournmentCharge>();
            //for (var i = 0; i < 10; i++)
            //{
            //    list.Add(new TournmentCharge
            //    {
            //        PsNumber = "20000" + i,
            //        Charges = 500 + i,
            //        Name = "Employee" + i,
            //        TournmentName = "Tournment" + i,
            //        TransactionDate = DateTime.Today.Subtract(TimeSpan.FromDays(i))
            //    });
            //}
            //return list;
        }
    }
}
