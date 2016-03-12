using System.Security.Principal;
using SportsComplex.Models;
using SportsComplex.Utilities;

namespace SportsComplex.Application.Helper
{
    public class CustomPrincipal : PrincipalModel,IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            var result = EnumHelper.TryParse<UserRoles>(role);
            return result != UserRoles.Anonymous && result == Role;
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}