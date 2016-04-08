using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Newtonsoft.Json;
using SportsComplex.Application.ViewModels;
using SportsComplex.DatabaseService.Interface;
using SportsComplex.Models;

namespace SportsComplex.Application.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public HomeController(IUserService userService,IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            if (User != null)
            {
                switch (User.Role)
                {
                    case UserRoles.Admin:
                        return RedirectToAction("Index", "Admin");
                    case UserRoles.Employee:
                        return RedirectToAction("Index", "Employee");
                }
            }
           
            return View(new HomeViewModel
            {
                LoginViewModel = new LoginViewModel(),
                Images = GetGallery(),
                News = GetNews()
            });

        }

        private List<ImageViewModel> GetGallery()
        {
            var images = _userService.GetGalleryImages();
            return images != null
                ? images.Select(eachImages => new ImageViewModel
                {
                    Name = eachImages.Name,
                    EncodedImage = eachImages.EncodedImage,
                    UploadedOn = eachImages.UploadedOn
                }).ToList()
                : new List<ImageViewModel>();
        }

        private List<NewsViewModel> GetNews()
        {
            var news = _userService.GetNews();
            return news != null
                ? news.Select(eachNews => _mapper.Map<News, NewsViewModel>(eachNews)).ToList()
                : new List<NewsViewModel>();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        [ActionName("Register")]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Register")]
        public async Task<ActionResult> RegisterUser(EmployeeViewModel employeeViewModel)
        {
            if (!ModelState.IsValid)
                return View(employeeViewModel);

            if (employeeViewModel.ConfirmPassword != employeeViewModel.Password)
            {
                ViewBag.Message = "Password and Confirm Password fields doesn't match";
                return View(employeeViewModel);
            }
            var employee = _mapper.Map<EmployeeViewModel, Employee>(employeeViewModel);
            var result =await _userService.RegisterEmployee(employee).ConfigureAwait(false);
            ViewBag.Message = result
                ? "Registered successfully"
                : "Some problem occured while registering. Try again later.";
            return View(new EmployeeViewModel());
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<ActionResult> Login(HomeViewModel homeVewModel)
        {
            if (!ModelState.IsValid)
                return View("Index");

            var loginViewModel = homeVewModel.LoginViewModel;
            var user = await _userService.GetUser(loginViewModel.Username, loginViewModel.Password);
            if (user != null)
            {
                var principalModel = new PrincipalModel
                {
                    UserId = user.PsNumber,
                    Name = user.Name,
                    Role = user.UserRole
                };

                var userData = JsonConvert.SerializeObject(principalModel);
                var authTicket = new FormsAuthenticationTicket(
                    1,
                    user.Name,
                    DateTime.Now,
                    DateTime.Now.AddMinutes(15),
                    loginViewModel.RememberMe,
                    userData);

                var encryptTicket = FormsAuthentication.Encrypt(authTicket);
                var httpCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptTicket);
                Response.Cookies.Add(httpCookie);

                switch (principalModel.Role)
                {
                    case UserRoles.Admin:
                        return RedirectToAction("Index", "Admin");
                    case UserRoles.Employee:
                        return RedirectToAction("Index", "Employee");
                    case UserRoles.Anonymous:
                        return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Error = "Incorrect username and/or password";
            return View("Index",homeVewModel);
        }
    }
}