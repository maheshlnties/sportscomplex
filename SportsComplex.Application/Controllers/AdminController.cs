using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using SportsComplex.Application.Filters;
using SportsComplex.Application.ViewModels;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;
        private readonly IMapper _mapper;

        public AdminController(IAdminService adminService, IMapper mapper)
        {
            _adminService = adminService;
            _mapper = mapper;
        }

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
        public ActionResult DeleteNews(List<NewsViewModel> newsViewModels)
        {
            if (newsViewModels.Count == 0)
            {
                return View("ManageNews");
            }
            var listNews = new List<News>();
            foreach (var eachNews in newsViewModels)
            {
                listNews.Add(_mapper.Map<NewsViewModel, News>(eachNews));
            }
            var result = _adminService.DeleteNews(listNews);
            ViewBag.Message = result
               ? "Deleted successfully"
               : "Some problem occured while deleting. Try again later.";
            return View("ManageNews");
        }

        [HttpGet]
        public ActionResult Tournment()
        {
            //var tournments = new List<TournmentViewModel>();
            //for (var i = 0; i < 5; i++)
            //{
            //    tournments.Add(new TournmentViewModel
            //    {
            //        Name = "Tournment" + i,
            //        Fees = 50,
            //        LastDate = DateTime.Now.AddDays(i),
            //        IsEnrolled = i%2 == 0
            //    });
            //}

            var tournments = _adminService.GetTournments();
            var tournmentViewModels = new List<TournmentViewModel>();
            if (tournments != null)
            {
                foreach (var eachTournment in tournments)
                {
                    tournmentViewModels.Add(_mapper.Map<Tournment, TournmentViewModel>(eachTournment));
                }
            }
            return View(tournmentViewModels);
        }

        [HttpGet]
        [ActionName("AddTournment")]
        public ActionResult AddTournment()
        {
            return View();
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
        public ActionResult DeleteTournment(IList<TournmentViewModel> tournmentViewModels)
        {
            if (tournmentViewModels.Count == 0)
            {
                return View();
            }
            var listTournments = new List<Tournment>();
            foreach (var eachTournment in tournmentViewModels)
            {
                listTournments.Add(_mapper.Map<TournmentViewModel, Tournment>(eachTournment));
            }
            bool result = _adminService.DeleteTournments(listTournments);
            ViewBag.Message = result
               ? "Deleted successfully"
               : "Some problem occured while deleting. Try again later.";

            return View();
        }

        [HttpGet]
        public ActionResult SportsReport()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AllCharges()
        {
            var list = new List<ChargeViewModel>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new ChargeViewModel
                {
                    Name = "employee" + i,
                    PsNumber = "ps" + i,
                    Charges = 500 + i,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(i)
                });
            }
            return View(new ChargeSheetViewModel { ResourceCharges = list, GymCharges = list, TournmentCharges = list });
        }

        [HttpGet]
        public ActionResult ChargeTournment()
        {
            var list = new List<ChargeViewModel>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new ChargeViewModel
                {
                    Name = "employee" + i,
                    PsNumber = "ps" + i,
                    Charges = 500 + i,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(i)
                });
            }
            return View(new ChargeSheetViewModel { TournmentCharges = list });
        }

        [HttpGet]
        public ActionResult ChargeGym()
        {
            var list = new List<ChargeViewModel>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new ChargeViewModel
                {
                    Name = "employee" + i,
                    PsNumber = "ps" + i,
                    Charges = 500 + i,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(i)
                });
            }
            return View(new ChargeSheetViewModel { GymCharges = list });
        }

        [HttpGet]
        public ActionResult ChargeResource()
        {
            var list = new List<ChargeViewModel>();
            for (var i = 0; i < 20; i++)
            {
                list.Add(new ChargeViewModel
                {
                    Name = "employee" + i,
                    PsNumber = "ps" + i,
                    Charges = 500 + i,
                    StartDate = DateTime.Today,
                    EndDate = DateTime.Today.AddDays(i)
                });
            }
            return View(new ChargeSheetViewModel { ResourceCharges = list });
        }
    }
}