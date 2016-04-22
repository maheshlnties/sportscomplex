using System;
using System.Collections.Generic;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;
using SportsComplex.Models.Charges;

namespace SportsComplex.DatabaseService
{
    public class EmployeeService : IEmployeeService
    {
        public IList<ResourceCharge> GetResourceCharges(int month, int year)
        {
            var list = new List<ResourceCharge>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new ResourceCharge
                {
                    PsNumber = "20000" + i,
                    Charges = 500 + i,
                    Name = "Employee" + i,
                    ResourceName = "Resource" + i,
                    Slot = "Slot" + i,
                    TransactionDate = DateTime.Today.Subtract(TimeSpan.FromDays(i))
                });
            }
            return list;
        }

        public IList<GymCharge> GetGymCharges(int month, int year)
        {
            var list = new List<GymCharge>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new GymCharge
                {
                    PsNumber = "20000" + i,
                    Charges = 500 + i,
                    Name = "Employee" + i,
                    JoinedOn = DateTime.Today.Subtract(TimeSpan.FromDays(i + 5)),
                    LeftOn = DateTime.Today.Subtract(TimeSpan.FromDays(i)),
                    TransactionDate = DateTime.Today.Subtract(TimeSpan.FromDays(i))
                });
            }
            return list;
        }

        public IList<TournmentCharge> GetTournmentCharges(int month, int year)
        {
            var list = new List<TournmentCharge>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new TournmentCharge
                {
                    PsNumber = "20000" + i,
                    Charges = 500 + i,
                    Name = "Employee" + i,
                    TournmentName = "Tournment" + i,
                    TransactionDate = DateTime.Today.Subtract(TimeSpan.FromDays(i))
                });
            }
            return list;
        }

        IList<ResourceCharge> IEmployeeService.GetResourceCharges(int selectedMonth, int selectedYear)
        {
            var list = new List<ResourceCharge>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new ResourceCharge
                {
                    PsNumber = "20000" + i,
                    Charges = 500 + i,
                    Name = "Employee" + i,
                    ResourceName = "Resource" + i,
                    Slot = "Slot" + i,
                    TransactionDate = DateTime.Today.Subtract(TimeSpan.FromDays(i))
                });
            }
            return list;
        }

        IList<GymCharge> IEmployeeService.GetGymCharges(int selectedMonth, int selectedYear)
        {
            throw new NotImplementedException();
        }

        IList<TournmentCharge> IEmployeeService.GetTournmentCharges(int selectedMonth, int selectedYear)
        {
            throw new NotImplementedException();
        }

        IList<Tournment> IEmployeeService.GetTournments()
        {
            var list = new List<Tournment>();
            for (var i = 0; i < 5; i++)
            {
                list.Add(new Tournment
                {
                    CreatedDate = DateTime.Now,
                    LastDate = DateTime.Now.AddDays(3),
                    Fees = 50,
                    Id = i.ToString(),
                    IsEnrolled = i % 2 == 0,
                    Name = "Tournment" + 1
                });
            }
            return list;
        }
        
        public bool BookTournment(string psNumber, string tournmentName)
        {
            return true;
        }
    }
}
