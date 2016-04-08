using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using SportsComplex.Application.Filters;
using SportsComplex.Application.ViewModels;
using SportsComplex.DatabaseService.Interface;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
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
            var listNews = new List<NewsViewModel>();
            for (int i = 0; i < 5; i++)
            {
                listNews.Add(new NewsViewModel
                {
                    Content = "Wish you a very happy ugadi" + i,
                    PostedOn = DateTime.Today,
                    ExpiresOn = DateTime.Today.AddDays(2)
                });
            }
            
            return View(listNews);
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
            //var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
            //var result = await _userService.RegisterEmployee(employee).ConfigureAwait(false);
            ViewBag.Message = true
                ? "Posted successfully"
                : "Some problem occured while posting. Try again later.";
            return View(new NewsViewModel());
        }
        
        [HttpDelete]
        [ActionName("ManageNews")]
        public ActionResult DeleteNews(List<NewsViewModel> newsViewModels)
        {
            return View("ManageNews");
        }
    }
}