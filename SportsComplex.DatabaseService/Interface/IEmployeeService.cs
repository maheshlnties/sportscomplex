using System.Collections.Generic;
using SportsComplex.Models;
using SportsComplex.Models.Charges;

namespace SportsComplex.DatabaseService.Interface
{
    public interface IEmployeeService
    {
        IList<ResourceCharge> GetResourceCharges(string psNumber,int selectedMonth, int selectedYear);

        IList<GymCharge> GetGymCharges(string psNumber,int selectedMonth, int selectedYear);

        IList<TournmentCharge> GetTournmentCharges(string psNumber,int selectedMonth, int selectedYear);

        IList<Tournment> GetTournments(string psNumber);

        IList<TournmentBooking> GetTournmentBookingByPsNumber(string psNumber);

        bool BookTournment(string psNumber, string tournmentId);
    }
}