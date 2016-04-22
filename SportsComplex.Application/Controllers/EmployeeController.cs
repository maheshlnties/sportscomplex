using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using SportsComplex.Application.Filters;
using SportsComplex.Application.Helper;
using SportsComplex.Application.ViewModels;
using SportsComplex.DatabaseService.Interface;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Employee")]
    public class EmployeeController : BaseController
    {
        #region Fields

        private readonly IEmployeeService _employeeService;

        #endregion

        #region Constructor

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        #endregion

        #region Index And Logout

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region Tournment

        public ActionResult Tournment()
        {
            return View(new List<TournmentViewModel>());
        }

        #endregion

        #region MyCharges

        [HttpGet]
        public ActionResult MyCharges()
        {
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_employeeService.GetResourceCharges(1, 1));
            var gymCharges = ModelConverters.FromGymChargesList(_employeeService.GetGymCharges(1, 1));
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_employeeService.GetTournmentCharges(1, 1));
            return
                View(new ChargeSheetViewModel
                {
                    ResourceCharges = resourceCharges,
                    GymCharges = gymCharges,
                    TournmentCharges = tournmentCharges
                });
        }

        [ActionName("MyCharges")]
        [HttpPost]
        public ActionResult MyChargesPost(int selectedMonth, int selectedYear)
        {
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_employeeService.GetResourceCharges(selectedMonth, selectedYear));
            var gymCharges =
                ModelConverters.FromGymChargesList(_employeeService.GetGymCharges(selectedMonth, selectedYear));
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_employeeService.GetTournmentCharges(selectedMonth,
                    selectedYear));
            return
                View(new ChargeSheetViewModel
                {
                    SelectedMonth = selectedMonth,
                    SelectedYear = selectedYear,
                    ResourceCharges = resourceCharges,
                    GymCharges = gymCharges,
                    TournmentCharges = tournmentCharges
                });
        }

        public CsvActionResult<ChargeViewModel> ExportAllCharges()
        {
            var list = new List<ChargeViewModel>();
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_employeeService.GetResourceCharges(1, 1));
            var gymCharges = ModelConverters.FromGymChargesList(_employeeService.GetGymCharges(1, 1));
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_employeeService.GetTournmentCharges(1, 1));
            list.AddRange(resourceCharges);
            list.AddRange(gymCharges);
            list.AddRange(tournmentCharges);
            return new CsvActionResult<ChargeViewModel>(list) {FileDownloadName = "MyCharges.csv"};
        }

        #endregion
    }
}