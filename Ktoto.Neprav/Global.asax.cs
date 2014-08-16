using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ktoto.Neprav.DAL;
using Microsoft.Practices.Unity;

namespace Ktoto.Neprav
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
	        var config = new WebConfig
	        {
		        Expose = false
	        };

            AreaRegistration.RegisterAllAreas();

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            var container = Bootstrapper.Initialize(config);

	        if (config.Expose)
	        {
		        InitialData(container);
	        }
        }

	    private static void InitialData(IUnityContainer container)
	    {
		    using (var dal = container.Resolve<IDalFactory>().Create())
		    {
			    SampleData.FillDal(dal);
		    }
	    }
    }
}