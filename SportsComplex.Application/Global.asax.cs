using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using SportsComplex.Application.Helper;
using SportsComplex.Models;

namespace SportsComplex.Application
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            UnityConfig.RegisterComponents();
        }

        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || string.IsNullOrEmpty(authCookie.Value)) return;
            var authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            if (authTicket == null) return;
            var principalModel = JsonConvert.DeserializeObject<PrincipalModel>(authTicket.UserData);
            var newUser = new CustomPrincipal(authTicket.Name)
            {
                PsNumber = principalModel.PsNumber,
                Name = principalModel.Name,
                Role = principalModel.Role
            };

            HttpContext.Current.User = newUser;
        }
    }
}
