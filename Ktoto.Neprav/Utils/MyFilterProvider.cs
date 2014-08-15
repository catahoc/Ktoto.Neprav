using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace Ktoto.Neprav.Utils
{
    public class MyFilterProvider : IFilterProvider
    {
        private readonly IUnityContainer _container;

        public MyFilterProvider(IUnityContainer container)
        {
            _container = container;
        }

        public IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            foreach (IActionFilter actionFilter in this._container.ResolveAll<IActionFilter>())
            {
                yield return new Filter(actionFilter, FilterScope.First, null);
            }
        }
    }
}