using System.Web.Mvc;
using SportsComplex.Application.Helper;

namespace SportsComplex.Application.Controllers
{
    public class BaseController : Controller
    {
        protected new virtual CustomPrincipal User
        {
            get { return HttpContext.User as CustomPrincipal; }
        }
	}
}