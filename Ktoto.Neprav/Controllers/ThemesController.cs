using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ktoto.Neprav.DAL;
using Ktoto.Neprav.Domain;
using Ktoto.Neprav.Models;

namespace Ktoto.Neprav.Controllers
{
    public class ThemesController : Controller
    {
        private readonly IDal _dal;

        public ThemesController(IDal dal)
        {
            _dal = dal;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(string text)
        {
            var found = _dal.Query<Theme>().Where(_ => _.Name.Contains(text)).ToList();
            return View(new FoundThemes(found, text));
        }
    }
}
