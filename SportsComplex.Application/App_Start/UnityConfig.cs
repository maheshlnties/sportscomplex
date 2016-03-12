using System.Web.Mvc;
using AutoMapper;
using Microsoft.Practices.Unity;
using SportsComplex.DatabaseService;
using SportsComplex.DatabaseService.Interface;
using Unity.Mvc5;

namespace SportsComplex.Application
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAdminService, AdminService>();
            container.RegisterType<IEmployeeService, IEmployeeService>();
            container.RegisterInstance(typeof(IMapper), MapperConfig.RegisterMappers());
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}