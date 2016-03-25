using System.Web.Mvc;
using SportsComplex.Application.Filters;

namespace SportsComplex.Application.Controllers
{
    [UserAuthorize(Roles = "Admin , Employee")]
    public class ModuleController : Controller
    {
        //
        // GET: /Module/
        public ActionResult ResourceBooking()
        {
            return View();
        }

        //
        // GET: /Module/
        public ActionResult Badminton()
        {
            return View();
        }


        //
        // GET: /Module/
        public ActionResult Billiards()
        {
            return View();
        }
	}
}