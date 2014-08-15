using System.Web;
using System.Web.Mvc;

namespace Ktoto.Neprav
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}