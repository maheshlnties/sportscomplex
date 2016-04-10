using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using SportsComplex.Application.Filters;
using SportsComplex.Application.ViewModels;
using SportsComplex.DatabaseService.Interface;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Employee")]
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        //
        // GET: /Employee/
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

        public ActionResult Tournment()
        {
            return View(new List<TournmentViewModel>());
        }
    }
}