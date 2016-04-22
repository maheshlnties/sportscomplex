using System.Collections.Generic;
using SportsComplex.Models;
using SportsComplex.Models.Charges;

namespace SportsComplex.DatabaseService.Interface
{
    public interface IEmployeeService
    {
        IList<ResourceCharge> GetResourceCharges(int selectedMonth, int selectedYear);

        IList<GymCharge> GetGymCharges(int selectedMonth, int selectedYear);

        IList<TournmentCharge> GetTournmentCharges(int selectedMonth, int selectedYear);

        IList<Tournment> GetTournments();

        bool BookTournment(string psNumber, string tournmentName);
    }
}