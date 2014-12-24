using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.Utils;

namespace Ktoto.Neprav.Controllers
{
	public class VkController: Controller
	{
		private readonly IVkArgsService _service;

		public VkController(IVkArgsService service)
		{
			_service = service;
		}

		public ActionResult Welcome()
		{
			if (_service.IsRequestFromVk(Request))
			{
				_service.SaveVkArgsAsCookies(Request, Response);
				return RedirectToAction("Search", "Themes");
			}
			else
			{
				throw new Exception("request should be from vk app");
			}
		}
	}
}