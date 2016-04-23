﻿using System;
using System.Collections.Generic;
using SportsComplex.Database;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;
using SportsComplex.Models.Charges;

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

        public IList<ResourceCharge> GetResourceCharges(int month, int year)
        {
            var list= new List<ResourceCharge>();
            for (var i = 0; i < 10; i++)
            {
                list.Add(new ResourceCharge
                {
                    PsNumber = "20000"+i,
                    Charges = 500 +i,
                    Name = "Employee"+i,
                    ResourceName = "Resource"+i,
                    Slot = "Slot"+i,
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
                    JoinedOn = DateTime.Today.Subtract(TimeSpan.FromDays(i+5)),
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
    }
}
