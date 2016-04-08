using System.Collections.Generic;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService
{
    public class AdminService :IAdminService
    {
        public IList<News> GetNews()
        {
            return new List<News>();
        }

        public bool AddNews(News news)
        {
            return true;
        }

        public bool DeleteNews(IList<News> news)
        {
            return true;
        }
    }
}
