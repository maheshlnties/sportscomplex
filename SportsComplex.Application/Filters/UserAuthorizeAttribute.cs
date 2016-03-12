using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using SportsComplex.Application.Helper;

namespace SportsComplex.Application.Filters
{
    public class UserAuthorizeAttribute: AuthorizeAttribute
    {
        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (!filterContext.HttpContext.Request.IsAuthenticated || string.IsNullOrEmpty(Roles) || CurrentUser == null ||
                !CurrentUser.IsInRole(Roles))
            {
                filterContext.Result = RedirectToLoginPage();
            }
        }

        private ActionResult RedirectToLoginPage()
        {
            return new RedirectToRouteResult(new
                RouteValueDictionary(new { controller = "Home", action = "Index" }));
        }
    }
}