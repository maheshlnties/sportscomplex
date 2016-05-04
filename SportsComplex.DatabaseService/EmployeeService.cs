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
    public class EmployeeService : IEmployeeService
    {
        #region Fields

        private readonly SqlDatabaseAccessor _databaseAccessor;

        #endregion

        #region Constructor

        public EmployeeService()
        {
            _databaseAccessor = new SqlDatabaseAccessor();
        }

        #endregion
        
        #region MyCharges

        public IList<ResourceCharge> GetResourceCharges(string psNumber, int selectedMonth, int selectedYear)
        {
            var badmintonResources = _databaseAccessor.GetBadmintonCharges(selectedMonth, selectedYear);
            var billiardResources = _databaseAccessor.GetBilliardCharges(selectedMonth, selectedYear);
            var list = new List<ResourceCharge>();
            foreach (var eachResource in badmintonResources)
            {
                var bookingItems =
                    eachResource.Items.Split(';')
                        .Select(eachItem => new BookingItem(eachItem))
                        .Where(x => x.BookedBy == psNumber)
                        .ToList();
                list.AddRange(bookingItems.Select(eachBooking => new ResourceCharge
                {
                    PsNumber = psNumber,
                    Name = eachBooking.EmployeeName,
                    Charges = Settings.BadmintonFee, ResourceName = "Badminton", Slot = "Slot -" + eachBooking.Item, TransactionDate = eachResource.BookDate
                })); //TODO: read charge from app config
            }

            foreach (var eachResource in billiardResources)
            {
                var bookingItems =
                    eachResource.Items.Split(';')
                        .Select(eachItem => new BookingItem(eachItem))
                        .Where(x => x.BookedBy == psNumber)
                        .ToList();
                list.AddRange(bookingItems.Select(eachBooking => new ResourceCharge
                {
                    PsNumber = psNumber,
                    Name = eachBooking.EmployeeName,
                    Charges = Settings.BilliardFee,
                    ResourceName = "Billiard",
                    Slot = "Slot -" + eachBooking.Item,
                    TransactionDate = eachResource.BookDate
                })); //TODO: read charge from app config
            }
            return list;

            //for (var i = 0; i < 10; i++)
            //{
            //    list.Add(new ResourceCharge
            //    {
            //        PsNumber = "20000" + i,
            //        Charges = 500 + i,
            //        Name = "Employee" + i,
            //        ResourceName = "Resource" + i,
            //        Slot = "Slot" + i,
            //        TransactionDate = DateTime.Today.Subtract(TimeSpan.FromDays(i))
            //    });
            //}
            //return list;
        }

        public IList<GymCharge> GetGymCharges(string psNumber, int selectedMonth, int selectedYear)
        {
            var gymList = _databaseAccessor.GetGymCharges(psNumber,selectedMonth, selectedYear);
            var gymCharges= gymList.Select(eachGym => new GymCharge
            {
                Charges = Settings.GymFee, JoinedOn = eachGym.JoinedOn, LeftOn = eachGym.LeftOn, TransactionDate = eachGym.TransactionDate, Joined = eachGym.Joined
            }).ToList();
            return gymCharges;
        }

        public IList<TournmentCharge> GetTournmentCharges(string psNumber, int selectedMonth, int selectedYear)
        {
            return _databaseAccessor.GetTournmentCharges(psNumber, selectedMonth, selectedYear);
        }

        #endregion

        #region Tournment

        public IList<Tournment> GetTournments(string psNumber)
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
            var tournments = _databaseAccessor.GetTournments();
            var tournmentBookings = _databaseAccessor.GetTournmentBookingByPsNumber(psNumber);
            foreach (var eachTournment in from eachTournment in tournments from eachBooking in tournmentBookings where eachBooking.TournmentId == eachTournment.Id select eachTournment)
            {
                eachTournment.IsEnrolled = true;
            }
            return tournments;
        }

        public bool BookTournment(string psNumber, string tournmentId)
        {
            return _databaseAccessor.BookTournment(psNumber, tournmentId);
        }
        public IList<TournmentBooking> GetTournmentBookingByPsNumber(string psNumber)
        {
            return _databaseAccessor.GetTournmentBookingByPsNumber(psNumber);
        }

        #endregion

    }
}
