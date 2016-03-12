using System.Web.Mvc;
using System.Web.Security;
using SportsComplex.Application.Filters;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Admin")]
    public class AdminController : BaseController
    {
        //
        // GET: /Admin/
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