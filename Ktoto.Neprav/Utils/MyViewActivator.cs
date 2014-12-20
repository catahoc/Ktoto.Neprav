using System;
using System.Web.Mvc;
using Ktoto.Neprav.Models;
using Microsoft.Practices.Unity;

namespace Ktoto.Neprav.Utils
{
    public class MyViewActivator: IViewPageActivator
    {
        private readonly IUnityContainer _container;

        public MyViewActivator(IUnityContainer container)
        {
            _container = container;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            var page = _container.Resolve(type);
			type.GetProperty("This").SetValue(page, controllerContext.HttpContext.Request.Url.AbsoluteUri);
			type.GetProperty("VkArgs").SetValue(page, _container.Resolve<IVkArgs>());
			type.GetProperty("IdentityInfo").SetValue(page, _container.Resolve<IIdentityInfoFactory>().Create());
            return page;
        }
    }
}