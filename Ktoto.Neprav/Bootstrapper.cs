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
        public static IUnityContainer Initialize()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();    
            RegisterTypes(container);

            return container;
        }

        private static void RegisterTypes(IUnityContainer container)
        {
            var factory = NhDalFactory.Create();
            container.RegisterType<IDal>(new InjectionFactory(_ => factory.Create()));
            container.RegisterType<IdentityInfo>(PerRequest());
            container.RegisterType<IViewPageActivator, MyViewActivator>(PerRequest());
            RegisterConnections(container);
        }

        private static void RegisterConnections(IUnityContainer container)
        {
            container.RegisterInstance(new OneToMany<Theme, Comment>(_ => _.Comments, null));
        }

        private static LifetimeManager PerRequest()
        {
            return new HierarchicalLifetimeManager();
        }
    }
}