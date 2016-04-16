using System;
using System.Collections.Generic;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService
{
    public class AdminService :IAdminService
    {
        public IList<News> GetNews()
        {
            var listNews = new List<News>();
            for (var i = 0; i < 5; i++)
            {
                listNews.Add(new News
                {
                    Content = "Wish you a very happy ugadi" + i,
                    PostedOn = DateTime.Today,
                    ExpiresOn = DateTime.Today.AddDays(2),
                    Highlight = i%2==0
                });
            }
            return listNews;
        }

        public bool AddNews(News news)
        {
            return true;
        }

        public bool DeleteNews(IList<News> news)
        {
            return true;
        }
        
        public IList<Tournment> GetTournments()
        {
            throw new NotImplementedException();
        }

        public bool AddTournment(Tournment tournment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTournments(List<Tournment> listTournments)
        {
            throw new NotImplementedException();
        }
    }
}
