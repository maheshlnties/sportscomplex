using System.Collections.Generic;
using SportsComplex.Models;
using SportsComplex.Models.Charges;

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

        IList<ResourceCharge> GetResourceCharges(int month,int year);

        IList<GymCharge> GetGymCharges(int month, int year);

        IList<TournmentCharge> GetTournmentCharges(int month, int year);
    }
}
