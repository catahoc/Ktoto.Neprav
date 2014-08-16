using System.Configuration;
using System.Linq;
using System.Web.Mvc;
using Ktoto.Neprav;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Utils;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(UnityWebActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(UnityWebActivator), "Shutdown")]

namespace Ktoto.Neprav
{
    /// <summary>Provides the bootstrapping for integrating Unity with ASP.NET MVC.</summary>
    public static class UnityWebActivator
    {
	    private static UnityContainer _container;

        /// <summary>Integrates Unity when the application starts.</summary>
        public static void Start() 
        {
			_container = new UnityContainer();

			BootstrapServices();

			FilterProviders.Providers.Remove(FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
			FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(_container));

			DependencyResolver.SetResolver(new UnityDependencyResolver(_container));

            DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
        }

	    private static void BootstrapServices()
	    {
		    var cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
			
		    var factory = NhDalFactory.Create(cs, WebConfig.ResetSchemata);
		    if (WebConfig.ResetSchemata)
		    {
			    using (var dal = factory.Create())
			    {
				    SampleData.FillDal(dal);
			    }
		    }

		    // global
		    _container.RegisterInstance<IDalFactory>(factory);

		    // per request
		    _container.RegisterType<IdentityInfo>(PerRequest());
		    _container.RegisterType<IDal>(PerRequest(), new InjectionFactory(_ => _.Resolve<IDalFactory>().Create()));
		    _container.RegisterType<IViewPageActivator, MyViewActivator>(PerRequest());
	    }

	    private static LifetimeManager PerRequest()
	    {
		    return new PerRequestLifetimeManager();
	    }

        public static void Shutdown()
        {
			_container.Dispose();
        }
    }
}