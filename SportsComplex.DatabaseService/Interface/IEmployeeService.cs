using System.Collections.Generic;

namespace SportsComplex.DatabaseService.Interface
{
    public interface IEmployeeService
    {
        IList<Models.Charges.ResourceCharge> GetResourceCharges(int selectedMonth, int selectedYear);

        IList<Models.Charges.GymCharge> GetGymCharges(int selectedMonth, int selectedYear);

        IList<Models.Charges.TournmentCharge> GetTournmentCharges(int selectedMonth, int selectedYear);
    }
}