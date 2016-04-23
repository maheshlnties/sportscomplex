using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using SportsComplex.Application.Filters;
using SportsComplex.Application.Helper;
using SportsComplex.Application.ViewModels;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Employee")]
    public class EmployeeController : BaseController
    {
        #region Fields

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public EmployeeController(IEmployeeService employeeService, IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper = mapper;
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

        [HttpGet]
        public ActionResult Tournment()
        {
            var tournments = _employeeService.GetTournments();
            var tournmentViewModels = new List<TournmentViewModel>();
            if (tournments != null)
            {
                tournmentViewModels.AddRange(
                    tournments.Select(eachTournment => _mapper.Map<Tournment, TournmentViewModel>(eachTournment)));
            }
            return View(tournmentViewModels);
        }

        [ActionName("Tournment")]
        [HttpPost]
        public ActionResult TournmentPost(string tournment)
        {
            var result = _employeeService.BookTournment(User.PsNumber, "tournment");
            var tournments = _employeeService.GetTournments();
            var tournmentViewModels = new List<TournmentViewModel>();
            if (tournments != null)
            {
                tournmentViewModels.AddRange(
                    tournments.Select(eachTournment => _mapper.Map<Tournment, TournmentViewModel>(eachTournment)));
            }
            return View(tournmentViewModels);
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
        public ActionResult MyChargesPost(ChargeSheetViewModel chargeSheetViewModel)
        {
            if(!ModelState.IsValid)
                return View(chargeSheetViewModel);

            var resourceCharges = 
                ModelConverters.FromResourceChargesList(_employeeService.GetResourceCharges(chargeSheetViewModel.SelectedMonth, chargeSheetViewModel.SelectedYear));
            var gymCharges =
                ModelConverters.FromGymChargesList(_employeeService.GetGymCharges(chargeSheetViewModel.SelectedMonth, chargeSheetViewModel.SelectedYear));
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_employeeService.GetTournmentCharges(chargeSheetViewModel.SelectedMonth, chargeSheetViewModel.SelectedYear));
            return
                View(new ChargeSheetViewModel
                {
                    SelectedMonth = chargeSheetViewModel.SelectedMonth,
                    SelectedYear = chargeSheetViewModel.SelectedYear,
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