using System.Collections.Generic;
using SportsComplex.Models;

namespace SportsComplex.DatabaseService.Interface
{
    public interface IAdminService
    {
        IList<News> GetNews();

        bool AddNews(News news);

        bool DeleteNews(IList<News> news);

        IList<Tournment> GetTournments();

        bool AddTournment(Tournment tournment);

        bool DeleteTournments(List<Tournment> listTournments);
    }
}
