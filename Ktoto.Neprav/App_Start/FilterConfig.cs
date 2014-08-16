using System.Web.Mvc;
using Ktoto.Neprav.DAL;

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