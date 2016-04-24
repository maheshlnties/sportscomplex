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
    [UserAuthorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        #region Fields

        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

        #endregion

        #region Index And Logout

        [HttpGet]
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

        #region News

        public ActionResult ManageNews()
        {
            var listNewsViewModel = new List<NewsViewModel>();
            var newsList = _adminService.GetNews();

            if (newsList != null)
                listNewsViewModel.AddRange(newsList.Select(eachNews => _mapper.Map<News, NewsViewModel>(eachNews)));

            return View(listNewsViewModel);
        }

        [HttpGet]
        [ActionName("AddNews")]
        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddNews")]
        public ActionResult AddNewsPost(NewsViewModel newsViewModel)
        {
            if (!ModelState.IsValid)
                return View(newsViewModel);

            if (newsViewModel.ExpiresOn < newsViewModel.PostedOn)
            {
                ViewBag.Message = "Expire date can not be before than posting date";
                return View(newsViewModel);
            }

            var news = _mapper.Map<NewsViewModel, News>(newsViewModel);
            var result = _adminService.AddNews(news);
            ViewBag.Message = result
                ? "Posted successfully"
                : "Some problem occured while posting. Try again later.";
            return View(new NewsViewModel());
        }

        [HttpDelete]
        [ActionName("ManageNews")]
        public ActionResult DeleteNews(List<string> selectedList)
        {
            if (selectedList != null && selectedList.Count == 0)
            {
                return View();
            }
            var result = _adminService.DeleteNews(selectedList);

            var listNewsViewModel = new List<NewsViewModel>();
            var newsList = _adminService.GetNews();

            if (newsList != null)
                listNewsViewModel.AddRange(newsList.Select(eachNews => _mapper.Map<News, NewsViewModel>(eachNews)));

            return View(listNewsViewModel);
        }

        #endregion

        #region Tournment

        [HttpGet]
        public ActionResult Tournment()
        {
            var tournments = _adminService.GetTournments();
            var tournmentViewModels = new List<TournmentViewModel>();
            if (tournments != null)
            {
                tournmentViewModels.AddRange(
                    tournments.Select(eachTournment => _mapper.Map<Tournment, TournmentViewModel>(eachTournment)));
            }
            return View(tournmentViewModels);
        }

        [HttpGet]
        [ActionName("AddTournment")]
        public ActionResult AddTournment()
        {
            return View(new TournmentViewModel());
        }

        [HttpPost]
        [ActionName("AddTournment")]
        public ActionResult AddTournmentPost(TournmentViewModel tournmentViewModel)
        {
            if (!ModelState.IsValid)
                return View(tournmentViewModel);

            var tournment = _mapper.Map<TournmentViewModel, Tournment>(tournmentViewModel);
            bool result = _adminService.AddTournment(tournment);
            ViewBag.Message = result
                ? "Added new tournment successfully"
                : "Some problem occured while creating new tournment. Try again later.";
            return View(new TournmentViewModel());
        }

        [HttpDelete]
        [ActionName("Tournment")]
        public ActionResult DeleteTournment(IList<string> selectedList)
        {
            if (selectedList != null && selectedList.Count == 0)
            {
                return View();
            }
            var result = _adminService.DeleteTournments(selectedList);
            
            var tournments = _adminService.GetTournments();
            var tournmentViewModels = new List<TournmentViewModel>();
            if (tournments != null)
            {
                tournmentViewModels.AddRange(
                    tournments.Select(eachTournment => _mapper.Map<Tournment, TournmentViewModel>(eachTournment)));
            }
            return View(tournmentViewModels);
        }

        #endregion

        #region Sports Report

        [HttpGet]
        public ActionResult SportsReport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AllCharges()
        {
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_adminService.GetResourceCharges(1, 1));
            var gymCharges = ModelConverters.FromGymChargesList(_adminService.GetGymCharges(1, 1));
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_adminService.GetTournmentCharges(1, 1));
            return
                View(new ChargeSheetViewModel
                {
                    ResourceCharges = resourceCharges,
                    GymCharges = gymCharges,
                    TournmentCharges = tournmentCharges
                });
        }

        [ActionName("AllCharges")]
        [HttpPost]
        public ActionResult AllChargesPost(int selectedMonth, int selectedYear)
        {
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_adminService.GetResourceCharges(selectedMonth, selectedYear));
            var gymCharges = ModelConverters.FromGymChargesList(_adminService.GetGymCharges(selectedMonth, selectedYear));
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_adminService.GetTournmentCharges(selectedMonth, selectedYear));
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

        [HttpGet]
        public ActionResult ChargeTournment()
        {
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_adminService.GetTournmentCharges(1, 1));
            return
                View(new ChargeSheetViewModel
                {
                    TournmentCharges = tournmentCharges
                });
        }

        [ActionName("ChargeTournment")]
        [HttpPost]
        public ActionResult ChargeTournmentPost(int selectedMonth, int selectedYear)
        {
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_adminService.GetTournmentCharges(selectedMonth, selectedYear));
            return
                View(new ChargeSheetViewModel
                {
                    SelectedMonth = selectedMonth,
                    SelectedYear = selectedYear,
                    TournmentCharges = tournmentCharges
                });
        }

        [HttpGet]
        public ActionResult ChargeGym()
        {
            var gymCharges = ModelConverters.FromGymChargesList(_adminService.GetGymCharges(1, 1));
            return
                View(new ChargeSheetViewModel
                {
                    GymCharges = gymCharges
                });
        }

        [ActionName("ChargeGym")]
        [HttpPost]
        public ActionResult ChargeGymPost(int selectedMonth, int selectedYear)
        {
            var gymCharges = ModelConverters.FromGymChargesList(_adminService.GetGymCharges(selectedMonth, selectedYear));
            return
                View(new ChargeSheetViewModel
                {
                    SelectedMonth = selectedMonth,
                    SelectedYear = selectedYear,
                    GymCharges = gymCharges
                });
        }

        [HttpGet]
        public ActionResult ChargeResource()
        {
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_adminService.GetResourceCharges(1, 1));
            return
                View(new ChargeSheetViewModel
                {
                    ResourceCharges = resourceCharges
                });
        }

        [ActionName("ChargeResource")]
        [HttpPost]
        public ActionResult ChargeResourcePost(int selectedMonth, int selectedYear)
        {
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_adminService.GetResourceCharges(selectedMonth, selectedYear));
            return
                View(new ChargeSheetViewModel
                {
                    SelectedMonth = selectedMonth,
                    SelectedYear = selectedYear,
                    ResourceCharges = resourceCharges
                });
        }

        public CsvActionResult<ChargeViewModel> ExportAllCharges()
        {
            var list = new List<ChargeViewModel>();
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_adminService.GetResourceCharges(1, 1));
            var gymCharges = ModelConverters.FromGymChargesList(_adminService.GetGymCharges(1, 1));
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_adminService.GetTournmentCharges(1, 1));
            list.AddRange(resourceCharges);
            list.AddRange(gymCharges);
            list.AddRange(tournmentCharges);
            return new CsvActionResult<ChargeViewModel>(list) {FileDownloadName = "AllCharges.csv"};
        }

        public CsvActionResult<ChargeViewModel> ExportGymCharges()
        {
            var list = new List<ChargeViewModel>();
            var gymCharges = ModelConverters.FromGymChargesList(_adminService.GetGymCharges(1, 1));
            list.AddRange(gymCharges);
            return new CsvActionResult<ChargeViewModel>(list) {FileDownloadName = "GymCharges.csv"};
        }

        public CsvActionResult<ChargeViewModel> ExportResourceCharges()
        {
            var list = new List<ChargeViewModel>();
            var resourceCharges =
                ModelConverters.FromResourceChargesList(_adminService.GetResourceCharges(1, 1));
            list.AddRange(resourceCharges);
            return new CsvActionResult<ChargeViewModel>(list) {FileDownloadName = "ResourceCharges.csv"};
        }

        public CsvActionResult<ChargeViewModel> ExportTournmentCharges()
        {
            var list = new List<ChargeViewModel>();
            var tournmentCharges =
                ModelConverters.FromTournmentChargesList(_adminService.GetTournmentCharges(1, 1));
            list.AddRange(tournmentCharges);
            return new CsvActionResult<ChargeViewModel>(list) {FileDownloadName = "TournmentCharges.csv"};
        }

        #endregion
    }
}