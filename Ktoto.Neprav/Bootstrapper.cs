using System.Configuration;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Domain;
using Ktoto.Neprav.Utils;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace Ktoto.Neprav
{
    public static class Bootstrapper
    {
        public static IUnityContainer Initialize(WebConfig config)
        {
            var container = BuildUnityContainer(config);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer(WebConfig config)
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container, config);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container, WebConfig config)
        {
	        var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
	        var factory = NhDalFactory.Create(cs, config.Expose);
	        container.RegisterInstance<IDalFactory>(factory);
            container.RegisterType<IDal>(new InjectionFactory(_ => _.Resolve<IDalFactory>().Create()));
            container.RegisterType<IdentityInfo>(PerRequest());
            container.RegisterType<IViewPageActivator, MyViewActivator>(PerRequest());
            RegisterConnections(container);
        }

        private static void RegisterConnections(IUnityContainer container)
        {
        }

        private static LifetimeManager PerRequest()
        {
            return new HierarchicalLifetimeManager();
        }
    }
}