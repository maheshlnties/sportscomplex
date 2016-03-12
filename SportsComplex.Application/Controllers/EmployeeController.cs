using System.Web.Mvc;
using System.Web.Security;
using SportsComplex.Application.Filters;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Employee")]
    public class EmployeeController : BaseController
    {
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
    }
}