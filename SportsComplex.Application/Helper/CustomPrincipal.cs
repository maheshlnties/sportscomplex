using System.Linq;
using System.Security.Principal;
using SportsComplex.Models;
using SportsComplex.Utilities;

namespace SportsComplex.Application.Helper
{
    public class CustomPrincipal : PrincipalModel, IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public bool IsInRole(string role)
        {
            if (string.IsNullOrEmpty(role)) return false;

            var roles = role.Split(',');
            return
                roles.Select(eachRole => EnumHelper.TryParse<UserRoles>(eachRole))
                    .Any(result => result != UserRoles.Anonymous && result == Role);
        }

        public CustomPrincipal(string username)
        {
            Identity = new GenericIdentity(username);
        }
    }
}