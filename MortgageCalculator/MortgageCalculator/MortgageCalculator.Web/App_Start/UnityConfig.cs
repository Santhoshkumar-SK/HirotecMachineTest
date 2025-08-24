using MortgageCalculator.Bll.Services;
using MortgageCalculator.Dll.Data;
using MortgageCalculator.Dll.Repos;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace MortgageCalculator.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

			// register all your components with the container here
			// it is NOT necessary to register your controllers

			// e.g. container.RegisterType<ITestService, TestService>();
			container.RegisterType<MortgageDataContext>();
			container.RegisterType<IMortgageRepo, MortgageRepo>();
			container.RegisterType<IMortgageBlService, MortgageBLService>();		

			DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}